using Universe.Characters.Skills;

namespace Universe.Characters
{
    
    public interface ICharacter
    {
        public string FirstName { get; }

        public string LastName { get; }

        public Gender Gender { get; }

        public int LocationCelestialObject { get; set; }

        public int LocationModuleId { get; set; }

        double GetSkill(SkillType skill);

        void SetSkill(ISkill skill);

        void SetSkill(SkillType skill, double value);
    }
}
