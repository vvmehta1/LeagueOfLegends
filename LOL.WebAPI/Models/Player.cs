using Newtonsoft.Json;

namespace LOL.WebAPI.Models
{
    public class Player
    {
        [JsonProperty(PropertyName = "summonername")]
        public string SummonerName { get; set; }
        [JsonProperty(PropertyName = "teamid")]
        public long TeamId { get; set; }
        [JsonProperty(PropertyName = "championid")]
        public long ChampionId { get; set; }
        [JsonProperty(PropertyName = "champion")]
        public Champion Champion { get; set; }
        
    }
}