using CDragonWrapper.EndPoints;
using CDragonWrapper.Entities;
using CDragonWrapper.Exceptions;
using RiotApiWrapper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CDragonWrapper.DataTypes
{
    public class SummonerSpellJson : DataType
    {
        private static List<SummonerSpellEntity>? _summonerSpellList;

        public List<SummonerSpellEntity> GetAllEntities()
        {
            if (_summonerSpellList == null)
            {
                var summonerSpellData = Client.GetFromJsonAsync<List<Dictionary<string, JsonElement>>>("https://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/default/v1/summoner-spells.json").Result;

                if (summonerSpellData == null)
                {
                    throw new CDragonException("Unexpected itemData.");
                }

                var summonerSpellEntities = new List<SummonerSpellEntity>();
                foreach (var summonerSpellDatum in summonerSpellData)
                {
                    summonerSpellEntities.Add(new SummonerSpellEntity(summonerSpellDatum["id"].GetUInt32(), summonerSpellDatum["name"].GetString()!, summonerSpellDatum["iconPath"].GetString()!.Substring(42).ToLower()));
                }
                _summonerSpellList = summonerSpellEntities;
            }

            return _summonerSpellList;
        }

        internal string ConvertToIcon(int summonerSpellId)
        {
            _summonerSpellList ??= GetAllEntities();
            try
            {
                return _summonerSpellList.First(x => x.Id == summonerSpellId).Icon;
            }
            catch (Exception ex)
            {
                throw new CDragonException($"Invalid summonerSpellId. id:{summonerSpellId}.", ex);
            }
        }
    }
}
