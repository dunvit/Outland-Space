using System.Collections.Generic;
using System.Linq;
using Universe.Geometry;
using Universe.Objects;
using Universe.Objects.Spaceships;

namespace Universe.Session
{
    public static class GameSessionDataExtensions
    {
        public static ISpaceship GetPlayerSpaceShip(this IGameSessionData session)
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

        public static List<ICelestialObject> GetCelestialObjectsByDistance(this IGameSessionData gameSession, Point coordinates, int range)
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

        public static ICelestialObject GetCelestialObject(this IGameSessionData gameSession, int celestialObjectId)
        {
            return gameSession.GetCelestialObjects().FirstOrDefault(x => x.Id == celestialObjectId);
        }
    }
}
