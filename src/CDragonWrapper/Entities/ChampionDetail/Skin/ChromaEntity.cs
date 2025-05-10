using CDragonWrapper.Entities.ChampionDetail.Skin.Chroma;
using CDragonWrapper.Logics;
using System.Text.Json.Serialization;

namespace CDragonWrapper.Entities.ChampionDetail.Skin
{
    public class ChromaEntity
    {
        private string? _chromaPath;

        public ChromaEntity(
            int id,
            string name,
            string chromaPath,
            List<string> colors,
            List<DescriptionEntity> descriptions,
            List<RarityEntity> rarities)
        {
            Id = id;
            Name = name;
            ChromaPath = chromaPath;
            Colors = colors;
            Descriptions = descriptions;
            Rarities = rarities;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string? ChromaPath { get => _chromaPath; private set => _chromaPath = PathManager.GetMappedPath(value); }
        public List<string> Colors { get; private set; }
        public List<DescriptionEntity> Descriptions { get; private set; }
        public List<RarityEntity> Rarities { get; private set; }

        [JsonIgnore]
        public string? ChromaUrl { get => PathManager.GetCDragonUrl(_chromaPath); }
    }
}
