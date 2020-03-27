using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient
{
    class OAuthClient
    {
        public int clientId;
        public string clientSecret;
        public string redirectUrl;

        public string error;
        public string token;

        const string authorizationEndpoint = "https://theorder.gg/oauth/authorize";
        const string tokenEndpoint = "https://theorder.gg/oauth/token";

        public OAuthClient(int inputClientId, string inputClientSecret, string inputRedirectUrl = "http://localhost:9000/")
        {
            clientId = inputClientId;
            clientSecret = inputClientSecret;
            redirectUrl = inputRedirectUrl;
        }

        public async void GetOAuthTokenAsync(Main mainInstance)
        {
            // Set up the HTTP listener...
            HttpListener httpListener = new HttpListener();
            httpListener.Prefixes.Add(redirectUrl);
            httpListener.Start();

            // Create the OAuth 2.0 authorization request...
            string authorizationRequest = string.Format("{0}?response_type=code&redirect_uri={1}&client_id={2}&scope=&state={3}",
                authorizationEndpoint,
                System.Uri.EscapeDataString(redirectUrl),
                clientId,
                GenerateStateValue(32) // Random state value...
            );

            // Open request in the browser...
            System.Diagnostics.Process.Start(authorizationRequest);

            // Wait for the OAuth authorization response...
            var httpResponse = await httpListener.GetContextAsync();

            // Bring this app back to the foreground...
            mainInstance.Activate();

            // Send an HTTP response to the browser...
            string responseString = string.Format("<html><head><title>Authentication</title></head><body><p>Please return to the app. You may now close this tab/window.</p></body></html>");
            var buffer1 = System.Text.Encoding.UTF8.GetBytes(responseString);
            httpResponse.Response.ContentLength64 = buffer1.Length;
            var responseOutput = httpResponse.Response.OutputStream;
            Task responseTask = responseOutput.WriteAsync(buffer1, 0, buffer1.Length).ContinueWith((task) =>
            {
                responseOutput.Close();
                httpListener.Stop();
            });

            // Check for errors...
            if (httpResponse.Request.QueryString.Get("error") != null)
            {
                error = String.Format("OAuth error: {0}.", httpResponse.Request.QueryString.Get("error"));
                mainInstance.labelIsAuthenticated_Update(false);
                return;
            }
            if (httpResponse.Request.QueryString.Get("code") == null)
            {
                error = "Malformed response received.";
                mainInstance.labelIsAuthenticated_Update(false);
                return;
            }

            // Extract the authentication code...
            var code = httpResponse.Request.QueryString.Get("code");

            // Exchange the authentication code for an authorization token...
            string formDataBoundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");

            // Prepare the HTTP request...
            HttpWebRequest tokenRequest = (HttpWebRequest)WebRequest.Create(tokenEndpoint);
            tokenRequest.Method = "POST";
            tokenRequest.ContentType = "multipart/form-data; boundary=" + formDataBoundary;
            tokenRequest.Accept = "application/json";

            // Build the request body...
            Stream formDataStream = new MemoryStream();         
            string formDataTemplate =
                    Environment.NewLine + "--" + formDataBoundary +
                    Environment.NewLine + "Content-Disposition: form-data; name=\"{0}\";" +
                    Environment.NewLine + Environment.NewLine + "{1}";

            // Grant Type...
            byte[] formDataGrantType = Encoding.UTF8.GetBytes(string.Format(formDataTemplate, "grant_type", "authorization_code"));
            formDataStream.Write(formDataGrantType, 0, formDataGrantType.Length);

            // Client ID...
            byte[] formDataClientId = Encoding.UTF8.GetBytes(string.Format(formDataTemplate, "client_id", clientId));
            formDataStream.Write(formDataClientId, 0, formDataClientId.Length);

            // Client Secret...
            byte[] formDataClientSecret = Encoding.UTF8.GetBytes(string.Format(formDataTemplate, "client_secret", clientSecret));
            formDataStream.Write(formDataClientSecret, 0, formDataClientSecret.Length);

            // Redirect URI...
            byte[] formDataRedirectUri = Encoding.UTF8.GetBytes(string.Format(formDataTemplate, "redirect_uri", redirectUrl));
            formDataStream.Write(formDataRedirectUri, 0, formDataRedirectUri.Length);

            // Code...
            byte[] formDataCode = Encoding.UTF8.GetBytes(string.Format(formDataTemplate, "code", code));
            formDataStream.Write(formDataCode, 0, formDataCode.Length);

            // Set the request length...
            tokenRequest.ContentLength = formDataStream.Length;

            // Set the request...
            Stream tokenRequestStream = tokenRequest.GetRequestStream();
            formDataStream.Position = 0;
            byte[] buffer2 = new byte[1024];
            int bytesRead = 0;
            while ((bytesRead = formDataStream.Read(buffer2, 0, buffer2.Length)) != 0)
            {
                tokenRequestStream.Write(buffer2, 0, bytesRead);
            }
            
            // Cleanup...
            formDataStream.Close();
            tokenRequestStream.Close();

            try
            {
                // Send the request...
                WebResponse tokenResponse = await tokenRequest.GetResponseAsync();

                using (StreamReader tokenResponseStreamReader = new StreamReader(tokenResponse.GetResponseStream()))
                {
                    // Read the entire response body...
                    string responseBody = await tokenResponseStreamReader.ReadToEndAsync();

                    // Convert the response body to a dictionary...
                    Dictionary<string, string> tokenEndpointDecoded = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseBody);

                    // Catch the token
                    token = tokenEndpointDecoded["access_token"];

                    // Set the logged in label...
                    mainInstance.labelIsAuthenticated_Update(true);
                }   
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError && e.Response != null)
                {
                    var errorResponse = e.Response as HttpWebResponse;
                    using (StreamReader errorResponseReader = new StreamReader(errorResponse.GetResponseStream()))
                    {
                        error = String.Format(
                            "HTTP {0}: {1} ", 
                            errorResponse.StatusCode,
                            await errorResponseReader.ReadToEndAsync()
                        );
                    } 
                }

                mainInstance.labelIsAuthenticated_Update(false);
            }
        }

        private static string GenerateStateValue(uint length)
        {
            RNGCryptoServiceProvider rngProvider = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[length];
            rngProvider.GetBytes(bytes);
            return Base64UrlEncode(bytes);
        }

        private static string Base64UrlEncode(byte[] buffer)
        {
            string base64 = Convert.ToBase64String(buffer);

            // Converts base64 to base64url...
            base64 = base64.Replace("+", "-");
            base64 = base64.Replace("/", "_");

            // Strips padding...
            base64 = base64.Replace("=", "");

            return base64;
        }
    }
}
