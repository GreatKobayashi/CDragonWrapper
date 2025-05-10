using CDragonWrapper.Entities;
using CDragonWrapper.Exceptions;
using CDragonWrapper.Logics;
using CDragonWrapper.Misc;
using System.Net.Http.Json;
using System.Text.Json;

namespace CDragonWrapper.DataTypes
{
    public class PerkStyleList : List<PerkStyleEntity>
    {
        public PerkStyleList(string version = "latest", Language language = Language.DEFAULT)
        {
            var gettedData = new List<PerkStyleEntity>();

            if (Client.Http.GetFromJsonAsync<Dictionary<string, JsonElement>>(
                UrlManager.GameData.GetUrl(version, language, "perkstyles")).Result is Dictionary<string, JsonElement> elements)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                gettedData = elements["styles"].EnumerateArray().ToList().ConvertAll(x => JsonSerializer.Deserialize<PerkStyleEntity>(x.GetRawText(), options))!;
            }

            if (gettedData == null)
            {
                throw new CDragonException("Unexpected items.json.");
            }

            Clear();
            AddRange(gettedData);
        }
    }
}
