using System.Collections.Generic;
using Universe.Session;

namespace Universe
{
    public interface IGameServer
    {
        //GameSession Initialization(string scenario, bool isActive = true);

        IGameSessionData RefreshGameSession(int id);

        void ResumeSession(int id);

        void PauseSession(int id);

        void Command(int sessionId, string command);

        int GetTurn(int sessionId);
        IGameSessionData SessionInitialization(bool debug = false, bool isGenerateStartMap = false, int sessionId = -1);

        IGameSessionData Execute(int sessionId, int turns);

        
    }
}
