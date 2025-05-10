namespace CDragonWrapper.Entities.ChampionDetail.Skin.Chroma
{
    public class DescriptionEntity
    {
        public DescriptionEntity(string region, string description)
        {
            Region = region;
            Description = description;
        }

        public string Region { get; private set; }
        public string Description { get; private set; }
    }
}
