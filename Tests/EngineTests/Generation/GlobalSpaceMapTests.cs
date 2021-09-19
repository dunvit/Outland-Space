using Engine;
using Engine.Generation;
using NUnit.Framework;
using Universe.Objects.Points;

namespace Tests.EngineTests.Generation
{
    [TestFixture]
    public class GlobalSpaceMapTests
    {
        [Test]
        public void GenerateEmptySpaceMapTest()
        {
            var spaceMap = GlobalSpaceMap.GenerateEmpty();

            Assert.That(spaceMap.GetCelestialObjects().Count, Is.EqualTo(1));
        }

        [Test]
        public void GenerateEmptySpaceMapWithCelestialObjectsTest()
        {
            var spaceMap = GlobalSpaceMap.GenerateEmpty();

            Assert.That(spaceMap.GetCelestialObjects().Count, Is.EqualTo(1));

            const double centerMap = 1000;
            const int radiusMap = 500;

            var asteroids = Tools.Random.GenerateSmallAsteroids(20, new SpacePoint(centerMap, centerMap), radiusMap);

            spaceMap.Add(asteroids[0]);

            Assert.That(spaceMap.GetCelestialObjects().Count, Is.EqualTo(2));

            asteroids = Tools.Random.GenerateSmallAsteroids(110, new SpacePoint(centerMap, centerMap), radiusMap);

            spaceMap.Add(asteroids);

            Assert.That(spaceMap.GetCelestialObjects().Count, Is.EqualTo(112));

            var stations = Tools.Random.GenerateStations(4, new SpacePoint(centerMap, centerMap), radiusMap);

            spaceMap.Add(stations);

            Assert.That(spaceMap.GetCelestialObjects().Count, Is.EqualTo(116));
        }
    }
}
