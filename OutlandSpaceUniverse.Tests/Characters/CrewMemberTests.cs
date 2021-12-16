using System;
using System.Collections.Generic;
using System.Text;
using Engine.Generation;
using NUnit.Framework;
using Universe.Characters;

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

            var member = CrewMemberFactory.GenerateRandomCrewMemberWithoutSkills();

            // Assert
            Assert.That(string.IsNullOrEmpty(member.FirstName) == false);
            Assert.That(string.IsNullOrEmpty(member.LastName) == false);
            Assert.That(member.Gender == Gender.Male || member.Gender == Gender.Female);
        }
    }
}
