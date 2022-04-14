using NUnit.Framework;
using Universe.Objects.Equipment.Weapon;
using System;
using System.Collections.Generic;
using System.Text;
using Universe.Objects.Equipment;

namespace Tests.Universe.Objects.Equipment.Weapon
{
    [TestFixture()]
    public class WeaponModuleFactoryTests
    {
        [Test()]
        public void CreateModuleFromWeaponModuleFactoryTest()
        {
            // Arrange
            var expectedModuleName = "Light Missile Launcher I";
            var expectedBaseAccuracy = 100;
            var expectedAmmoId = 101;

            // Act
            var moduleFromWeaponModuleFactory = WeaponModuleFactory.Create(1, ModulesType.WeaponModuleLightMissileLauncher).ToWeapon();

            // Assert
            Assert.AreEqual(expectedModuleName, moduleFromWeaponModuleFactory.Name);
            Assert.AreEqual(expectedBaseAccuracy, moduleFromWeaponModuleFactory.BaseAccuracy);
            Assert.AreEqual(expectedAmmoId, moduleFromWeaponModuleFactory.AmmoId);
            Assert.AreEqual(ModuleCategory.Weapon, moduleFromWeaponModuleFactory.Category);
        }
    }
}