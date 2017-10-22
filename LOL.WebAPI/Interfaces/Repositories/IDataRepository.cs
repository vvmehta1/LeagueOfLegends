using LOL.WebAPI.Models;
namespace LOL.WebAPI.Interfaces.Repositories
{
    public interface IDataRepository
    {
        #region Data  Repository Methods

        string GetMainData();

        APIResult GetLiveData(string summonerName);

        #endregion
    }
}
