﻿using LOL.WebAPI.Models;
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

        // GET: api/Champions/5
        public string Get(int id)
        {
            return "value";
        }
        
    }
}
