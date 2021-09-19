using Universe.Session;

namespace Engine
{
    public interface ITurnCalculator
    {
        IGameSessionData Execute(IGameSession session, int turns);
    }
}