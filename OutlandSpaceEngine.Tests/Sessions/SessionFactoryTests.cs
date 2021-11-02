using System.Linq;
using Engine.Sessions;
using NUnit.Framework;
using Universe.Objects;

namespace OutlandSpaceEngine.Tests.Sessions
{
    [TestFixture]
    public class SessionFactoryTests
    {
        [Test]
        public void GenerateEmptySession()
        {
            var session = SessionFactory.ProduceSession();

            session.GenerateBaseSpaceMap();

            Assert.That(session.Turn, Is.EqualTo(1));
            Assert.That(session.IsPause, Is.True);
            Assert.That(session.IsValid, Is.True);
            Assert.That(session.Id, Is.InRange(1000000000, 2147483647));
            Assert.That(session.ScenarioName, Is.EqualTo("Empty session scenario"));
            Assert.That(session.GetCelestialObjects().Count, Is.EqualTo(125));

            var playerShips = session.GetCelestialObjects().Where(x => x.Type == CelestialObjectTypes.SpaceshipPlayer).ToList();
            var asteroids = session.GetCelestialObjects().Where(x => x.Type == CelestialObjectTypes.Asteroid).ToList();
            var stations = session.GetCelestialObjects().Where(x => x.Type == CelestialObjectTypes.Station).ToList();

            Assert.That(playerShips.Count, Is.EqualTo(1));
            Assert.That(stations.Count, Is.EqualTo(4));
            Assert.That(asteroids.Count, Is.EqualTo(120));
        }

        [Test]
        public void BaseSessionShouldBeGeneratedCorrect()
        {
            var session = SessionFactory.GenerateBaseSession();

            session.GenerateBaseSpaceMap();

            Assert.That(session.Turn, Is.EqualTo(1));
            Assert.That(session.IsPause, Is.True);
            Assert.That(session.IsValid, Is.True);
            Assert.That(session.Id, Is.InRange(1000000000, 2147483647));
            Assert.That(session.ScenarioName, Is.EqualTo("Base session scenario"));
            Assert.That(session.GetCelestialObjects().Count, Is.EqualTo(125));

            var playerShips = session.GetCelestialObjects().Where(x => x.Type == CelestialObjectTypes.SpaceshipPlayer).ToList();
            var asteroids = session.GetCelestialObjects().Where(x => x.Type == CelestialObjectTypes.Asteroid).ToList();
            var stations = session.GetCelestialObjects().Where(x => x.Type == CelestialObjectTypes.Station).ToList();

            Assert.That(playerShips.Count, Is.EqualTo(1));
            Assert.That(stations.Count, Is.EqualTo(4));
            Assert.That(asteroids.Count, Is.EqualTo(120));
        }
    }
}