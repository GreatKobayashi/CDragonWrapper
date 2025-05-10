using CDragonWrapper.Entities;
using CDragonWrapper.Exceptions;
using CDragonWrapper.Logics;
using CDragonWrapper.Misc;
using System.Net.Http.Json;

namespace CDragonWrapper.DataTypes
{
    public class PerkList : List<PerkEntity>
    {
        public PerkList(string version = "latest", Language language = Language.DEFAULT)
        {
            var gettedData = Client.Http.GetFromJsonAsync<List<PerkEntity>>(
                UrlManager.GameData.GetUrl(version, language, "perks")).Result;

            if (gettedData == null)
            {
                throw new CDragonException("Unexpected items.json.");
            }
            Clear();
            AddRange(gettedData);
        }
    }
}
