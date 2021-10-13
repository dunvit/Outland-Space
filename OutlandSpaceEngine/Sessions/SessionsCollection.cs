using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Sessions
{
    public class SessionsCollection: ISessionsCollection
    {
        private readonly Dictionary<int, IGameSession> _sessions = new Dictionary<int, IGameSession>();

        public IGameSession Get(int sessionId)
        {
            return _sessions[sessionId];
        }

        public List<IGameSession> GetAll()
        {
            return _sessions.Select(gameSession => gameSession.Value).ToList();
        }

        public void Set(IGameSession session)
        {
            if (IsExists(session.Id))
            {
                throw new InvalidOperationException();
            }

            _sessions[session.Id] = session;
        }

        public void Update(IGameSession session)
        {
            if (IsExists(session.Id) == false)
            {
                throw new InvalidOperationException();
            }

            _sessions[session.Id] = session;
        }

        public bool IsExists(int sessionId)
        {
            return _sessions.ContainsKey(sessionId);
        }

        public int Count()
        {
            return _sessions.Count;
        }

        public IEnumerator GetEnumerator()
        {
            return _sessions.GetEnumerator();
        }
    }
}