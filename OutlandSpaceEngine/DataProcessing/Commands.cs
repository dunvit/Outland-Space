using log4net;
using OutlandSpaceCommon;
using System.Reflection;

namespace Engine.DataProcessing
{
    public class Commands
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IGameSession Execute(IGameSession gameSession, EngineSettings settings)
        {
            Logger.Debug($"[Turn {gameSession.Turn}] Execute commands.");

            gameSession.ClearCommands();

            return gameSession;
        }
    }
}
