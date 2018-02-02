using LOL.WebAPI.Models;
using LOL.WebAPI.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;

namespace LOL.WebAPI.Controllers
{
    //[EnableCorsAttribute("http://leaguelegends.azurewebsites.net", "*", "*")]
    [EnableCorsAttribute("http://localhost:65503", "*", "*")]
    public class ChampionsController : ApiController
    {
        // GET: api/Champions
        //[EnableQuery()]
        public IEnumerable<Champion> Get()
        {
            var repository = new DataRepository();
            List<Champion> Champions = new List<Champion>();

            var json = repository.GetMainData();
            var champions = JsonConvert.DeserializeObject<RootObject>(json);

            foreach (var champ in champions.Champions)
                Champions.Add(champ.Value);

            return Champions;
        }

        // GET: api/Champions/summonerName
        public IEnumerable<Player> Get(string summoner)
        {
            List<Player> Players = new List<Player>();
            var repository = new DataRepository();
            
            if(!String.IsNullOrEmpty(summoner))
            {
                var result = repository.GetLiveData(summoner);
                Players = result.Players;
            }
            
            return Players;
        }
        
    }
}
