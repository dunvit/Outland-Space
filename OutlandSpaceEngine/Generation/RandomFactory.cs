using System.Collections.Generic;
using Universe.Objects;
using Universe.Objects.Points;

namespace Engine.Generation
{
    public class RandomFactory
    {
        public static List<ICelestialObject> GenerateSmallAsteroids(int count, SpacePoint centerMap, int radius)
        {
            var result = new List<ICelestialObject>();

            for (var i = 0; i < count; i++)
            {
                result.Add(AsteroidFactory.GenerateSmall(centerMap, radius));
            }

            return result;
        }

        public static List<ICelestialObject> GenerateStations(int count, SpacePoint centerMap, int radius)
        {
            var result = new List<ICelestialObject>();

            for (var i = 0; i < count; i++)
            {
                result.Add(StationFactory.Generate(centerMap, radius));
            }

            return result;
        }
    }
}
