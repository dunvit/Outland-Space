using System;
using EngineCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OutlandSpace.Engine
{
    [TestClass()]
    public class LocalGameServerBaseTests
    {
        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException), "")]
        public void RefreshGameSessionTest()
        {
            var server = new LocalGameServer();

            server.RefreshGameSession(1);
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException), "")]
        public void ResumeSessionTest()
        {
            var server = new LocalGameServer();

            server.RefreshGameSession(1);
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException), "")]
        public void PauseSessionTest()
        {
            var server = new LocalGameServer();

            server.RefreshGameSession(1);
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException), "")]
        public void CommandTest()
        {
            var server = new LocalGameServer();

            server.RefreshGameSession(1);
        }
    }
}