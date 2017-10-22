using Newtonsoft.Json;
using System.Collections.Generic;

namespace LOL.WebAPI.Models
{
    public class Spell
    {
        [JsonProperty(PropertyName = "cooldown")]
        public List<double> CoolDowns { get; set; }
    }
}