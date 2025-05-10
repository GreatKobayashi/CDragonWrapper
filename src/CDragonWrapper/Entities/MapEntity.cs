namespace CDragonWrapper.Entities
{
    public class MapEntity
    {
        public MapEntity(int id, string name, string description, string mapStringId)
        {
            Id = id;
            Name = name;
            Description = description;
            MapStringId = mapStringId;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string MapStringId { get; private set; }
    }
}
