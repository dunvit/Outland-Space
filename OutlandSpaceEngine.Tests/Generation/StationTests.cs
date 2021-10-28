using Engine.Generation;
using NUnit.Framework;
using Universe.Objects;
using Universe.Objects.Points;

namespace OutlandSpaceEngine.Tests.Generation
{
    [TestFixture]
    public class StationTests
    {
        [Test]
        public void GenerateStation()
        {
            const double centerMap = 1000;
            const int radiusMap = 500;

            var station = StationFactory.Generate(new SpacePoint(centerMap, centerMap), radiusMap);

            Assert.That(station.Direction, Is.InRange(0, 360));
            Assert.That(station.Id, Is.InRange(1000000000, 2147483647));
            Assert.That(station.Type, Is.EqualTo(CelestialObjectTypes.Station));
            Assert.That(station.IsNameCorrect, Is.EqualTo(true));
            Assert.That(station.PositionX, Is.InRange(centerMap - radiusMap, centerMap + radiusMap));
            Assert.That(station.PositionY, Is.InRange(centerMap - radiusMap, centerMap + radiusMap));
            Assert.That(station.Speed, Is.InRange(0, 2));
            Assert.That(station.Direction, Is.InRange(0, 360));
        }
    }
}
