using CDragonWrapper.Logics;
using System.Text.Json.Serialization;

namespace CDragonWrapper.Entities
{
    public class PerkEntity
    {
        private string? _iconPath;

        public PerkEntity(
            int id,
            string name,
            string majorChangePatchVersion,
            string tooltip,
            string shortDesc,
            string longDesc,
            string recommendationDescriptor,
            string iconPath,
            List<string> endOfGameStatDescs,
            Dictionary<string, int> recommendationDescriptorAttributes
        )
        {
            Id = id;
            Name = name;
            MajorChangePatchVersion = majorChangePatchVersion;
            Tooltip = tooltip;
            ShortDesc = shortDesc;
            LongDesc = longDesc;
            RecommendationDescriptor = recommendationDescriptor;
            IconPath = iconPath;
            EndOfGameStatDescs = endOfGameStatDescs;
            RecommendationDescriptorAttributes = recommendationDescriptorAttributes;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string MajorChangePatchVersion { get; private set; }
        public string Tooltip { get; private set; }
        public string ShortDesc { get; private set; }
        public string LongDesc { get; private set; }
        public string RecommendationDescriptor { get; private set; }
        public string? IconPath { get => _iconPath; private set => _iconPath = PathManager.GetMappedPath(value); }
        public List<string> EndOfGameStatDescs { get; private set; }
        public Dictionary<string, int> RecommendationDescriptorAttributes { get; private set; }

        [JsonIgnore]
        public string? IconUrl { get => PathManager.GetCDragonUrl(_iconPath); }
    }
}
