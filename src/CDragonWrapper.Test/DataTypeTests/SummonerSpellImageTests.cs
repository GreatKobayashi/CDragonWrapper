using RiotApiWrapper.Misc;

namespace CDragonWrapper.Test
{
    [TestClass]
    public class SummonerSpellImageTests
    {
        private HttpClient _httpClient = new();

        [TestMethod]
        public async Task TestGetIconImage()
        {
            var test = CDragon.SummonerSpellImage.GetIconImage(SummonerSpell.Clarity);
            var response = await _httpClient.GetAsync(test);
            Assert.IsTrue(response.IsSuccessStatusCode);

            test = CDragon.SummonerSpellImage.GetIconImage(SummonerSpell.Barrier);
            response = await _httpClient.GetAsync(test);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}