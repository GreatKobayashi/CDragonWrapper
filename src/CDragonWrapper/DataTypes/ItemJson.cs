using CDragonWrapper.EndPoints;
using CDragonWrapper.Entities;
using CDragonWrapper.Exceptions;
using RiotApiWrapper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CDragonWrapper.DataTypes
{
    public class ItemJson : DataType
    {
        private static List<ItemEntity>? _itemList;

        public List<ItemEntity> GetAllEntities()
        {
            if (_itemList == null)
            {
                var itemData = Client.GetFromJsonAsync<List<Dictionary<string, JsonElement>>>("https://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/default/v1/items.json").Result;

                if (itemData == null)
                {
                    throw new CDragonException("Unexpected itemData.");
                }

                var itemEntities = new List<ItemEntity>();
                foreach (var itemDatum in itemData)
                {
                    itemEntities.Add(new ItemEntity(itemDatum["id"].GetInt32(), itemDatum["name"].GetString()!, itemDatum["iconPath"].GetString()!.Substring(43)));
                }
                _itemList = itemEntities;
            }

            return _itemList;
        }

        internal string ConvertToIcon(int itemId)
        {
            _itemList ??= GetAllEntities();
            try
            {
                return _itemList.First(x => x.Id == itemId).Icon;
            }
            catch (Exception ex)
            {
                throw new CDragonException($"Invalid itemId. id:{itemId}.", ex);
            }
        }
    }
}
