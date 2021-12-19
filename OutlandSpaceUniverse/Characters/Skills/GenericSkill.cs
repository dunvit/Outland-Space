namespace Universe.Characters.Skills
{
    public class GenericSkill: ISkill
    {
        public SkillType Label { get; set; }
        public double Value { get; set; }

        public GenericSkill(SkillType label, double value)
        {
            Label = label;
            Value = value;
        }
    }
}