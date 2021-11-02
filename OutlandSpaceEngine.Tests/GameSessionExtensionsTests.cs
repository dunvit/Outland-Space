using Engine;
using NUnit.Framework;
using Universe.Objects;
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
    }
}
