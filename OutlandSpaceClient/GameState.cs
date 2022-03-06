using System.Linq;
using Engine;
using OutlandSpaceClient.UI.Model;
using OutlandSpaceCommon;
using Universe.Objects;
using Universe.Session;

namespace OutlandSpaceClient
{
    public class GameState : IGameState
    {
        public IScreenInfo ScreenInfo;

        public EngineSettings Settings = new EngineSettings();

        private IGameSessionData _gameSession;

        public GameState()
        {
            ScreenInfo = new ScreenParameters(1920, 1080, 10000, 10000);
        }

        public IGameSessionData GetGameSession()
        {
            return _gameSession;
        }

        public ICelestialObject GetActiveCelestialObject()
        {
            return _gameSession.GetCelestialObjects().FirstOrDefault(o => o.Id == ScreenInfo.ActiveCelestialObjectId);
        }

        public void SetActiveCelestialObject(int id)
        {
            ScreenInfo.ActiveCelestialObjectId = id;
        }

        public void SetSession(IGameSessionData session)
        {
            _gameSession = session;
        }
    }
}