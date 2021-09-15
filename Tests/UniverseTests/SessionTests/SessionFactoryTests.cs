using System.Linq;
using Engine;
using NUnit.Framework;
using Universe.Objects;

namespace Tests.UniverseTests.SessionTests
{
    [TestFixture]
    public class SessionFactoryTests
    {
        [Test]
        public void GenerateEmptySessionTest()
        {
            var session = SessionFactory.ProduceSession();

            Assert.That(session.Turn, Is.EqualTo(1));
            Assert.That(session.IsPause, Is.True);
            Assert.That(session.Id, Is.InRange(1000000000, 2147483647));
            Assert.That(session.ScenarioName, Is.EqualTo("Empty session scenario"));
            Assert.That(session.SpaceMap.GetCelestialObjects().Count, Is.EqualTo(125));

            var playerShips = session.SpaceMap.GetCelestialObjects().Where(x => x.Type == CelestialObjectTypes.SpaceshipPlayer).ToList();
            var asteroids = session.SpaceMap.GetCelestialObjects().Where(x => x.Type == CelestialObjectTypes.Asteroid).ToList();
            var stations = session.SpaceMap.GetCelestialObjects().Where(x => x.Type == CelestialObjectTypes.Station).ToList();

            Assert.That(playerShips.Count, Is.EqualTo(1));
            Assert.That(stations.Count, Is.EqualTo(4));
            Assert.That(asteroids.Count, Is.EqualTo(120));
        }
    }
}