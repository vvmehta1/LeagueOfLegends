using Newtonsoft.Json;
using System.Collections.Generic;

namespace LOL.WebAPI.Models
{
    public class Spell
    {
        [JsonProperty(PropertyName = "cooldown")]
        public List<double> CoolDowns { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}