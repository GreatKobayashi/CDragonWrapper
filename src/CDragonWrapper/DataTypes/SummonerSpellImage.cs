using CDragonWrapper.EndPoints;
using RiotApiWrapper.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDragonWrapper.DataTypes
{
    public class SummonerSpellImage : DataType
    {
        public string GetIconImage(string summonerSpellName)
        {
            return GetIconImage(Enum.Parse<SummonerSpell>(summonerSpellName, true));
        }

        public string GetIconImage(int summonerSpellId)
        {
            var summonerSpells = CDragon.SummonerSpellJson.GetAllEntities();
            var summonerSpell = summonerSpells.First(x => x.Id == summonerSpellId);
            return $"https://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/default/data/spells/icons2d/{summonerSpell.Icon}";
        }

        public string GetIconImage(SummonerSpell summonerSpell)
        {
            return GetIconImage((int)summonerSpell);
        }
    }
}
