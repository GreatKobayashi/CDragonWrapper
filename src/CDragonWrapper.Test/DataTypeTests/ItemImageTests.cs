namespace CDragonWrapper.Test
{
    [TestClass]
    public class ItemImageTests
    {
        private HttpClient _httpClient = new();

        [TestMethod]
        public async Task TestGetIconImage()
        {
            var test = CDragon.ItemImage.GetIconImage(1001);
            var response = await _httpClient.GetAsync(test);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}