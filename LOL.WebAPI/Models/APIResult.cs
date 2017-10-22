
using System.Collections.Generic;

namespace LOL.WebAPI.Models
{
    public class APIResult
    {
        public APIResult()
        {
            Players = new List<Models.Player>();
        }

        public List<Player> Players { get; set; }

        public bool HasErrors { get; set; }

        public string ErrorDescription { get; set; }
    }
}