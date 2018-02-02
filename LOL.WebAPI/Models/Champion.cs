using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace LOL.WebAPI.Models
{
    public class Champion
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "spells")]
        public List<Spell> Spells { get; set; }
        [JsonProperty(PropertyName = "image")]
        public ChampionImage Image { get; set; }
        
    }
}