using System;
using System.Collections.Generic;
using Universe;
using Universe.Session;

namespace Engine
{
    public class LocalGameServer: IGameServer
    {
        private readonly Dictionary<int, SessionDataDto> _sessions = new Dictionary<int, SessionDataDto>();

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

        public int GetTurn(int sessionId)
        {
            throw new NotImplementedException();
        }

        public void SessionInitialization(int sessionId = -1)
        {
            if (sessionId == -1) sessionId = OutlandSpaceCommon.RandomGenerator.GetId();

            _sessions.Add(sessionId, new SessionDataDto());

            throw new NotImplementedException();
        }
    }
}
