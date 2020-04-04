using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace DesktopClient.WoW
{
    class Stock
    {
        public List<Item> mail = new List<Item>();
        public List<Item> bags = new List<Item>();

        public string ToJson()
        {
            return JsonConvert.SerializeObject(new Dictionary<string, Stock>(){
                { "stock", this }
            });
        }

        public async void Post(ApiClient apiClient, string json)
        {
            // Prepare the data to be sent...
            Dictionary<string, string> formData = new Dictionary<string, string>()
            {
                { "stock", json }
            };

            // Make the API request...
            JObject _ = await apiClient.Post(ApiClient.UpdateStockApiUrl, formData);
            
            // We don't want to do anything with the response, so finish here...
        }
    }
}
