using Engine;
using NUnit.Framework;
using Universe;

namespace OutlandSpace.Integration.Tests
{
    public class SpaceshipSimpleShotTests
    {
        private IGameSession session;
        private IGameServer _server;
        private TurnCalculator _turnCalculator;

        [SetUp]
        protected void Init()
        {
            _server = new LocalGameServer();
            _turnCalculator = new TurnCalculator();
        }

        [Test]
        public void SpaceshipSimpleShotTest()
        {
            // Arround

            var exceptedId = 1000000001;

            // Act

            session = Engine.Sessions.SessionFactory.GenerateBaseSession(Engine.Generation.GlobalSpaceMap.GenerateEmptyBase());

            session = _turnCalculator.Execute(session, 1);

            var spaceship = session.GetPlayerSpaceShip();

            // Assert

            Assert.AreEqual(exceptedId, spaceship.Id);
        }
    }
}