using OutlandSpaceCommon;
using Universe.Objects;
using Universe.Objects.Points;
using Universe.Objects.Stations;

namespace Engine.Generation
{
    public class StationFactory
    {
        public static ICelestialObject Generate(SpacePoint centerMap, int radius)
        {
            var asteroid = new Station
            {
                Type = CelestialObjectTypes.Station,
                Id = RandomGenerator.GetId(),
                Name = RandomGenerator.GenerateCelestialObjectName(),
                PositionX = RandomGenerator.GetDouble(centerMap.X - radius, centerMap.X + radius),
                PositionY = RandomGenerator.GetDouble(centerMap.X - radius, centerMap.X + radius),
                Direction = RandomGenerator.GetDouble(0, 359.99),
                Speed = RandomGenerator.GetDouble(0, 2),
                IsVisited = false
            };

            return asteroid;
        }
    }
}
