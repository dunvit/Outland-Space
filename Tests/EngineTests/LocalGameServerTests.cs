using System;
using Engine;
using NUnit.Framework;

namespace Tests.EngineTests
{
    [TestFixture]
    public class LocalGameServerTests
    {
        private LocalGameServer _server;

        [SetUp]
        protected void Init()
        {
            _server = new LocalGameServer();
        }

        [Test]
        public void RefreshGameSessionTest()
        {
            Assert.Throws<NotImplementedException>(() => _server.RefreshGameSession(1));
        }

        [Test]
        public void ResumeSessionTest()
        {
            Assert.Throws<NotImplementedException>(() => _server.ResumeSession(1));
        }

        [Test()]
        public void PauseSessionTest()
        {
            Assert.Throws<NotImplementedException>(() => _server.PauseSession(1));
        }

        [Test()]
        public void CommandTest()
        {
            Assert.Throws<NotImplementedException>(() => _server.Command(1, ""));
        }
    }
}
