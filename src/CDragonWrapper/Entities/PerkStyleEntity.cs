using CDragonWrapper.Logics;
using System.Text.Json.Serialization;

namespace CDragonWrapper.Entities
{
    public class PerkStyleEntity
    {
        private string? _iconPath;
        private Dictionary<string, string>? _assetMap;

        public PerkStyleEntity(
            int id,
            string name,
            string tooltip,
            string? iconPath,
            Dictionary<string, string>? assetMap,
            bool isAdvanced,
            List<int> allowedSubStyles,
            List<SubStyleBonusEntity> subStyleBonus,
            List<SlotEntity> slots,
            string defaultPageName,
            int defaultSubStyle,
            List<int> defaultPerks,
            List<int> defaultPerksWhenSplashed,
            List<DefaultStatModsPerSubStyleEntity> defaultStatModsPerSubStyle)
        {
            Id = id;
            Name = name;
            Tooltip = tooltip;
            IconPath = iconPath;
            AssetMap = assetMap;
            IsAdvanced = isAdvanced;
            AllowedSubStyles = allowedSubStyles;
            SubStyleBonus = subStyleBonus;
            Slots = slots;
            DefaultPageName = defaultPageName;
            DefaultSubStyle = defaultSubStyle;
            DefaultPerks = defaultPerks;
            DefaultPerksWhenSplashed = defaultPerksWhenSplashed;
            DefaultStatModsPerSubStyle = defaultStatModsPerSubStyle;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Tooltip { get; private set; }
        public string? IconPath { get => _iconPath; private set => _iconPath = PathManager.GetMappedPath(value); }
        public Dictionary<string, string>? AssetMap
        {
            get => _assetMap;
            private set
            {
                _assetMap = new Dictionary<string, string>();
                foreach (var kvp in value!)
                {
                    _assetMap.Add(kvp.Key, PathManager.GetMappedPath(kvp.Value)!);
                }
            }
        }
        public bool IsAdvanced { get; private set; }
        public List<int> AllowedSubStyles { get; private set; }
        public List<SubStyleBonusEntity> SubStyleBonus { get; private set; }
        public List<SlotEntity> Slots { get; private set; }
        public string DefaultPageName { get; private set; }
        public int DefaultSubStyle { get; private set; }
        public List<int> DefaultPerks { get; private set; }
        public List<int> DefaultPerksWhenSplashed { get; private set; }
        public List<DefaultStatModsPerSubStyleEntity> DefaultStatModsPerSubStyle { get; private set; }

        [JsonIgnore]
        public string? IconUrl { get => PathManager.GetCDragonUrl(_iconPath); }
        [JsonIgnore]
        public Dictionary<string, string>? AssetMapUrl
        {
            get
            {
                if (_assetMap == null)
                {
                    return null;
                }
                var assetMapUrl = new Dictionary<string, string>();
                foreach (var kvp in _assetMap)
                {
                    assetMapUrl.Add(kvp.Key, PathManager.GetCDragonUrl(kvp.Value)!);
                }
                return assetMapUrl;
            }
        }
    }
}
