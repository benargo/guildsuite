using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Web;

namespace DesktopClient
{
    public class ApiClient
    {
        private string AuthorizationHeader;

        public const string BankersApiUrl = "https://theorder.gg/api/guild-bank/bankers";
        public const string UpdateStockApiUrl = "https://theorder.gg/api/guild-bank/stock/update";

        public void SetAccessToken(string token)
        {
            AuthorizationHeader = $"Bearer {token}";
        }

        public async Task<JObject> Get(string url)
        {
            // Set up the HTTP request...
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "application/json";
            request.Method = "GET";
            request.Headers.Add("Authorization", AuthorizationHeader);

            // Attempt the request...
            try
            {
                // Send the request and wait for the response to come back...
                WebResponse response = await request.GetResponseAsync();

                // Put on our reading glasses and read the API's response...
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    // Read the response body...
                    string responseText = await reader.ReadToEndAsync();

                    // Parse the response as JSON...
                    return JObject.Parse(responseText);
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return null;
        }

        public async Task<JObject> Post(string url, Dictionary<string, string> formData)
        {
            string postData = "";

            foreach (string key in formData.Keys)
            {
                postData += HttpUtility.UrlEncode(key)
                          + "="
                          + HttpUtility.UrlEncode(formData[key])
                          + "&";
            }

            // Build the request object...
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "application/json";
            request.Method = "POST";
            request.Headers.Add("Authorization", AuthorizationHeader);

            byte[] data = Encoding.ASCII.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            // Build the post data...
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();

            // Attempt the request...
            try
            {
                // Send the request and wait for the response to come back...
                WebResponse response = await request.GetResponseAsync();

                // Put on our reading glasses and read the API's response...
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    // Read the response body...
                    string responseText = await reader.ReadToEndAsync();

                    // Parse the response as JSON...
                    return JObject.Parse(responseText);
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return null;
        }
    }
}
