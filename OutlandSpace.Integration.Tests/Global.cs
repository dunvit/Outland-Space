
using Universe.Objects;
using Universe.Objects.Spaceships;

namespace OutlandSpace.Integration.Tests
{
    public class Global
    {
        public static GlobalEnvironment GetOneAsteroidEnvironment()
        {
            var environment = new GlobalEnvironment();

            environment.GenerateOneAsteroidEnvironment();

            return environment;
        }

        public static GlobalEnvironment GetOneEnemySpaceshipEnvironment()
        {
            var environment = new GlobalEnvironment();

            var spaceship = SpaceshipFactory.GenerateFuryClassSpaceshipWithCrew();

            spaceship.Id = 1000000002;
            spaceship.Name = "Target I";
            spaceship.Direction = 270;
            spaceship.PositionX = 10010;
            spaceship.PositionY = 10010;
            //spaceship.Speed = 10;

            environment.Session.AddCelestialObject(spaceship);

            environment.Server.SessionInitialization(environment.Session.ToGameSession(), true);

            return environment;
        }
    }

}
