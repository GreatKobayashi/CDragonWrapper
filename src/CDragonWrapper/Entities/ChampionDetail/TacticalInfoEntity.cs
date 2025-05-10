namespace CDragonWrapper.Entities.ChampionDetail
{
    public class TacticalInfoEntity
    {
        public TacticalInfoEntity(int style, int difficulty, string damageType)
        {
            Style = style;
            Difficulty = difficulty;
            DamageType = damageType;
        }

        public int Style { get; private set; }
        public int Difficulty { get; private set; }
        public string DamageType { get; private set; }
    }
}
