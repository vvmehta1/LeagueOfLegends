using Newtonsoft.Json;

namespace LOL.WebAPI.Models
{
    public class Player
    {
        [JsonProperty(PropertyName = "summonername")]
        public string SummonerName { get; set; }
        public long TeamId { get; set; }
        public string NameExtraDetails
        {
            get
            {
                return $"Name: {SummonerName}\n-------------------\n";
            }
        }
        [JsonProperty(PropertyName = "championid")]
        public long ChampionId { get; set; }
        public Champion Champion { get; set; }
        public string ChampionString
        {
            get
            {
                return Champion?.ToString();
            }

        }
        
        public override string ToString()
        {
            return $"Name:      {SummonerName}, Team: {TeamId}, Champion:       {ChampionId}";
        }
    }
}