using OutlandSpaceCommon;
using Universe.Objects;
using Universe.Objects.Asteroids;
using Universe.Objects.Spaceships;

namespace Engine.Generation
{
    public class PlayerSpacecraft
    {
        public static ICelestialObject Generate()
        {
            var furyClassSpaceship = SpaceshipFactory.GenerateFuryClassSpaceship();

            var spaceship = new Spaceship
            {
                Id = furyClassSpaceship.Id,
                Name = "Glowworm",
                Direction = 90,
                PositionX = 10000,
                PositionY = 10000,
                Modules = furyClassSpaceship.Modules,
                MaxSpeed = furyClassSpaceship.MaxSpeed,
                Type = CelestialObjectTypes.SpaceshipPlayer
            };

            return spaceship;
        }


    }
}
