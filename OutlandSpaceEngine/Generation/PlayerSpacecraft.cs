using Universe.Objects;
using Universe.Objects.Spaceships;

namespace Engine.Generation
{
    public class PlayerSpacecraft
    {
        public static ICelestialObject Generate()
        {
            var furyClassSpaceship = SpaceshipFactory.GenerateFuryClassSpaceship();

            ICelestialObject spaceship = new BaseSpaceship
            {
                Id = 1000000001,
                Name = "Glowworm",
                Direction = 90,
                PositionX = 10000,
                PositionY = 10000,
                Speed = 10,
                Modules = furyClassSpaceship.ToSpaceship().Modules,
                MaxSpeed = furyClassSpaceship.ToSpaceship().MaxSpeed,
                Type = CelestialObjectTypes.SpaceshipPlayer
            };

            return spaceship;
        }


    }
}
