using Engine;
using Engine.Generation;
using Engine.Sessions;
using NUnit.Framework;
using OutlandSpaceClient;
using Universe;
using Universe.Geometry;

namespace OutlandSpaceEngine.Tests
{
    [TestFixture]
    public class GameStateTests
    {
        [Test]
        public void Execute_Positive()
        {
            var session = SessionFactory.GenerateBaseSession(GlobalSpaceMap.GenerateEmptyBase());
            var asteroid = AsteroidFactory.GenerateSmall(new Point(10100, 10100));
            session.AddCelestialObject(asteroid);

            IGameState gameState = new GameState();

            gameState.SetSession(session.ToGameSession());
            gameState.SetActiveCelestialObject(asteroid.Id);

            var activeObject = gameState.GetActiveCelestialObject();

            Assert.That(activeObject.Id, Is.EqualTo(asteroid.Id));
        }
    }
}