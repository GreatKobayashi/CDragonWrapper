namespace CDragonWrapper.Entities.ChampionDetail.Spell
{
    public class AmmoEntity
    {
        public AmmoEntity(List<double> ammoRechargeTime, List<int> maxAmmo)
        {
            AmmoRechargeTime = ammoRechargeTime;
            MaxAmmo = maxAmmo;
        }

        public List<double> AmmoRechargeTime { get; private set; }
        public List<int> MaxAmmo { get; private set; }
    }
}
