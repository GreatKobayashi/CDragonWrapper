using CDragonWrapper.EndPoints;
using CDragonWrapper.Exceptions;
using RiotApiWrapper.Entities;
using System.Net.Http.Json;
using System.Text.Json;

namespace CDragonWrapper.DataTypes
{
    public class ChampionJson : DataType
    {
        private static List<ChampionEntity>? _championList;

        public ChampionDetailEntity GetDetail(ChampionEntity champion)
        {
            return GetDetail(champion.Id);
        }

        public ChampionDetailEntity GetDetail(int championId)
        {
            // TODO
            return new ChampionDetailEntity(0, "", 0);
        }

        public List<ChampionEntity> GetAllEntities()
        {
            if (_championList == null)
            {
                var championData = Client.GetFromJsonAsync<List<Dictionary<string, JsonElement>>>("https://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/default/v1/champion-summary.json").Result;

                if (championData == null)
                {
                    throw new CDragonException("Unexpected championData.");
                }

                var championEntities = new List<ChampionEntity>();
                foreach (var championDatum in championData)
                {
                    if (championDatum["id"].GetInt32() == -1)
                    {
                        continue;
                    }
                    championEntities.Add(new ChampionEntity(championDatum["id"].GetInt32(), championDatum["name"].GetString()!, 0));
                }

                _championList = championEntities;
            }

            return _championList;
        }

        public Dictionary<int, string> GetAllSkins(int championId)
        {
            var skinData = Client.GetFromJsonAsync<Dictionary<string, Dictionary<string, JsonElement>>>("https://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/default/v1/skins.json").Result;

            if (skinData == null)
            {
                throw new CDragonException("Unexpected skinData.");
            }

            var skins = new Dictionary<int, string>();
            foreach (var skinDatum in skinData)
            {
                if (skinDatum.Key[..^3] == championId.ToString())
                {
                    skins.Add(skinDatum.Value["id"].GetInt32() % 1000, skinDatum.Value["name"].GetString()!);
                }
            }

            return skins;
        }

        public string ConvertToChampionName(int championId)
        {
            _championList ??= GetAllEntities();
            return _championList.First(x => x.Id == championId).Name;
        }

        public int ConvertToChampionId(string championName)
        {
            _championList ??= GetAllEntities();
            var formedChampionName = FormChanmpionName(championName);
            return _championList.First(x => string.Compare(FormChanmpionName(x.Name), formedChampionName, true) == 0).Id;
        }

        internal string FormChanmpionName(string originalchampionName)
        {
            var championName = originalchampionName.ToLower().Replace(" ", "").Replace("'", "").Replace(".", "");
            switch (championName)
            {
                case "wukong":
                    championName = "monkeyking";
                    break;
                case "nunu&willump":
                    championName = "nunu";
                    break;
                case "renataglasc":
                    championName = "renata";
                    break;
            }

            return championName;
        }

        public ChampionEntity GetEntity(int championId)
        {
            _championList ??= GetAllEntities();
            return _championList.First(x => x.Id == championId);
        }

        public ChampionEntity GetEntity(string championName)
        {
            _championList ??= GetAllEntities();
            return _championList.First(x => x.Name.ToLower() == championName.ToLower());
        }
    }
}
