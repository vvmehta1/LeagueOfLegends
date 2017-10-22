
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LOL.WebAPI.Models
{
    public class RootObject
    {
        [JsonProperty(PropertyName = "data")]
        public Dictionary<string, Champion> Champions { get; set; }
    }
}