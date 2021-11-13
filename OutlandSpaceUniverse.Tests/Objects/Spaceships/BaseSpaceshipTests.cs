using NUnit.Framework;
using System.Linq;
using Universe.Objects;

namespace OutlandSpaceUniverse.Tests.Objects.Spaceships
{
    [TestFixture]
    public class BaseSpaceshipTests
    {
        [Test]
        public void SpaceshipShouldBeNotDestroyed()
        {
            // Arrange

            var expectedIsSpaceshipDestroyed = false;

            // Act

            var celestialObject = Engine.Generation.PlayerSpacecraft.Generate();

            var spaceship = celestialObject.ToSpaceship();

            // Assert

            Assert.AreEqual(expectedIsSpaceshipDestroyed, spaceship.IsDestroyed);
        }

        [Test]
        public void SpaceshipWithoutReactorShouldBeDestroyed()
        {
            // Arrange

            var expectedIsSpaceshipDestroyed = true;

            // Act

            var celestialObject = Engine.Generation.PlayerSpacecraft.Generate();

            var spaceship = celestialObject.ToSpaceship();

            spaceship.GetRechargeableBatteryModules().FirstOrDefault().Hit(200);

            // Assert

            Assert.AreEqual(expectedIsSpaceshipDestroyed, spaceship.IsDestroyed);
        }

        [Test]
        public void SpaceshipWithoutCommandCenterShouldBeDestroyed()
        {
            // Arrange

            var expectedIsSpaceshipDestroyed = true;

            // Act

            var celestialObject = Engine.Generation.PlayerSpacecraft.Generate();

            var spaceship = celestialObject.ToSpaceship();

            spaceship.GetCommandModules().FirstOrDefault().Hit(200);

            // Assert

            Assert.AreEqual(expectedIsSpaceshipDestroyed, spaceship.IsDestroyed);
        }

        [Test]
        public void CountOfWorkableModulesShouldBeCorrect()
        {
            // Arrange

            var expectedChargeableBatteryModulesCount = 1;
            var expectedWeaponModulesCount = 1;
            var expectedShieldModulesCount = 1;
            var expectedCommandModulesCount = 1;

            var expectedDestroyedShipChargeableBatteryModulesCount = 0;
            var expectedDestroyedShipWeaponModulesCount = 0;
            var expectedDestroyedShipShieldModulesCount = 0;
            var expectedDestroyedShipCommandModulesCount = 0;

            // Act

            var spaceship = Engine.Generation.PlayerSpacecraft.Generate().ToSpaceship();
            var spaceshipDestroyed = Engine.Generation.PlayerSpacecraft.Generate().ToSpaceship();

            spaceshipDestroyed.GetRechargeableBatteryModules().FirstOrDefault().Hit(200);
            spaceshipDestroyed.GetWorkableWeaponModules().FirstOrDefault().Hit(200);
            spaceshipDestroyed.GetWorkableShieldModules().FirstOrDefault().Hit(200);
            spaceshipDestroyed.GetWorkableCommandModules().FirstOrDefault().Hit(200);

            // Assert

            Assert.AreEqual(expectedChargeableBatteryModulesCount, spaceship.GetWorkableRechargeableBatteryModules().Count);
            Assert.AreEqual(expectedWeaponModulesCount, spaceship.GetWorkableWeaponModules().Count);
            Assert.AreEqual(expectedShieldModulesCount, spaceship.GetWorkableShieldModules().Count);
            Assert.AreEqual(expectedCommandModulesCount, spaceship.GetWorkableCommandModules().Count);

            Assert.AreEqual(expectedDestroyedShipChargeableBatteryModulesCount, spaceshipDestroyed.GetWorkableRechargeableBatteryModules().Count);
            Assert.AreEqual(expectedDestroyedShipWeaponModulesCount, spaceshipDestroyed.GetWorkableWeaponModules().Count);
            Assert.AreEqual(expectedDestroyedShipShieldModulesCount, spaceshipDestroyed.GetWorkableShieldModules().Count);
            Assert.AreEqual(expectedDestroyedShipCommandModulesCount, spaceshipDestroyed.GetWorkableCommandModules().Count);
        }

        
    }
}
