using CDragonWrapper.Entities;
using CDragonWrapper.Exceptions;
using CDragonWrapper.Logics;
using CDragonWrapper.Misc;
using System.Net.Http.Json;

namespace CDragonWrapper.DataTypes
{
    public class SummonerSpellList : List<SummonerSpellEntity>
    {
        public SummonerSpellList(string version = "latest", Language language = Language.DEFAULT)
        {
            var gettedData = Client.Http.GetFromJsonAsync<List<SummonerSpellEntity>>(
                UrlManager.GameData.GetUrl(version, language, "summoner-spells")).Result;

            if (gettedData == null)
            {
                throw new CDragonException("Unexpected itemData.");
            }
            Clear();
            AddRange(gettedData);
        }
    }
}
