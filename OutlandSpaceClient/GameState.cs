using OutlandSpaceClient.UI.Model;
using OutlandSpaceCommon;
using Universe.Session;

namespace OutlandSpaceClient
{
    public class GameState
    {
        public IScreenInfo ScreenInfo;

        public EngineSettings Settings = new EngineSettings();

        public IGameSessionData GameSession;

        public GameState()
        {
            ScreenInfo = new ScreenParameters(1920, 1080, 10000, 10000);
        }
    }
}