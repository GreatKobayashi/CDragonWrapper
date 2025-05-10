using CDragonWrapper.Entities.ChampionDetail.Skin;
using CDragonWrapper.Logics;
using System.Text.Json.Serialization;

namespace CDragonWrapper.Entities.ChampionDetail
{
    public class SkinEntity
    {
        private string? _splashPath;
        private string? _uncenteredSplashPath;
        private string? _tilePath;
        private string? _loadScreenPath;
        private string? _splashVideoPath;
        private string? _collectionSplashVideoPath;
        private string? _collectionCardHoverVideoPath;
        private string? _chromaPath;
        private string? _rarityGemPath;

        public SkinEntity(
            int id,
            bool isBase,
            string name,
            string splashPath,
            string uncenteredSplashPath,
            string tilePath,
            string loadScreenPath,
            string skinType,
            string rarity,
            bool isLegacy,
            string splashVideoPath,
            string collectionSplashVideoPath,
            string collectionCardHoverVideoPath,
            string featuresText,
            string chromaPath,
            List<ChromaEntity> chromas,
            string emblems,
            int regionRarityId,
            string rarityGemPath,
            List<SkinLineEntity> skinLines,
            string description)
        {
            Id = id;
            IsBase = isBase;
            Name = name;
            SplashPath = splashPath;
            UncenteredSplashPath = uncenteredSplashPath;
            TilePath = tilePath;
            LoadScreenPath = loadScreenPath;
            SkinType = skinType;
            Rarity = rarity;
            IsLegacy = isLegacy;
            SplashVideoPath = splashVideoPath;
            CollectionSplashVideoPath = collectionSplashVideoPath;
            CollectionCardHoverVideoPath = collectionCardHoverVideoPath;
            FeaturesText = featuresText;
            ChromaPath = chromaPath;
            Chromas = chromas;
            Emblems = emblems;
            RegionRarityId = regionRarityId;
            RarityGemPath = rarityGemPath;
            SkinLines = skinLines;
            Description = description;
        }

        public int Id { get; private set; }
        public bool IsBase { get; private set; }
        public string Name { get; private set; }
        public string? SplashPath { get => _splashPath; private set => _splashPath = PathManager.GetMappedPath(value); }
        public string? UncenteredSplashPath { get => _uncenteredSplashPath; private set => _uncenteredSplashPath = PathManager.GetMappedPath(value); }
        public string? TilePath { get => _tilePath; private set => _tilePath = PathManager.GetMappedPath(value); }
        public string? LoadScreenPath { get => _loadScreenPath; private set => _loadScreenPath = PathManager.GetMappedPath(value); }
        public string SkinType { get; private set; }
        public string Rarity { get; private set; }
        public bool IsLegacy { get; private set; }
        public string? SplashVideoPath { get => _splashVideoPath; private set => _splashVideoPath = PathManager.GetMappedPath(value); }
        public string? CollectionSplashVideoPath { get => _collectionSplashVideoPath; private set => _collectionSplashVideoPath = PathManager.GetMappedPath(value); }
        public string? CollectionCardHoverVideoPath { get => _collectionCardHoverVideoPath; private set => _collectionCardHoverVideoPath = PathManager.GetMappedPath(value); }
        public string FeaturesText { get; private set; }
        public string? ChromaPath { get => _chromaPath; private set => _chromaPath = PathManager.GetMappedPath(value); }
        public List<ChromaEntity> Chromas { get; private set; }
        public string Emblems { get; private set; }
        public int RegionRarityId { get; private set; }
        public string? RarityGemPath { get => _rarityGemPath; private set => _rarityGemPath = PathManager.GetMappedPath(value); }
        public List<SkinLineEntity> SkinLines { get; private set; }
        public string Description { get; private set; }

        [JsonIgnore]
        public string? SplashUrl { get => PathManager.GetCDragonUrl(_splashPath); }
        [JsonIgnore]
        public string? UncenteredSplashUrl { get => PathManager.GetCDragonUrl(_splashPath); }
        [JsonIgnore]
        public string? TileUrl { get => PathManager.GetCDragonUrl(_splashPath); }
        [JsonIgnore]
        public string? LoadScreenUrl { get => PathManager.GetCDragonUrl(_splashPath); }
        [JsonIgnore]
        public string? SplashVideoUrl { get => PathManager.GetCDragonUrl(_splashPath); }
        [JsonIgnore]
        public string? CollectionSplashVideoUrl { get => PathManager.GetCDragonUrl(_splashPath); }
        [JsonIgnore]
        public string? CollectionCardHoverVideoUrl { get => PathManager.GetCDragonUrl(_splashPath); }
        [JsonIgnore]
        public string? ChromaUrl { get => PathManager.GetCDragonUrl(_splashPath); }
        [JsonIgnore]
        public string? RarityGemUrl { get => PathManager.GetCDragonUrl(_splashPath); }
    }
}
