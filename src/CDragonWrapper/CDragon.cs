using CDragonWrapper.DataTypes;

namespace CDragonWrapper
{
    public static class CDragon
    {
        public static ChampionJson ChampionJson { get; } = new();
        public static ChampionImage ChampionImage { get; } = new();
        public static ItemJson ItemJson { get; } = new();
        public static ItemImage ItemImage { get; } = new();
        public static SummonerSpellJson SummonerSpellJson { get; } = new();
        public static SummonerSpellImage SummonerSpellImage { get; } = new();
    }
}
