
using LOL.WebAPI.Interfaces.Repositories;
using LOL.WebAPI.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Web.Hosting;

namespace LOL.WebAPI.Repositories
{
    public class DataRepository : IDataRepository
    {
        //string doc = HostingEnvironment.MapPath(@"~/App_Data/leaguedata.json");
        string doc = HostingEnvironment.MapPath(@"~/App_Data/imageData.json");

        string apiKey = "";
        string url = "https://na1.api.riotgames.com/lol/";

        HttpWebRequest httpreq;
        HttpWebResponse httpres;
        long summonerId;
        string getSummonerIdReq = "summoner/v3/summoners/by-name/";
        string getLiveGameReq = "spectator/v3/active-games/by-summoner/";

        public string GetMainData()
        {
            using (StreamReader r = new StreamReader(doc))
            {
                string json = r.ReadToEnd();
                return json;
            }
        }

        public APIResult GetLiveData(string summonerName)
        {
            APIResult result = new APIResult();

            GetAccount(summonerName);
            GetLiveGameInfo(result);

            return result;
        }

        private void GetLiveGameInfo(APIResult resultObj)
        {
            httpreq = HttpRequestSetup(getLiveGameReq + summonerId + "?");
            try
            {
                httpres = (HttpWebResponse)httpreq.GetResponse();

                var result = GetJsonResult(httpres);
                dynamic jsonob = JsonConvert.DeserializeObject(result);
                GetGameData(jsonob, resultObj);
            }
            catch (Exception e)
            {
                resultObj.HasErrors = true;
                resultObj.ErrorDescription = "Summoner not found or not currenlty in a live game. Please try again";
            }
        }

        private void GetGameData(dynamic liveGame, APIResult resultObj)
        {
            if (!resultObj.HasErrors)
            {
                foreach (var summoner in liveGame.participants)
                {
                    var livePlayer = new Player();
                    livePlayer.SummonerName = summoner.summonerName;
                    livePlayer.TeamId = summoner.teamId;
                    livePlayer.ChampionId = summoner.championId;
                    
                    resultObj.Players.Add(livePlayer);
                }
            }

        }

        private void GetAccount(string SummonerName)
        {
            httpreq = HttpRequestSetup(getSummonerIdReq + SummonerName + "?");
            httpres = (HttpWebResponse)httpreq.GetResponse();
            var result = GetJsonResult(httpres);
            dynamic jsonob = JsonConvert.DeserializeObject(result);
            summonerId = GetSummonerId(jsonob);
        }

        private HttpWebRequest HttpRequestSetup(string api)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + api + apiKey);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "GET";
            httpWebRequest.Credentials = new NetworkCredential("username", "password");

            return httpWebRequest;
        }



        private long GetSummonerId(dynamic jsonObject)
        {
            foreach (var item in jsonObject)
            {
                if (item.Name == "id")
                {
                    summonerId = item.Value;
                    break;
                }
            }
            return summonerId;
        }



        private string GetJsonResult(HttpWebResponse httpResponse)
        {
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return result;
            }
        }

    }
}
