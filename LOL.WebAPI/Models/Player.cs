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
        [JsonProperty(PropertyName = "team")]
        public string Team
        {
            get
            {
                if(TeamId == 100)
                    return "Blue";
                else if(TeamId == 200)
                    return "Red";
                else
                    return TeamId.ToString();
            }
        }
        [JsonProperty(PropertyName = "teamcolor")]
        public string TeamColor
        {
            get
            {
                if (TeamId == 100)
                    return "lightblue";
                else if (TeamId == 200)
                    return "lightcoral";
                else
                    return TeamId.ToString();
            }
        }
    }
}