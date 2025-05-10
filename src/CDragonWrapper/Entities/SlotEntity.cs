namespace CDragonWrapper.Entities
{
    public class SlotEntity
    {
        public SlotEntity(string type, string slotLabel, List<int> perks)
        {
            Type = type;
            SlotLabel = slotLabel;
            Perks = perks;
        }

        public string Type { get; private set; }
        public string SlotLabel { get; private set; }
        public List<int> Perks { get; private set; }
    }
}
