using System.Collections;
using System.Collections.Generic;

namespace Engine.Sessions
{
    public interface ISessionsCollection : IEnumerable
    {
        IGameSession Get(int sessionId);

        List<IGameSession> GetAll();

        void Set(IGameSession session);

        void Update(IGameSession session);

        bool IsExists(int sessionId);

        int Count();
    }
}