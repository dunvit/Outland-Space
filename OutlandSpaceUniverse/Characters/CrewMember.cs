using System;
using System.Collections.Generic;
using Universe.Characters.Skills;

namespace Universe.Characters
{
    [Serializable]
    public class CrewMember : ICharacter
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public Gender Gender { get; private set; }
        public int LocationCelestialObject { get; set; }
        public int LocationModuleId { get; set; }

        private List<ISkill> _skills;

        public CrewMember(string firstName, string lastName, Gender gender, int celestialObject = 0, int module =0, List<ISkill> skills = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;

            LocationCelestialObject = celestialObject;
            LocationModuleId = module;

            _skills = skills ?? new List<ISkill>();
        }

        public double GetSkill(SkillType skill)
        {
            const double defaultSkillValue = 0.0;

            foreach (var currentSkill in _skills)
            {
                if (currentSkill.Label == skill)
                {
                    return currentSkill.Value;
                }
            }

            return defaultSkillValue;
        }

        public void SetSkill(ISkill skill)
        {
            if (_skills.Contains(skill)) _skills.Remove(skill);

            _skills.Add(skill);
        }

        public void SetSkill(SkillType skill, double value)
        {
            var genericSkill = new GenericSkill(skill, value);

            SetSkill(genericSkill);
        }
        
    }
}
