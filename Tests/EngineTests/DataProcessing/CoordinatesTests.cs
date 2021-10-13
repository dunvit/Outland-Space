using System.Linq;
using Engine;
using Engine.DataProcessing;
using NUnit.Framework;
using OutlandSpaceCommon;
using Universe.Geometry;
using Universe.Objects;
using Universe.Objects.Points;

namespace Tests.EngineTests.DataProcessing
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
        public void CalculateGeneralObjectLocationTest()
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

            var atomicSecondTurnLocation = resultSession.GetCelestialObject(smallAsteroid.Id).AtomicLocation;

            Assert.That(atomicSecondTurnLocation.Count, Is.EqualTo(21));

            var atomicInitialStepLocation = resultSession.GetTurnLocation(smallAsteroid.Id, 0);
            var atomicFirstStepLocation = resultSession.GetTurnLocation(smallAsteroid.Id, 1);
            var atomicSecondStepLocation = resultSession.GetTurnLocation(smallAsteroid.Id, 2);
            var atomicFinishStepLocation = resultSession.GetTurnLocation(smallAsteroid.Id, 20);

            Assert.That(atomicInitialStepLocation.IsEqualTo(new Point(1020, 2000)));
            Assert.That(atomicFirstStepLocation.IsEqualTo(new Point(1020.5, 2000)));
            Assert.That(atomicSecondStepLocation.IsEqualTo(new Point(1021, 2000)));
            Assert.That(atomicFinishStepLocation.IsEqualTo(new Point(1030, 2000)));

            var resultSessionThirdTurn = dataProcess.Recalculate(session, new EngineSettings());

            var atomicThirdTurnLocation = resultSessionThirdTurn.GetCelestialObject(smallAsteroid.Id).AtomicLocation;

            Assert.That(atomicThirdTurnLocation.Count, Is.EqualTo(21));

            var atomicInitialStepThirdTurnLocation = resultSessionThirdTurn.GetTurnLocation(smallAsteroid.Id, 0);
            var atomicFirstStepThirdTurnLocation = resultSessionThirdTurn.GetTurnLocation(smallAsteroid.Id, 1);
            var atomicSecondStepThirdTurnLocation = resultSessionThirdTurn.GetTurnLocation(smallAsteroid.Id, 2);
            var atomicFinishStepThirdTurnLocation = resultSessionThirdTurn.GetTurnLocation(smallAsteroid.Id, 20);

            Assert.That(atomicInitialStepThirdTurnLocation.IsEqualTo(new Point(1030, 2000)));
            Assert.That(atomicFirstStepThirdTurnLocation.IsEqualTo(new Point(1030.5, 2000)));
            Assert.That(atomicSecondStepThirdTurnLocation.IsEqualTo(new Point(1031, 2000)));
            Assert.That(atomicFinishStepThirdTurnLocation.IsEqualTo(new Point(1040, 2000)));
        }
    }
}
