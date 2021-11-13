using Engine;
using NUnit.Framework;
using Universe.Objects;
using Universe.Objects.Points;
using Universe.Objects.Spaceships;

namespace OutlandSpaceEngine.Tests
{
    [TestFixture]
    public class GameSessionExtensionsTests
    {
        [Test]
        public void ConvertToSpaceshipShouldBeCorrect()
        {
            var celestialObject = Engine.Generation.PlayerSpacecraft.Generate();

            var spaceship = celestialObject.ToSpaceship();

            Assert.IsTrue(celestialObject is ICelestialObject);
            Assert.IsTrue(spaceship is ISpaceship);
            Assert.That(celestialObject.Type, Is.EqualTo(CelestialObjectTypes.SpaceshipPlayer));
            Assert.That(spaceship.MaxSpeed, Is.EqualTo(12));
        }

        [Test]
        public void GetPlayerSpaceShipShouldReturnSpaceship()
        {
            // Arround
            var exceptedId = 1000000001;
            var exceptedMaxSpeed = 12;

            // Act
            var spaceMap = Engine.Generation.GlobalSpaceMap.GenerateEmptyBase();

            var session = new GameSession(spaceMap);

            var spaceship = session.GetPlayerSpaceShip();

            // Assert

            Assert.AreEqual(exceptedId, spaceship.Id);
            Assert.AreEqual(exceptedMaxSpeed, spaceship.MaxSpeed);
        }

        [Test]
        public void GetCelestialObjectsByDistanceShouldBeCorrect()
        {
            // Arround
            const double centerMap = 1000;
            const int radiusMap = 500;

            var exceptedCelestialObjectCountOn100 = 1;
            var exceptedCelestialObjectCountOn200 = 2;
            var exceptedCelestialObjectCountOn300 = 3;
            var exceptedCelestialObjectCountOn400 = 5;
            var exceptedCelestialObjectCountOn500 = 5;
            var exceptedCelestialObjectCountOn999 = 6;            

            // Act
            var spaceMap = Engine.Generation.GlobalSpaceMap.GenerateEmptyBase();

            var asteroids = Tools.Random.GenerateSmallAsteroids(5, new SpacePoint(centerMap, centerMap), radiusMap);

            // Distance 100
            asteroids[0].PositionX = 10101;
            asteroids[0].PositionY = 10000;

            // Distance 200
            asteroids[1].PositionX = 10201;
            asteroids[1].PositionY = 10000;

            // Distance 300
            asteroids[2].PositionX = 10301;
            asteroids[2].PositionY = 10000;

            // Distance 300
            asteroids[3].PositionX = 9699;
            asteroids[3].PositionY = 10000;

            // Distance 500
            asteroids[4].PositionX = 10501;
            asteroids[4].PositionY = 10000;

            spaceMap.Add(asteroids);

            var session = new GameSession(spaceMap);

            var spaceship = session.GetPlayerSpaceShip();

            var actualCelestialObjectCountOn100 = session.GetCelestialObjectsByDistance(spaceship.GetLocation(), 100);
            var actualCelestialObjectCountOn200 = session.GetCelestialObjectsByDistance(spaceship.GetLocation(), 200);
            var actualCelestialObjectCountOn300 = session.GetCelestialObjectsByDistance(spaceship.GetLocation(), 300);
            var actualCelestialObjectCountOn400 = session.GetCelestialObjectsByDistance(spaceship.GetLocation(), 400);
            var actualCelestialObjectCountOn500 = session.GetCelestialObjectsByDistance(spaceship.GetLocation(), 500);
            var actualCelestialObjectCountOn999 = session.GetCelestialObjectsByDistance(spaceship.GetLocation(), 999);

            // Assert

            Assert.AreEqual(exceptedCelestialObjectCountOn100, actualCelestialObjectCountOn100.Count);
            Assert.AreEqual(exceptedCelestialObjectCountOn200, actualCelestialObjectCountOn200.Count);
            Assert.AreEqual(exceptedCelestialObjectCountOn300, actualCelestialObjectCountOn300.Count);
            Assert.AreEqual(exceptedCelestialObjectCountOn400, actualCelestialObjectCountOn400.Count);
            Assert.AreEqual(exceptedCelestialObjectCountOn500, actualCelestialObjectCountOn500.Count);
            Assert.AreEqual(exceptedCelestialObjectCountOn999, actualCelestialObjectCountOn999.Count);
        }
    }
}
