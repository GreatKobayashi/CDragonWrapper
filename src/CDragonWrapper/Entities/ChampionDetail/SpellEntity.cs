using CDragonWrapper.Entities.ChampionDetail.Spell;
using CDragonWrapper.Logics;
using System.Text.Json.Serialization;

namespace CDragonWrapper.Entities.ChampionDetail
{
    public class SpellEntity
    {
        private string? _abilityIconPath;
        private string? _abilityVideoPath;
        private string? _abilityVideoImagePath;

        public SpellEntity(
            string spellKey,
            string name,
            string abilityIconPath,
            string abilityVideoPath,
            string abilityVideoImagePath,
            string cost,
            string cooldown,
            string description,
            string dynamicDescription,
            List<double> range,
            List<double> costCoefficients,
            List<double> cooldownCoefficients,
            Dictionary<string, double> coefficients,
            AmmoEntity ammo)
        {
            SpellKey = spellKey;
            Name = name;
            AbilityIconPath = abilityIconPath;
            AbilityVideoPath = abilityVideoPath;
            AbilityVideoImagePath = abilityVideoImagePath;
            Cost = cost;
            Cooldown = cooldown;
            Description = description;
            DynamicDescription = dynamicDescription;
            Range = range;
            CostCoefficients = costCoefficients;
            CooldownCoefficients = cooldownCoefficients;
            Coefficients = coefficients;
            Ammo = ammo;
        }

        public string SpellKey { get; private set; }
        public string Name { get; private set; }
        public string? AbilityIconPath { get => _abilityIconPath; private set => _abilityIconPath = PathManager.GetMappedPath(value); }
        public string? AbilityVideoPath { get => _abilityVideoPath; private set => _abilityVideoPath = PathManager.GetMappedPath(value); }
        public string? AbilityVideoImagePath { get => _abilityVideoImagePath; private set => _abilityVideoImagePath = PathManager.GetMappedPath(value); }
        /// <summary>
        /// Idk how to resolve.
        /// </summary>
        public string Cost { get; private set; }
        /// <summary>
        /// Idk how to resolve.
        /// </summary>
        public string Cooldown { get; private set; }
        public string Description { get; private set; }
        /// <summary>
        /// You can resolve some variable using Damage Simulator. link:
        /// </summary>
        public string DynamicDescription { get; private set; }
        /// <summary>
        /// Six values are stored for all champions to match the champions whose skill level can be raised to six.
        /// The sixth value is not used for champions with skill levels up to 5.
        /// </summary>
        public List<double> Range { get; private set; }
        /// <summary>
        /// Six values are stored for all champions to match the champions whose skill level can be raised to six.
        /// The sixth value is not used for champions with skill levels up to 5.
        /// </summary>
        public List<double> CostCoefficients { get; private set; }
        /// <summary>
        /// Six values are stored for all champions to match the champions whose skill level can be raised to six.
        /// The sixth value is not used for champions with skill levels up to 5.
        /// </summary>
        public List<double> CooldownCoefficients { get; private set; }
        public Dictionary<string, double> Coefficients { get; private set; }
        /// <summary>
        /// For Gangplank's E, Corki's R ..
        /// </summary>
        public AmmoEntity Ammo { get; private set; }

        [JsonIgnore]
        public string? AbilityIconUrl { get => PathManager.GetCDragonUrl(_abilityIconPath); }
        [JsonIgnore]
        public string? AbilityVideoUrl { get => PathManager.GetCloudUrl(_abilityVideoPath); }
        [JsonIgnore]
        public string? AbilityVideoImageUrl { get => PathManager.GetCloudUrl(_abilityVideoImagePath); }
    }
}
