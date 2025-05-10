namespace CDragonWrapper.Entities
{
    public class DefaultStatModsPerSubStyleEntity
    {
        public string Id { get; private set; }
        public List<int> Perks { get; private set; }

        public DefaultStatModsPerSubStyleEntity(string id, List<int> perks)
        {
            Id = id;
            Perks = perks;
        }
    }
}
