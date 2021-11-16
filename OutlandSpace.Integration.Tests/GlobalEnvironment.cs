using Engine;
using Engine.Generation;
using Universe;
using Universe.Geometry;

namespace OutlandSpace.Integration.Tests
{
    public class GlobalEnvironment
    {
        public IGameSession Session { get; set; }
        public IGameServer Server { get; set; }
        public TurnCalculator TurnCalculator { get; set; }

        public GlobalEnvironment()
        {
            Server = new LocalGameServer();
            TurnCalculator = new TurnCalculator();

            var spaceMap = GlobalSpaceMap.GenerateEmptyBase();

            Session = new GameSession(spaceMap);

            var asteroid = AsteroidFactory.GenerateSmall(new Point(10100, 10100));
            Session.AddCelestialObject(asteroid);

            Server.SessionInitialization(Session.ToGameSession(), true);
        }
    }
}
