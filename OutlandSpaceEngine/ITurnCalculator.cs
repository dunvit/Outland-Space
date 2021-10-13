using Universe.Session;

namespace Engine
{
    public interface ITurnCalculator
    {
        IGameSession Execute(IGameSession session, int turns);
    }
}