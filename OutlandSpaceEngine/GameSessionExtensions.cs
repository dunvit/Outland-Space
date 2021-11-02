using Universe.Objects;
using Universe.Objects.Spaceships;

namespace Engine
{
    public static class GameSessionExtensions
    {
        public static ISpaceship GetPlayerSpaceShip(this IGameSession session)
        {
            foreach (var celestialObject in session.GetCelestialObjects())
            {
                if (celestialObject.Type == CelestialObjectTypes.SpaceshipPlayer)
                {
                    return celestialObject.ToSpaceship();
                }
            }

            return null;
        }
    }
}
