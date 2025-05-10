using CDragonWrapper.Entities;
using CDragonWrapper.Exceptions;
using CDragonWrapper.Logics;
using CDragonWrapper.Misc;
using System.Net.Http.Json;

namespace CDragonWrapper.DataTypes
{
    public class SummonerIconList : List<SummonerIconEntity>
    {
        public SummonerIconList(string version = "latest", Language language = Language.DEFAULT)
        {
            var gettedData = Client.Http.GetFromJsonAsync<List<SummonerIconEntity>>(
                UrlManager.GameData.GetUrl(version, language, "summoner-icons")).Result;

            if (gettedData == null)
            {
                throw new CDragonException("Unexpected items.json.");
            }
            Clear();
            AddRange(gettedData);
        }
    }
}
