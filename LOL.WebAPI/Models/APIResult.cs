
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LOL.WebAPI.Models
{
    public class APIResult
    {
        public APIResult()
        {
            Players = new List<Models.Player>();
        }
        [JsonProperty(PropertyName = "players")]
        public List<Player> Players { get; set; }

        public bool HasErrors { get; set; }

        public string ErrorDescription { get; set; }
    }
}