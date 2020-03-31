using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace DesktopClient
{
    class ApiClient
    {
        private readonly Main MainInstance;
        private readonly OAuthClient OAuthClient;
        private readonly string AuthorizationHeader;

        public List<Banker> Bankers;

        const string BankersApiUrl = "https://theorder.gg/api/guild-bank/bankers";

        public ApiClient(Main main, OAuthClient client)
        {
            MainInstance = main;
            OAuthClient = client;
            AuthorizationHeader = $"Bearer {OAuthClient.Token}";
        }

        public async void GetBankersAsync()
        {
            // Set up the HTTP request...
            HttpWebRequest bankersRequest = (HttpWebRequest)WebRequest.Create(BankersApiUrl);
            bankersRequest.Accept = "application/json";
            bankersRequest.Method = "GET";
            bankersRequest.Headers.Add("Authorization", AuthorizationHeader);            

            // Attempt the request...
            try
            {
                // Send the request and wait for the response to come back...
                WebResponse context = await bankersRequest.GetResponseAsync();

                // Put on our reading glasses and read the API's response...
                using (StreamReader reader = new StreamReader(context.GetResponseStream()))
                {
                    // Read the response body...
                    string responseText = await reader.ReadToEndAsync();

                    // Convert the response to a dictionary...
                    JObject responseObject = JObject.Parse(responseText);
                    JArray bankersArray = (JArray)responseObject["bankers"];
                    Bankers = bankersArray.ToObject<List<Banker>>();
                }

                // Update the list of bankers in the main instance...
                MainInstance.labelBankersList_Update(Bankers);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }
    }
}
