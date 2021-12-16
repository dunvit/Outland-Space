using System;
using System.Collections.Generic;
using LanguageExt;
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

            _skills = skills;
        }

        public double GetSkill(SkillType skill)
        {
            throw new NotImplementedException();
        }
    }
}
