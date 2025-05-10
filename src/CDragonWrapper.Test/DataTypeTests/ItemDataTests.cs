using CDragonWrapper.DataTypes;
using RiotApiWrapper;
using RiotApiWrapper.Misc;

namespace CDragonWrapper.Test
{
    [TestClass]
    public class ItemDataTests
    {
        [TestMethod]
        public async Task TestWithApi()
        {
            var test = new ItemList();
            var api = new RiotApi("RGAPI-f2fd9645-376c-46ea-a3ba-8b81661a5885");
            var account = await api.Account.GetByGameIdAsync(Region.Asia, "GreatKobayashi", "JP1");
            var matchIds = await api.Match.GetIdListAsync(Region.Asia, account.PuuId);
            var match = await api.Match.GetInfoAsync(Region.Asia, matchIds[0]);

            var summonerSpellList = new SummonerSpellList();
            var spell1 = summonerSpellList.Find(x => x.Id == match.Info.Participants[0].Summoner1Id);

            var mapList = new MapList();
            var map = mapList.Find(x => x.Id == match.Info.MapId);
            var perkStyleList = new PerkStyleList("latest", Misc.Language.ja_jp);
            var perkList = new PerkList("latest", Misc.Language.ja_jp);
            var perkStyle = perkStyleList.Find(x => x.Id == match.Info.Participants[0].Perks.Styles[0].Style);
            var perk = perkList.Find(x => x.Id == match.Info.Participants[0].Perks.Styles[0].Selections[0].Perk);
            var queueData = new QueueList("latest", Misc.Language.ja_jp);
            var queue = queueData.Find(x => x.Id == match.Info.QueueId);
            var summonerIconList = new SummonerIconList();
            var summonerIcon = summonerIconList.Find(x => x.Id == match.Info.Participants[0].ProfileIcon);
            var iconUrl = summonerIcon!.ImageUrl;

            var timeline = await api.Match.GetTimeLineAsync(Region.Asia, matchIds[0]);
        }
    }
}