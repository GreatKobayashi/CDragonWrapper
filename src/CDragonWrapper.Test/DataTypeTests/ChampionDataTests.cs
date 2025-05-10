using CDragonWrapper.DataTypes;
using CDragonWrapper.Entities;

namespace CDragonWrapper.Test
{
    [TestClass]
    public class ChampionDataTests
    {
        [TestMethod]
        public async Task TestGetChampionList()
        {
            var data = new ChampionList("latest", Misc.Language.ja_jp);

            var champion = data.Find(x => x.Name == "トリスターナ")!;
            var detail = new ChampionDetailEntity(champion.Id);

            var skinImage = detail.Skins[1].LoadScreenPath;
            var qVideo = detail.Spells.First(x => x.SpellKey == "q").AbilityVideoUrl;
        }
    }
}