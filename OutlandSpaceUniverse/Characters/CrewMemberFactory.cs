using System;
using System.ComponentModel;
using OutlandSpaceCommon;
using RandomNameGeneratorLibrary;

namespace Universe.Characters
{
    public class CrewMemberFactory
    {
        public static ICharacter GenerateRandomCrewMemberWithoutSkills(int celestialObjectId = 0,int moduleId = 0)
        {
            var gender = GetRandomGender();

            var name = GetFirstAndLastName(GetRandomGender()).Split(' ');

            var character = new CrewMember(name[0], name[1], gender)
            {
                LocationCelestialObject = celestialObjectId,
                LocationModuleId = moduleId
            };

            return character;
        }

        public static string GetFirstAndLastName(Gender gender) => gender switch
        {
            Gender.Male => new PersonNameGenerator().GenerateRandomMaleFirstAndLastName(),
            Gender.Female => new PersonNameGenerator().GenerateRandomFemaleFirstAndLastName(),
            _ => throw new InvalidEnumArgumentException()
        };

        public static Gender GetRandomGender() => RandomGenerator.GetInteger(1, 3) switch
        {
            1 => Gender.Male,
            2 => Gender.Female,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
