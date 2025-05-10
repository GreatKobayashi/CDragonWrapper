using CDragonWrapper.Entities;
using CDragonWrapper.Exceptions;
using CDragonWrapper.Logics;
using CDragonWrapper.Misc;
using System.Net.Http.Json;

namespace CDragonWrapper.DataTypes
{
    public class ItemList : List<ItemEntity>
    {
        public ItemList(string version = "latest", Language language = Language.DEFAULT)
        {
            var gettedData = Client.Http.GetFromJsonAsync<List<ItemEntity>>(
                UrlManager.GameData.GetUrl(version, language, "items")).Result;

            if (gettedData == null)
            {
                throw new CDragonException("Unexpected items.json.");
            }
            Clear();
            AddRange(gettedData);
        }
    }
}
