using System;
using Engine;
using NUnit.Framework;
using Universe;
using Universe.Objects.Points;

namespace Tests.EngineTests.TurnCalculator
{
    [TestFixture]
    public class BaseExecuteTests
    {
        private IGameServer _server;

        [SetUp]
        protected void Init()
        {
            _server = new LocalGameServer();
        }

        [Test]
        [TestCase(0)]
        [TestCase(-100)]
        public void NotValidSessionTest(int value)
        {
            ITurnCalculator server = new Engine.TurnCalculator();

            Assert.That(server.Execute(new GameSession(), value).IsValid, Is.False);
        }

        [Test]
        [TestCase(1)]
        [TestCase(100)]
        public void ValidSessionTest(int value)
        {
            ITurnCalculator server = new Engine.TurnCalculator();

            Assert.That(server.Execute(new GameSession(), value).IsValid, Is.True);
        }

        [Test]
        public void RefreshGameSessionTest()
        {
            ITurnCalculator server = new Engine.TurnCalculator();

            var session = server.Execute(new GameSession(), 1);

            Assert.That(session.IsValid, Is.True);
        }

        [Test]
        public void BasicExecuteTest()
        {
            const double centerMap = 1000;
            const int radiusMap = 500;

            ITurnCalculator server = new Engine.TurnCalculator();

            var session = SessionFactory.ProduceSession();

            session.AddCelestialObject(Tools.Random.GenerateSmallAsteroid(new SpacePoint(centerMap, centerMap), radiusMap));

            Assert.That(session.Turn, Is.EqualTo(1));
            Assert.That(session.IsPause, Is.True);
            Assert.That(session.IsValid, Is.True);
            Assert.That(session.Id, Is.InRange(1000000000, 2147483647));
            Assert.That(session.ScenarioName, Is.EqualTo("Empty session scenario"));
            Assert.That(session.GetCelestialObjects().Count, Is.EqualTo(1));

            var session1 = server.Execute(session, 1);

            Assert.That(session1.IsValid, Is.True);
        }
    }
}