using System;
using System.Collections.Generic;
using Universe;
using Universe.Session;

namespace Engine
{
    public class LocalGameServer: IGameServer
    {
        private readonly Dictionary<int, IGameSession> _sessions = new Dictionary<int, IGameSession>();

        public IGameSessionData RefreshGameSession(int sessionId)
        {
            Validation(sessionId);

            return _sessions[sessionId].Export();
        }

        public void ResumeSession(int sessionId)
        {
            Validation(sessionId);
        }

        public void PauseSession(int sessionId)
        {
            Validation(sessionId);
        }

        public void Command(int sessionId, string command)
        {
            Validation(sessionId);
        }

        public int GetTurn(int sessionId)
        {
            Validation(sessionId);

            return _sessions[sessionId].Turn;
        }

        public IGameSessionData SessionInitialization(int sessionId = -1)
        {
            var session = SessionFactory.ProduceSession(sessionId);

            _sessions.Add(session.Id, session);

            return session;
        }

        public IGameSessionData Execute(int sessionId, int turns)
        {
            Validation(sessionId);

            return _sessions[sessionId].Export();
        }

        private void Validation(int sessionId)
        {
            if (_sessions.ContainsKey(sessionId) == false)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
