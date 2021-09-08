using Universe.Session;

namespace Universe
{
    public interface IGameServer
    {
        //GameSession Initialization(string scenario, bool isActive = true);

        SessionDataDto RefreshGameSession(int id);

        void ResumeSession(int id);

        void PauseSession(int id);

        void Command(int sessionId, string command);

        int GetTurn(int sessionId);

        void SessionInitialization(int sessionId = -1);
    }
}
