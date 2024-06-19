namespace CDragonWrapper.Test
{
    [TestClass]
    public class ItemJsonTests
    {
        [TestMethod]
        public void TestGetAllIds()
        {
            var test = CDragon.ItemJson.GetAllEntities();
        }
    }
}