using Universe.Objects;
using Universe.Session;

namespace Engine
{
    public interface IGameState
    {
        IGameSessionData GetGameSession();

        ICelestialObject GetActiveCelestialObject();

        void SetActiveCelestialObject(int id);

        void SetSession(IGameSessionData session);
    }
}