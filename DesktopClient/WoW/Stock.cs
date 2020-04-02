using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DesktopClient.WoW
{
    class Stock
    {
        public List<Item> Mail = new List<Item>();
        public List<Item> Bags = new List<Item>();

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public async void Post(string json)
        {

        }
    }
}
