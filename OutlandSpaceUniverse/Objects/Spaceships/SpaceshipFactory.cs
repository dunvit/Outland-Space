using System.Collections.Generic;
using OutlandSpaceCommon;
using Universe.Modules;
using Universe.Objects.Asteroids;

namespace Universe.Objects.Spaceships
{
    public class SpaceshipFactory
    {
        public static Spaceship GenerateFuryClassSpaceship()
        {
            var spaceship = new Spaceship
            {
                Id = RandomGenerator.GetId(),
                Name = RandomGenerator.GenerateCelestialObjectName(),
                MaxSpeed = 12,
                Type = CelestialObjectTypes.SpaceshipNpcNeutral,
                Modules = new List<IModule>()
            };

            return spaceship;
        }
    }
}