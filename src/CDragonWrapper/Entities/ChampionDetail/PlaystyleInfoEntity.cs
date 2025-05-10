namespace CDragonWrapper.Entities.ChampionDetail
{
    public class PlaystyleInfoEntity
    {
        public PlaystyleInfoEntity(int damage, int durability, int crowdControl, int mobility, int utility)
        {
            Damage = damage;
            Durability = durability;
            CrowdControl = crowdControl;
            Mobility = mobility;
            Utility = utility;
        }

        public int Damage { private get; set; }
        public int Durability { private get; set; }
        public int CrowdControl { private get; set; }
        public int Mobility { private get; set; }
        public int Utility { private get; set; }
    }
}
