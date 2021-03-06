using Engine;
using NUnit.Framework;
using Universe.Objects;
using Universe.Objects.Points;

namespace OutlandSpaceEngine.Tests.Generation
{
    [TestFixture]
    public class RandomFactoryTests
    {
        [Test]
        public void GenerateBaseSpaceship()
        {
            const double centerMap = 1000;
            const int radiusMap = 500;

            var asteroids = Tools.Random.GenerateSmallAsteroids(20, new SpacePoint(centerMap, centerMap), radiusMap);

            Assert.That(asteroids.Count, Is.EqualTo(20));

            var asteroid = asteroids[2];

            Assert.That(asteroid.Direction, Is.InRange(0, 360));
            Assert.That(asteroid.Id, Is.InRange(1000000000, 2147483647));
            Assert.That(asteroid.Type, Is.EqualTo(CelestialObjectTypes.Asteroid));
            Assert.That(asteroid.IsNameCorrect, Is.EqualTo(true));
            Assert.That(asteroid.PositionX, Is.InRange(centerMap - radiusMap, centerMap + radiusMap));
            Assert.That(asteroid.Speed, Is.InRange(0, 70));
        }
    }
}