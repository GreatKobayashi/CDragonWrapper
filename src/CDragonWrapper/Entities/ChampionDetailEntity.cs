using CDragonWrapper.Entities.ChampionDetail;
using CDragonWrapper.Exceptions;
using CDragonWrapper.Logics;
using CDragonWrapper.Misc;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace CDragonWrapper.Entities
{
    public class ChampionDetailEntity
    {
        private string? _squarePortraitPath;
        private string? _stingerSfxPath;
        private string? _chooseVoPath;
        private string? _banVoPath;

        [JsonConstructor]
        public ChampionDetailEntity(
            int id,
            string name,
            string alias,
            string title,
            string shortBio,
            TacticalInfoEntity tacticalInfo,
            PlaystyleInfoEntity playstyleInfo,
            string squarePortraitPath,
            string stingerSfxPath,
            string chooseVoPath,
            string banVoPath,
            List<string> roles,
            List<SkinEntity> skins,
            PassiveEntity passive,
            List<SpellEntity> spells)
        {
            Id = id;
            Name = name;
            Alias = alias;
            Title = title;
            ShortBio = shortBio;
            TacticalInfo = tacticalInfo;
            PlaystyleInfo = playstyleInfo;
            SquarePortraitPath = squarePortraitPath;
            StingerSfxPath = stingerSfxPath;
            ChooseVoPath = chooseVoPath;
            BanVoPath = banVoPath;
            Roles = roles;
            Skins = skins;
            Passive = passive;
            Spells = spells;
        }

        public ChampionDetailEntity(int championId, string version = "latest", Language language = Language.DEFAULT)
        {
            var detail = Client.Http.GetFromJsonAsync<ChampionDetailEntity>(
                UrlManager.GameData.GetUrl(version, language, championId.ToString(), "champions")).Result;

            if (detail == null)
            {
                throw new CDragonException("Unexpected error.");
            }

            foreach (var prop in typeof(ChampionDetailEntity).GetProperties())
            {
                if (prop.CanRead && prop.CanWrite)
                {
                    prop.SetValue(this, prop.GetValue(detail));
                }
            }
        }

        public int Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string Alias { get; private set; } = null!;
        public string Title { get; private set; } = null!;
        public string ShortBio { get; private set; } = null!;
        public TacticalInfoEntity TacticalInfo { get; private set; } = null!;
        public PlaystyleInfoEntity PlaystyleInfo { get; private set; } = null!;
        public string? SquarePortraitPath { get => _squarePortraitPath; private set => _squarePortraitPath = PathManager.GetMappedPath(value); }
        public string? StingerSfxPath { get => _stingerSfxPath; private set => _stingerSfxPath = PathManager.GetMappedPath(value); }
        public string? ChooseVoPath { get => _chooseVoPath; private set => _chooseVoPath = PathManager.GetMappedPath(value); }
        public string? BanVoPath { get => _banVoPath; private set => _banVoPath = PathManager.GetMappedPath(value); }
        public List<string> Roles { get; private set; } = null!;
        public List<SkinEntity> Skins { get; private set; } = null!;
        public PassiveEntity Passive { get; private set; } = null!;
        public List<SpellEntity> Spells { get; private set; } = null!;

        [JsonIgnore]
        public string? SquarePortraitUrl { get => PathManager.GetCDragonUrl(_squarePortraitPath); }
        [JsonIgnore]
        public string? StingerSfxUrl { get => PathManager.GetCDragonUrl(_stingerSfxPath); }
        [JsonIgnore]
        public string? ChooseVoUrl { get => PathManager.GetCDragonUrl(_chooseVoPath); }
        [JsonIgnore]
        public string? BanVoUrl { get => PathManager.GetCDragonUrl(_banVoPath); }
    }
}
