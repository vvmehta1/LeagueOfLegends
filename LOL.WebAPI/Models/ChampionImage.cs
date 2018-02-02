using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOL.WebAPI.Models
{
    public class ChampionImage
    {
        public string url {
            get
            {
                return "http://ddragon.leagueoflegends.com/cdn/8.2.1/img/sprite/" + sprite;
            }
        }
        public string full { get; set; }
        public string sprite { get; set; }
        public string group { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int h { get; set; }
        public int w { get; set; }
        

    }
}