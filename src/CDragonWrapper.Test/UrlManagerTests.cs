using CDragonWrapper.Logics;
using CDragonWrapper.Misc;

namespace CDragonWrapper.Test
{
    [TestClass]
    public class UrlManagerTests
    {
        [TestMethod]
        public void TestGetMatchHistoryIconUrl()
        {
            var actualUrl = UrlManager.Image.GetMatchHistoryIconUrl(EpicMonster.Baronnashor);
        }
    }
}
