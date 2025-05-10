using CDragonWrapper.Entities;
using CDragonWrapper.Exceptions;
using CDragonWrapper.Logics;
using CDragonWrapper.Misc;
using System.Net.Http.Json;

namespace CDragonWrapper.DataTypes
{
    public class MapList : List<MapEntity>
    {
        public MapList(string version = "latest", Language language = Language.DEFAULT)
        {
            var gettedData = Client.Http.GetFromJsonAsync<List<MapEntity>>(
                UrlManager.GameData.GetUrl(version, language, "maps")).Result;

            if (gettedData == null)
            {
                throw new CDragonException("Unexpected items.json.");
            }
            Clear();
            AddRange(gettedData);
        }
    }
}
