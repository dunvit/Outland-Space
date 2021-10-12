using System;
using Engine.Sessions;
using OutlandSpaceCommon;
using Universe;
using Universe.Session;

namespace Engine
{
    public class LocalGameServer: IGameServer
    {
        readonly ISessionsCollection _sessions = new SessionsCollection();

        public IGameSessionData RefreshGameSession(int sessionId)
        {
            Validation(sessionId);

            return _sessions.Get(sessionId).Export();
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

            return _sessions.Get(sessionId).Turn;
        }

        public IGameSessionData SessionInitialization(int sessionId = -1)
        {
            var session = SessionFactory.ProduceSession(sessionId);

            _sessions.Set(session);

            return session;
        }

        public IGameSessionData Execute(int sessionId, int turns)
        {
            Validation(sessionId);

            var session = _sessions.Get(sessionId).DeepClone();

            session.Block();

            var result = new TurnCalculator().Execute(session, turns);

            session.UnBlock();

            return result;
        }

        private void Validation(int sessionId)
        {
            if (_sessions.IsExists(sessionId) == false)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
