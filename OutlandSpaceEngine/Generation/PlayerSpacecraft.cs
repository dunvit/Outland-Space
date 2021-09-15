using System.Collections.Generic;
using OutlandSpaceCommon;
using Universe.Modules;
using Universe.Objects;
using Universe.Objects.Asteroids;

namespace Engine.Generation
{
    public class PlayerSpacecraft
    {
        public static ICelestialObject Generate()
        {
            var spaceship = new Spaceship
            {
                Id = RandomGenerator.GetId(),
                Name = "Glowworm",
                Direction = 90,
                PositionX = 10000,
                PositionY = 10000,
                MaxSpeed = 12,
                Modules = new List<IModule>(),
                Type = CelestialObjectTypes.SpaceshipPlayer
            };


            return spaceship;
        }
    }
}
