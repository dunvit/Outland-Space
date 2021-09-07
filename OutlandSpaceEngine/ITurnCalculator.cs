using Universe.Session;

namespace Engine
{
    public interface ITurnCalculator
    {
        SessionDataDto Execute(int turns);
    }
}