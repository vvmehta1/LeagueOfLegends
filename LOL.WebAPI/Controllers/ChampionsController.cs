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
    [EnableCorsAttribute("http://localhost:53861", "*", "*")]
    public class ChampionsController : ApiController
    {
        public static List<Champion> Champions = new List<Champion>();

        // GET: api/Champions
        //[EnableQuery()]
        public IEnumerable<Champion> Get()
        {
            var repository = new DataRepository();

            if(!(Champions.Count > 0))
            {
                LoadChampions(repository);
            }
            
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

                if(!(Champions.Count > 0))
                {
                    LoadChampions(repository);
                }

                foreach(var player in Players)
                {
                    // Load Champion
                    player.Champion = Champions.FirstOrDefault(x => x.Id == player.ChampionId);
                }

            }           
            return Players;
        }

        private void LoadChampions(DataRepository repository)
        {
            var json = repository.GetMainData();
            var champions = JsonConvert.DeserializeObject<RootObject>(json);

            foreach (var champ in champions.Champions)
                Champions.Add(champ.Value);
        }
        
    }
}
