using CDragonWrapper.Logics;
using System.Text.Json.Serialization;

namespace CDragonWrapper.Entities
{
    public class SummonerSpellEntity
    {
        private string? _iconPath;

        public SummonerSpellEntity(long id, string name, string description, int summonerLevel, int cooldown, List<string> gameModes, string iconPath)
        {
            Id = id;
            Name = name;
            Description = description;
            SummonerLevel = summonerLevel;
            Cooldown = cooldown;
            GameModes = gameModes;
            IconPath = iconPath;
        }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int SummonerLevel { get; private set; }
        public int Cooldown { get; private set; }
        public List<string> GameModes { get; private set; }
        public string? IconPath { get => _iconPath; private set => _iconPath = PathManager.GetMappedPath(value); }


        [JsonIgnore]
        public string? IconUrl { get => PathManager.GetCDragonUrl(_iconPath); }
    }
}
