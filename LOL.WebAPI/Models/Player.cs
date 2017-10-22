namespace LOL.WebAPI.Models
{
    public class Player
    {
        public string SummonerName { get; set; }
        public long TeamId { get; set; }
        public string NameExtraDetails
        {
            get
            {
                return $"Name: {SummonerName}\n-------------------\nMasteries:\nCooldown Cap Increase: {HasCDCapIncrease}\nSummonerSpell Cooldown Reduction: {HasSumSpellCd}";
            }
        }
        public bool HasSumSpellCd { get; set; }
        public bool HasCDCapIncrease { get; set; }
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