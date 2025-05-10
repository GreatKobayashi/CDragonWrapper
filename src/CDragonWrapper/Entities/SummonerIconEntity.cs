using CDragonWrapper.Logics;
using System.Text.Json.Serialization;

namespace CDragonWrapper.Entities
{
    public class SummonerIconEntity
    {
        private string? _imagePath;

        public SummonerIconEntity(
            int id,
            string title,
            int yearReleased,
            bool isLegacy,
            string imagePath,
            string region,
            string description,
            int rarity,
            List<string> disabledRegions)
        {
            Id = id;
            Title = title;
            YearReleased = yearReleased;
            IsLegacy = isLegacy;
            ImagePath = imagePath;
            Region = region;
            Description = description;
            Rarity = rarity;
            DisabledRegions = disabledRegions ?? new List<string>();
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public int YearReleased { get; private set; }
        public bool IsLegacy { get; private set; }
        public string? ImagePath { get => _imagePath; private set => _imagePath = PathManager.GetMappedPath(value); }
        public string Region { get; private set; }
        public string Description { get; private set; }
        public int Rarity { get; private set; }
        public List<string> DisabledRegions { get; private set; }

        [JsonIgnore]
        public string? ImageUrl { get => PathManager.GetCDragonUrl(_imagePath); }
    }
}
