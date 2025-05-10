using CDragonWrapper.Exceptions;
using CDragonWrapper.Logics;
using CDragonWrapper.Misc;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace CDragonWrapper.Entities
{
    public class ChanpionEntity
    {
        private string? _squarePortraitPath;
        private string _version = "";
        private Language _language;

        public ChanpionEntity(int id, string name, string alias, string squarePortraitPath, List<string> roles)
        {
            Id = id;
            Name = name;
            Alias = alias;
            SquarePortraitPath = squarePortraitPath;
            Roles = roles;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Alias { get; private set; }
        public string? SquarePortraitPath { get => _squarePortraitPath; private set => _squarePortraitPath = PathManager.GetMappedPath(value); }
        public List<string> Roles { get; private set; }

        [JsonIgnore]
        public string? SquarePortraitUrl { get => PathManager.GetCDragonUrl(_squarePortraitPath); }

        internal void SetMetaValue(string version, Language language)
        {
            _version = version;
            _language = language;
        }

        public async Task<ChampionDetailEntity> GetDetailEntity()
        {
            var detail = await Client.Http.GetFromJsonAsync<ChampionDetailEntity>(
                UrlManager.GameData.GetUrl(_version, _language, Id.ToString(), "champions"));

            if (detail == null)
            {
                throw new CDragonException("Unexpected error.");
            }

            return detail;
        }
    }
}
