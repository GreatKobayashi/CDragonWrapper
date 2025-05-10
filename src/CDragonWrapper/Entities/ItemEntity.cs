using CDragonWrapper.Logics;
using System.Text.Json.Serialization;

namespace CDragonWrapper.Entities
{
    public class ItemEntity
    {
        private string? _iconPath;

        public ItemEntity(
            int id,
            string name,
            string description,
            bool active,
            bool inStore,
            List<int> form,
            List<int> to,
            List<string> categories,
            int maxStacks,
            string requiredChampion,
            string requiredAlly,
            string requiredBuffCurrencyName,
            int requiredBuffCurrencyCost,
            int specialRecipe,
            bool isEnchantment,
            int price,
            int priceTotal,
            bool displayInItemSets,
            string iconPath)
        {
            Id = id;
            Name = name;
            Description = description;
            Active = active;
            InStore = inStore;
            Form = form;
            To = to;
            Categories = categories;
            MaxStacks = maxStacks;
            RequiredChampion = requiredChampion;
            RequiredAlly = requiredAlly;
            RequiredBuffCurrencyName = requiredBuffCurrencyName;
            RequiredBuffCurrencyCost = requiredBuffCurrencyCost;
            SpecialRecipe = specialRecipe;
            IsEnchantment = isEnchantment;
            Price = price;
            PriceTotal = priceTotal;
            DisplayInItemSets = displayInItemSets;
            IconPath = iconPath;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public bool InStore { get; private set; }
        public List<int> Form { get; private set; }
        public List<int> To { get; private set; }
        public List<string> Categories { get; private set; }
        public int MaxStacks { get; private set; }
        public string RequiredChampion { get; private set; }
        public string RequiredAlly { get; private set; }
        public string RequiredBuffCurrencyName { get; private set; }
        public int RequiredBuffCurrencyCost { get; private set; }
        public int SpecialRecipe { get; private set; }
        public bool IsEnchantment { get; private set; }
        public int Price { get; private set; }
        public int PriceTotal { get; private set; }
        public bool DisplayInItemSets { get; private set; }
        public string? IconPath { get => _iconPath; private set => _iconPath = PathManager.GetMappedPath(value); }

        [JsonIgnore]
        public string? IconUrl { get => PathManager.GetCDragonUrl(_iconPath); }
    }
}
