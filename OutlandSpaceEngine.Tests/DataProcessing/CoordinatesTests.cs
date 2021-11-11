using System.Linq;
using Engine;
using Engine.DataProcessing;
using Engine.Sessions;
using NUnit.Framework;
using OutlandSpaceCommon;
using Universe.Objects;
using Universe.Objects.Points;

namespace OutlandSpaceEngine.Tests.DataProcessing
{
    [TestFixture]
    public class CoordinatesTests
    {
        private IGameSession session;
        private const double CenterMap = 1000;
        private const int RadiusMap = 500;

        [SetUp]
        protected void Init()
        {
            session = SessionFactory.ProduceSession();

            session.GenerateEmptySpaceMap();
        }

        [Test]
        public void CalculateGeneralObjectLocation()
        {
            var smallAsteroid = Tools.Random.GenerateSmallAsteroid(new SpacePoint(CenterMap, RadiusMap), RadiusMap);

            smallAsteroid.PositionX = 1000;
            smallAsteroid.PositionY = 2000;
            smallAsteroid.Direction = 90;
            smallAsteroid.Speed = 10;

            session.AddCelestialObject(smallAsteroid.DeepClone());

            var asteroids = session.GetCelestialObjects().Where(x => x.Type == CelestialObjectTypes.Asteroid).ToList();
            Assert.That(asteroids.Count, Is.EqualTo(1));

            var dataProcess = new Coordinates();

            var resultSession = dataProcess.Recalculate(session, new EngineSettings());

            Assert.That(resultSession.GetCelestialObject(smallAsteroid.Id).PreviousPositionX, Is.EqualTo(smallAsteroid.PositionX));
            Assert.That(resultSession.GetCelestialObject(smallAsteroid.Id).PreviousPositionY, Is.EqualTo(smallAsteroid.PositionY));

            Assert.That(resultSession.GetCelestialObject(smallAsteroid.Id).PositionX, Is.EqualTo(1010));
            Assert.That(resultSession.GetCelestialObject(smallAsteroid.Id).PositionY, Is.EqualTo(2000));

            resultSession = dataProcess.Recalculate(session, new EngineSettings());

            Assert.That(resultSession.GetCelestialObject(smallAsteroid.Id).PositionX, Is.EqualTo(1020));
            Assert.That(resultSession.GetCelestialObject(smallAsteroid.Id).PositionY, Is.EqualTo(2000));
        }
    }
}
