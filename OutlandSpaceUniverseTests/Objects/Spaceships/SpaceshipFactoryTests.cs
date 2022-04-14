using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.Objects;
using Universe.Objects.Spaceships;

namespace OutlandSpaceUniverseTests.Objects.Spaceships
{
    [TestClass()]
    public class SpaceshipFactoryTests
    {
        [TestMethod()]
        public void GenerateFuryClassSpaceshipWithCrewTest()
        {
            // Arrange

            var expectedIsSpaceshipDestroyed = false;

            // Act

            var celestialObject = SpaceshipFactory.GenerateFuryClassSpaceshipWithCrew();

            var spaceship = celestialObject.ToSpaceship();

            // Assert

            Assert.AreEqual(expectedIsSpaceshipDestroyed, spaceship.IsDestroyed);
        }

        [TestMethod()]
        public void GenerateFuryClassSpaceshipTest()
        {
            // Arrange

            var expectedIsSpaceshipDestroyed = false;

            // Act

            var celestialObject = SpaceshipFactory.GenerateFuryClassSpaceship();

            var spaceship = celestialObject.ToSpaceship();

            // Assert

            Assert.AreEqual(expectedIsSpaceshipDestroyed, spaceship.IsDestroyed);
        }
    }
}