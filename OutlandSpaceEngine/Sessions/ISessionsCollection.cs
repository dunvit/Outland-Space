namespace Engine.Sessions
{
    public interface ISessionsCollection
    {
        IGameSession Get(int sessionId);

        void Set(IGameSession session);

        void Update(IGameSession session);

        bool IsExists(int sessionId);

        int Count();
    }
}