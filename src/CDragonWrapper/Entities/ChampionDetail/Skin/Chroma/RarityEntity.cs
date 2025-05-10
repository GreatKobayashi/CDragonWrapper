namespace CDragonWrapper.Entities.ChampionDetail.Skin.Chroma
{
    public class RarityEntity
    {
        public RarityEntity(string region, int rarity)
        {
            Region = region;
            Rarity = rarity;
        }

        public string Region { get; private set; }
        public int Rarity { get; private set; }
    }
}
