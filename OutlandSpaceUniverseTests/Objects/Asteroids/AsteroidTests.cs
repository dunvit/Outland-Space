using NUnit.Framework;
using Universe.Objects;
using Universe.Objects.Asteroids;

namespace Tests.Universe.Objects.Asteroids
{
    [TestFixture()]
    public class AsteroidTests
    {
        [Test()]
        public void AsteroidTest()
        {
            // Arrange

            var expectedAsteroidType = CelestialObjectTypes.Asteroid;

            // Act

            var asteroid = new Asteroid();

            // Assert

            Assert.AreEqual(expectedAsteroidType, asteroid.Type);
        }
    }
}