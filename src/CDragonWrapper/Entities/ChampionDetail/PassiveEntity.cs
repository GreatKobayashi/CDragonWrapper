using CDragonWrapper.Logics;
using System.Text.Json.Serialization;

namespace CDragonWrapper.Entities.ChampionDetail
{
    public class PassiveEntity
    {
        private string? _abilityIconPath;
        private string? _abilityVideoPath;
        private string? _abilityVideoImagePath;

        public PassiveEntity(string name, string abilityIconPath, string abilityVideoPath, string abilityVideoImagePath, string description)
        {
            Name = name;
            AbilityIconPath = abilityIconPath;
            AbilityVideoPath = abilityVideoPath;
            AbilityVideoImagePath = abilityVideoImagePath;
            Description = description;
        }

        public string Name { get; private set; }
        public string? AbilityIconPath { get => _abilityIconPath; private set => _abilityIconPath = PathManager.GetMappedPath(value); }
        public string? AbilityVideoPath { get => _abilityVideoPath; private set => _abilityVideoPath = PathManager.GetMappedPath(value); }
        public string? AbilityVideoImagePath { get => _abilityVideoImagePath; private set => _abilityVideoImagePath = PathManager.GetMappedPath(value); }
        public string Description { get; private set; }

        [JsonIgnore]
        public string? AbilityIconUrl { get => PathManager.GetCDragonUrl(_abilityIconPath); }
        [JsonIgnore]
        public string? AbilityVideoUrl { get => PathManager.GetCloudUrl(_abilityVideoPath); }
        [JsonIgnore]
        public string? AbilityVideoImageUrl { get => PathManager.GetCloudUrl(_abilityVideoImagePath); }
    }
}
