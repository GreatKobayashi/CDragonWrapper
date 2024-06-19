using System.Diagnostics;

namespace CDragonWrapper.Test
{
    [TestClass]
    public class ChampionImageTests
    {
        private HttpClient _httpClient = new();

        [TestMethod]
        public async Task TestGetSquareIconPath()
        {
            var test = CDragon.ChampionImage.GetSquareIconPath("JarvanIV");
            var response = await _httpClient.GetAsync(test);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task TestGetCircleSkinIconPath()
        {
            var allImage = new List<string>();

            foreach (var champion in CDragon.ChampionJson.GetAllEntities())
            {
                var test = CDragon.ChampionImage.GetCircleSkinIconPath(champion.Name, 1);
                allImage.Add(test);
            }

            var client = new HttpClient();
            foreach (var path in allImage)
            {
                var response = await client.GetAsync(path);
                if (!response.IsSuccessStatusCode)
                {
                    Assert.Fail();
                }
            }
        }
    }
}