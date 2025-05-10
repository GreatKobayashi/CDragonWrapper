namespace CDragonWrapper.Entities
{
    public class QueueEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string ShortName { get; private set; }
        public string Description { get; private set; }
        public string DetailedDescription { get; private set; }
        public string GameSelectModeGroup { get; private set; }
        public string GameSelectCategory { get; private set; }
        public int GameSelectPriority { get; private set; }
        public bool IsSkillTreeQueue { get; private set; }

        public QueueEntity(
            int id,
            string name,
            string shortName,
            string description,
            string detailedDescription,
            string gameSelectModeGroup,
            string gameSelectCategory,
            int gameSelectPriority,
            bool isSkillTreeQueue)
        {
            Id = id;
            Name = name;
            ShortName = shortName;
            Description = description;
            DetailedDescription = detailedDescription;
            GameSelectModeGroup = gameSelectModeGroup;
            GameSelectCategory = gameSelectCategory;
            GameSelectPriority = gameSelectPriority;
            IsSkillTreeQueue = isSkillTreeQueue;
        }
    }
}
