using OutlandSpaceCommon;
using System;
using Universe.Geometry;
using Universe.Objects;
using Universe.Objects.Asteroids;
using Universe.Objects.Points;

namespace Engine.Generation
{
    public class AsteroidFactory
    {
        public static ICelestialObject GenerateSmall(SpacePoint centerMap, int radius)
        {           
            var asteroid = new Asteroid
            {
                Type = CelestialObjectTypes.Asteroid,
                Id = RandomGenerator.GetId(),
                Name = RandomGenerator.GenerateCelestialObjectName(),
                PositionX = RandomGenerator.GetDouble(centerMap.X - radius, centerMap.X + radius),
                PositionY = RandomGenerator.GetDouble(centerMap.X - radius, centerMap.X + radius),
                Direction = RandomGenerator.GetDouble(0, 359.99),
                Speed = RandomGenerator.GetDouble(0, 50),
                IsOreScanned = false
            };

            return asteroid;
        }

        public static ICelestialObject GenerateSmall(Point location)
        {
            var asteroid = new Asteroid
            {
                Type = CelestialObjectTypes.Asteroid,
                Id = RandomGenerator.GetId(),
                Name = RandomGenerator.GenerateCelestialObjectName(),
                PositionX = location.X,
                PositionY = location.Y,
                Direction = RandomGenerator.GetDouble(0, 359.99),
                Speed = RandomGenerator.GetDouble(0, 50),
                IsOreScanned = false
            };

            return asteroid;
        }
    }
}
