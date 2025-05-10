using CDragonWrapper.Entities;
using CDragonWrapper.Exceptions;
using CDragonWrapper.Logics;
using CDragonWrapper.Misc;
using System.Net.Http.Json;

namespace CDragonWrapper.DataTypes
{
    public class QueueList : List<QueueEntity>
    {
        public QueueList(string version = "latest", Language language = Language.DEFAULT)
        {
            var gettedData = Client.Http.GetFromJsonAsync<List<QueueEntity>>(
                UrlManager.GameData.GetUrl(version, language, "queues")).Result;

            if (gettedData == null)
            {
                throw new CDragonException("Unexpected itemData.");
            }
            Clear();
            AddRange(gettedData);
        }
    }
}
