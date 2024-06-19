using CDragonWrapper.EndPoints;
using CDragonWrapper.Exceptions;
using RiotApiWrapper.Entities;

namespace CDragonWrapper.DataTypes
{
    public class ChampionImage : DataType
    {
        public string GetSquareIconPath(string championName)
        {
            return GetSquareIconPath(CDragon.ChampionJson.ConvertToChampionId(championName));
        }

        public string GetSquareIconPath(int championId)
        {
            return $"https://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/default/v1/champion-icons/{championId}.png";
        }

        public string GetCircleSkinIconPath(string championName, int skinId)
        {
            if (skinId == 0)
            {
                throw new CDragonException("Invalid skinId. skin:0.");
            }

            championName = CDragon.ChampionJson.FormChanmpionName(championName);
            var addition = (string?)null;
            switch (championName)
            {
                case "leesin":
                    if (skinId < 50)
                    {
                        addition = ".asu_leesin";
                    }
                    break;
                case "skarner":
                    addition = ".skarner_rework";
                    break;
            }

            return $"https://raw.communitydragon.org/latest/game/assets/characters/{championName}/hud/{championName}_circle_{skinId}{addition}.png";
        }

        public string GetCircleIconPath(int championId, int skinId)
        {
            return GetCircleSkinIconPath(CDragon.ChampionJson.ConvertToChampionName(championId), skinId);
        }
    }
}
