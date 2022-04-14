using BenchmarkDotNet.Attributes;
using Universe.Geometry;
using Universe.Objects;
using Universe.Objects.Asteroids;
using Universe.Objects.Points;

namespace Engine.Generation
{
    [MemoryDiagnoser]
    public class AsteroidFactory
    {
        private static ICelestialObjectBuilder BasePreset()
        {
            return new CelestialObjectBuilder(new Asteroid())
                .BuildGeneralData()
                .BuildNavigation();
        }

        private static ICelestialObject Generate(ICelestialObjectBuilder builder)
        {
            return builder.Build();
        }

        [Benchmark]
        public static ICelestialObject GenerateSmall(SpacePoint centerMap, int radius)
        {
            var asteroidBuilder = BasePreset()
                .BuildLocation(centerMap, radius);

            return Generate(asteroidBuilder);
        }

        public static ICelestialObject GenerateSmall(Point location)
        {
            var asteroidBuilder = BasePreset()
                .BuildLocation(location);

            return Generate(asteroidBuilder);
        }
    }
}
