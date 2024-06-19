using CDragonWrapper.EndPoints;

namespace CDragonWrapper.DataTypes
{
    public class ItemImage : DataType
    {
        public string GetIconImage(int itemId)
        {
            var iconImageName = CDragon.ItemJson.ConvertToIcon(itemId).ToLower();
            return $"https://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/default/assets/items/icons2d/{iconImageName}";
        }
    }
}
