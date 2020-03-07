using System;
using System.Collections.Generic;
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

            // Creates the OAuth 2.0 authorization request.
            string authorizationRequest = string.Format("{0}?response_type=code&redirect_uri={1}&client_id={2}&scope=&state={3}",
                authorizationEndpoint,
                System.Uri.EscapeDataString(redirectUrl),
                clientId,
                GenerateStateValue(32) // Random state value...
            );

            // Opens request in the browser.
            System.Diagnostics.Process.Start(authorizationRequest);

            // Waits for the OAuth authorization response.
            var httpResponse = await httpListener.GetContextAsync();

            // Brings this app back to the foreground.
            mainInstance.Activate();

            // Sends an HTTP response to the browser.
            string responseString = string.Format("<html><head><title>Authentication</title></head><body><p>Please return to the app. You may now close this tab/window.</p></body></html>");
            var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            httpResponse.Response.ContentLength64 = buffer.Length;
            var responseOutput = httpResponse.Response.OutputStream;
            Task responseTask = responseOutput.WriteAsync(buffer, 0, buffer.Length).ContinueWith((task) =>
            {
                responseOutput.Close();
                httpListener.Stop();
            });

            // Checks for errors.
            if (httpResponse.Request.QueryString.Get("error") != null)
            {
                MessageBox.Show(String.Format("OAuth authorization error: {0}.", httpResponse.Request.QueryString.Get("error")));
                return;
            }
            if (httpResponse.Request.QueryString.Get("code") == null)
            {
                MessageBox.Show("Malformed authorization response. " + httpResponse.Request.QueryString);
                return;
            }

            // extracts the code
            return httpResponse.Request.QueryString.Get("code");
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
