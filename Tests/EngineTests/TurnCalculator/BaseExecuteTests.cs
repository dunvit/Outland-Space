using System;
using Engine;
using NUnit.Framework;
using Universe;

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
    }
}