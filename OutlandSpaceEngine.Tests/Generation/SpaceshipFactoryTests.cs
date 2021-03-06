using System.Linq;
using System.Windows.Input;
using NUnit.Framework;
using Universe.Objects;
using Universe.Objects.Equipment;
using Universe.Objects.Equipment.Control;
using Universe.Objects.Equipment.Energy;
using Universe.Objects.Equipment.Shield;
using Universe.Objects.Equipment.Weapon;
using Universe.Objects.Spaceships;

namespace OutlandSpaceEngine.Tests.Generation
{
    [TestFixture]
    public class SpaceshipFactoryTests
    {
        [Test]
        public void GenerateFuryClassSpaceship()
        {
            // Arrange 

            var expectedModulesCount = 4;

            // Act

            var furyClassSpaceship = SpaceshipFactory.GenerateFuryClassSpaceship();

            // Assert

            Assert.That(furyClassSpaceship.Id, Is.InRange(1000000000, 2147483647));
            Assert.That(furyClassSpaceship.Type, Is.EqualTo(CelestialObjectTypes.SpaceshipNpcNeutral));
            Assert.That(furyClassSpaceship.IsNameCorrect, Is.EqualTo(true));

            Assert.That(furyClassSpaceship.ToSpaceship().Modules.Count, Is.EqualTo(expectedModulesCount));

            IShieldModule shieldModule = furyClassSpaceship.ToSpaceship().GetShieldModules().First();

            Assert.That(shieldModule.OwnerId, Is.EqualTo(furyClassSpaceship.Id));
            Assert.That(shieldModule.Category, Is.EqualTo(ModuleCategory.Shield));
            Assert.That(shieldModule.Name, Is.EqualTo("Standard Medium Shield Mk I"));

            IWeaponModule weaponModule = furyClassSpaceship.ToSpaceship().GetWeaponModules().First();

            Assert.That(weaponModule.OwnerId, Is.EqualTo(furyClassSpaceship.Id));
            Assert.That(weaponModule.Category, Is.EqualTo(ModuleCategory.Weapon));
            Assert.That(weaponModule.Name, Is.EqualTo("Light Missile Launcher I"));

            IRechargeableBattery rechargeableBattery = furyClassSpaceship.ToSpaceship().GetRechargeableBatteryModules().First();

            Assert.That(rechargeableBattery.OwnerId, Is.EqualTo(furyClassSpaceship.Id));
            Assert.That(rechargeableBattery.Category, Is.EqualTo(ModuleCategory.RechargeableBattery));
            Assert.That(rechargeableBattery.Name, Is.EqualTo("Standard Large Battery Mk I"));

            ICommandModule commandModule = furyClassSpaceship.ToSpaceship().GetCommandModules().First();

            Assert.That(commandModule.OwnerId, Is.EqualTo(furyClassSpaceship.Id));
            Assert.That(commandModule.Category, Is.EqualTo(ModuleCategory.Command));
            Assert.That(commandModule.Name, Is.EqualTo("Command Module FS Mk I"));
        }
    }
}