using NUnit.Framework;
using Universe.Characters;
using Universe.Characters.Skills;

namespace OutlandSpaceUniverse.Tests.Characters
{
    [TestFixture]
    public class CrewMemberTests
    {
        [Test]
        public void CrewMemberOnCreateShouldBeCorrect()
        {
            // Arrange

            // act

            var member = CrewMemberFactory.GenerateRandomCrewMember();

            // Assert
            Assert.That(string.IsNullOrEmpty(member.FirstName) == false);
            Assert.That(string.IsNullOrEmpty(member.LastName) == false);
            Assert.That(member.Gender == Gender.Male || member.Gender == Gender.Female);
        }

        [Test]
        public void CrewMemberAfterAddSkillItShouldBeInSkills()
        {
            // Arrange
            const double exceptedSkillValue = 20.1;
            const double exceptedMissileLauncherControlValue = 10.1;

            // act

            var member = CrewMemberFactory.GenerateRandomCrewMember();

            member.SetSkill(new GenericSkill(SkillType.EvasionManeuvering, 20.1));
            var skillValue = member.GetSkill(SkillType.EvasionManeuvering);


            member.SetSkill(SkillType.MissileLauncherControl, 10.1);
            var skillMissileLauncherControl = member.GetSkill(SkillType.MissileLauncherControl);

            // Assert
            Assert.AreEqual(exceptedSkillValue, skillValue);
            Assert.AreEqual(exceptedMissileLauncherControlValue, skillMissileLauncherControl);
        }

        [Test]
        public void CrewMemberNotAddedSkillShouldBeZero()
        {
            // Arrange
            const double exceptedSkillValue = 0.0;

            // act

            var member = CrewMemberFactory.GenerateRandomCrewMember();

            member.SetSkill(new GenericSkill(SkillType.EvasionManeuvering, 20.1));

            var skillValue = member.GetSkill(SkillType.MissileLauncherControl);

            // Assert
            Assert.AreEqual(exceptedSkillValue, skillValue);
        }
    }
}
