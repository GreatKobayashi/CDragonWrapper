namespace CDragonWrapper.Test
{
    [TestClass]
    public class ChampionJsonTests
    {
        [TestMethod]
        public void TestGetAllEntities()
        {
            var test = CDragon.ChampionJson.GetAllEntities();
        }

        [TestMethod]
        public void TestGetAllSkins()
        {
            var test = CDragon.ChampionJson.GetAllSkins(1);
        }
    }
}