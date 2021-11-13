using System.Collections.Generic;
using System.Linq;
using Universe.Geometry;
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

        public static List<ICelestialObject> GetCelestialObjectsByDistance(this IGameSession gameSession, Point coordinates, int range)
        {
            return gameSession.GetCelestialObjects().Map(celestialObject => (celestialObject,
                        GeometryTools.Distance(
                            coordinates,
                            celestialObject.GetLocation())
                    )).
                Where(e => e.Item2 < range).
                OrderBy(e => e.Item2).
                Map(e => e.celestialObject).
                ToList();
        }
    }
}
