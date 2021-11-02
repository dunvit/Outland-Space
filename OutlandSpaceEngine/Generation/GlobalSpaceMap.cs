using System.Collections.Generic;
using Universe.Objects;
using Universe.Objects.Points;
using Universe.Session;

namespace Engine.Generation
{
    public class GlobalSpaceMap
    {
        public static CelestialMap GenerateEmpty()
        {
            var objects = new List<ICelestialObject>();

            return new CelestialMap(objects);
        }

        public static CelestialMap GenerateEmptyBase()
        {
            var objects = new List<ICelestialObject>();

            objects.Add(PlayerSpacecraft.Generate());

            return new CelestialMap(objects);
        }

        public static CelestialMap GenerateBase()
        {
            const double centerMap = 1000;
            const int radiusMap = 500;

            var smallAsteroids = Tools.Random.GenerateSmallAsteroids(120, new SpacePoint(centerMap, centerMap), radiusMap);
            var stations = Tools.Random.GenerateStations(4, new SpacePoint(centerMap, centerMap), radiusMap);

            var objects = new List<ICelestialObject>();

            objects.Add(PlayerSpacecraft.Generate());
            objects.AddRange(smallAsteroids);
            objects.AddRange(stations);

            return new CelestialMap(objects);
        }

        public static CelestialMap GenerateDebug()
        {
            const double centerMap = 1000;
            const int radiusMap = 500;

            var smallAsteroid = Tools.Random.GenerateSmallAsteroid(new SpacePoint(centerMap, radiusMap), radiusMap);

            smallAsteroid.PositionX = 10300;
            smallAsteroid.PositionY = 10300;
            smallAsteroid.Direction = 90;
            smallAsteroid.Speed = 10;

            var objects = new List<ICelestialObject>();

            objects.Add(PlayerSpacecraft.Generate());
            objects.Add(smallAsteroid);


            return new CelestialMap(objects);
        }

    }
}
