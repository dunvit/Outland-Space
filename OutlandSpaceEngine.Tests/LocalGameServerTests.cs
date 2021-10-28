using System;
using Engine;
using NUnit.Framework;
using Universe;
using Universe.Session;

namespace OutlandSpaceEngine.Tests
{
    [TestFixture]
    public class LocalGameServerTests
    {
        private IGameServer _server;

        [SetUp]
        protected void Init()
        {
            _server = new LocalGameServer();
        }

        [Test]
        public void EmptySessionInitialization()
        {
            IGameSessionData session = _server.SessionInitialization();

            Assert.That(session.Turn, Is.EqualTo(1));
            Assert.That(session.IsPause, Is.True);
            Assert.That(session.IsValid, Is.True);
            Assert.That(session.Id, Is.InRange(1000000000, 2147483647));
            Assert.That(session.ScenarioName, Is.EqualTo("Empty session scenario"));
        }

        [Test]
        public void GetTurn_Negative()
        {
            Assert.Throws<InvalidOperationException>(() => _server.GetTurn(1));
        }

        [Test]
        public void Execute_Positive()
        {
            var session = _server.SessionInitialization(true);
            _server.ResumeSession(session.Id);
            session = _server.Execute(session.Id, 1);

            Assert.That(session.Turn, Is.EqualTo(2));
        }

        [Test]
        public void GetTurn_EmptySessionPositive()
        {
            var session = _server.SessionInitialization();

            Assert.That(session.Turn, Is.EqualTo(1));
        }

        [Test]
        public void RefreshGameSession_Negative()
        {
            Assert.Throws<InvalidOperationException>(() => _server.RefreshGameSession(1));
        }

        [Test]
        public void RefreshGameSession_Positive()
        {
            var session = _server.SessionInitialization();

            Assert.That(_server.RefreshGameSession(session.Id).Turn, Is.EqualTo(1));
            Assert.That(_server.RefreshGameSession(session.Id).Id, Is.EqualTo(session.Id));
        }

        [Test]
        public void ResumeSession_Negative()
        {
            Assert.Throws<InvalidOperationException>(() => _server.ResumeSession(1));
        }

        [Test()]
        public void PauseSession_Negative()
        {
            Assert.Throws<InvalidOperationException>(() => _server.PauseSession(1));
        }

        [Test()]
        public void Command_Negative()
        {
            Assert.Throws<InvalidOperationException>(() => _server.Command(1, ""));
        }
    }
}
