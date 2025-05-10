using CDragonWrapper.Entities;
using CDragonWrapper.Exceptions;
using CDragonWrapper.Logics;
using CDragonWrapper.Misc;
using System.Net.Http.Json;

namespace CDragonWrapper.DataTypes
{
    public class ChampionList : List<ChanpionEntity>
    {
        public ChampionList(string version = "latest", Language language = Language.DEFAULT)
        {
            var gotData = Client.Http.GetFromJsonAsync<List<ChanpionEntity>>(
                UrlManager.GameData.GetUrl(version, language, "champion-summary")).Result;

            if (gotData == null)
            {
                throw new CDragonException("Unexpected error.");
            }
            gotData.ForEach(e => { e.SetMetaValue(version, language); });

            Clear();
            AddRange(gotData);
        }
    }
}
