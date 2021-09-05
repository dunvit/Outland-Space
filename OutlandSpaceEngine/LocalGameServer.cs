using System;
using Universe;
using Universe.Session;

namespace EngineCore
{
    public class LocalGameServer: IGameServer
    {
        public SessionDataDto RefreshGameSession(int id)
        {
            throw new NotImplementedException();
        }

        public void ResumeSession(int id)
        {
            throw new NotImplementedException();
        }

        public void PauseSession(int id)
        {
            throw new NotImplementedException();
        }

        public void Command(int sessionId, string command)
        {
            throw new NotImplementedException();
        }
    }
}
