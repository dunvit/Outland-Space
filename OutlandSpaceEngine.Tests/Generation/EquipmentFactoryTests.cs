using System;
using NUnit.Framework;
using Universe.Objects.Equipment;
using Universe.Objects.Equipment.Control;
using Universe.Objects.Equipment.Energy;
using Universe.Objects.Equipment.Shield;
using Universe.Objects.Equipment.Weapon;

namespace OutlandSpaceEngine.Tests.Generation
{
    [TestFixture]
    public class EquipmentFactoryTests
    {
        [Test]
        public void GenerateShieldModuleStandardMediumShieldShouldBeCorrect()
        {
            // Arrange
            var expectedModuleName = "Standard Medium Shield Mk I";
            var expectedPower = 200;

            var expectedArmor = 10;
            var expectedArmorFull = 10;
            var expectedStructure = 5;
            var expectedStructureFull = 5;

            // Act
            var moduleFromEnergyModuleFactory = ShieldModuleFactory.Create(1, ModulesType.ShieldModuleStandardMediumShield).ToShield();
            var moduleFromEquipmentFactory = EquipmentFactory.Create(1, ModulesType.ShieldModuleStandardMediumShield).ToShield();

            // Assert
            Assert.AreEqual(expectedModuleName, moduleFromEnergyModuleFactory.Name);
            Assert.AreEqual(expectedPower, moduleFromEnergyModuleFactory.Power);
            Assert.AreEqual(ModuleCategory.Shield, moduleFromEnergyModuleFactory.Category);
            Assert.That(moduleFromEnergyModuleFactory.ActivationCost, Is.EqualTo(100));

            Assert.AreEqual(expectedModuleName, moduleFromEquipmentFactory.Name);
            Assert.AreEqual(expectedPower, moduleFromEquipmentFactory.Power);
            Assert.AreEqual(ModuleCategory.Shield, moduleFromEquipmentFactory.Category);
            Assert.That(moduleFromEquipmentFactory.ActivationCost, Is.EqualTo(100));

            Assert.AreEqual(expectedArmor, moduleFromEquipmentFactory.ArmorActual);
            Assert.AreEqual(expectedArmorFull, moduleFromEquipmentFactory.ArmorDesign);

            Assert.AreEqual(expectedStructure, moduleFromEquipmentFactory.StructureActual);
            Assert.AreEqual(expectedStructureFull, moduleFromEquipmentFactory.StructureDesign);
        }

        [Test]
        public void GenerateWeaponModuleLightMissileLauncherShouldBeCorrect()
        {
            // Arrange
            var expectedModuleName = "Light Missile Launcher I";
            var expectedBaseAccuracy = 100;
            var expectedAmmoId = 101;

            var expectedArmor = 10;
            var expectedArmorFull = 10;
            var expectedStructure = 5;
            var expectedStructureFull = 5;

            // Act
            var moduleFromEnergyModuleFactory = WeaponModuleFactory.Create(1, ModulesType.WeaponModuleLightMissileLauncher).ToWeapon();
            var moduleFromEquipmentFactory = EquipmentFactory.Create(1, ModulesType.WeaponModuleLightMissileLauncher).ToWeapon();

            // Assert
            Assert.AreEqual(expectedModuleName, moduleFromEnergyModuleFactory.Name);
            Assert.AreEqual(expectedBaseAccuracy, moduleFromEnergyModuleFactory.BaseAccuracy);
            Assert.AreEqual(expectedAmmoId, moduleFromEnergyModuleFactory.AmmoId);
            Assert.AreEqual(ModuleCategory.Weapon, moduleFromEnergyModuleFactory.Category);

            Assert.AreEqual(expectedModuleName, moduleFromEquipmentFactory.Name);
            Assert.AreEqual(expectedBaseAccuracy, moduleFromEquipmentFactory.BaseAccuracy);
            Assert.AreEqual(expectedAmmoId, moduleFromEquipmentFactory.AmmoId);
            Assert.AreEqual(ModuleCategory.Weapon, moduleFromEquipmentFactory.Category);

            Assert.AreEqual(expectedArmor, moduleFromEquipmentFactory.ArmorActual);
            Assert.AreEqual(expectedArmorFull, moduleFromEquipmentFactory.ArmorDesign);

            Assert.AreEqual(expectedStructure, moduleFromEquipmentFactory.StructureActual);
            Assert.AreEqual(expectedStructureFull, moduleFromEquipmentFactory.StructureDesign);
        }

        [Test]
        public void GenerateEnergyModuleStandardLargeBatteryShouldBeCorrect()
        {
            // Arrange
            var expectedModuleName = "Standard Large Battery Mk I";
            var expectedCapacity = 300;
            var expectedMaxCapacity = 300;
            var expectedArmor = 10;
            var expectedArmorFull = 10;
            var expectedStructure = 5;
            var expectedStructureFull = 5;

            // Act
            var moduleFromEnergyModuleFactory = EnergyModuleFactory.Create(1, ModulesType.EnergyModulesStandardLargeBattery).ToRechargeableBattery();
            var moduleFromEquipmentFactory = EquipmentFactory.Create(1, ModulesType.EnergyModulesStandardLargeBattery).ToRechargeableBattery();

            // Assert
            Assert.AreEqual(expectedModuleName, moduleFromEnergyModuleFactory.Name);
            Assert.AreEqual(expectedCapacity, moduleFromEnergyModuleFactory.Capacity);
            Assert.AreEqual(expectedMaxCapacity, moduleFromEnergyModuleFactory.MaxCapacity);
            Assert.AreEqual(ModuleCategory.RechargeableBattery, moduleFromEnergyModuleFactory.Category);

            Assert.AreEqual(expectedModuleName, moduleFromEquipmentFactory.Name);
            Assert.AreEqual(expectedCapacity, moduleFromEquipmentFactory.Capacity);
            Assert.AreEqual(expectedMaxCapacity, moduleFromEquipmentFactory.MaxCapacity);
            Assert.AreEqual(ModuleCategory.RechargeableBattery, moduleFromEquipmentFactory.Category);

            Assert.AreEqual(expectedArmor, moduleFromEquipmentFactory.ArmorActual);
            Assert.AreEqual(expectedArmorFull, moduleFromEquipmentFactory.ArmorDesign);

            Assert.AreEqual(expectedStructure, moduleFromEquipmentFactory.StructureActual);
            Assert.AreEqual(expectedStructureFull, moduleFromEquipmentFactory.StructureDesign);
        }

        [Test]
        public void GenerateCommandModuleFrigateSizeShouldBeCorrect()
        {
            // Arrange
            var expectedModuleName = "Command Module FS Mk I";
            var expectedArmor = 10;
            var expectedArmorFull = 10;
            var expectedStructure = 5;
            var expectedStructureFull = 5;

            // Act
            var moduleFromCommandModuleFactory = CommandModuleFactory.Create(1, ModulesType.CommandModuleFrigateSize).ToCommand();
            var moduleFromEquipmentFactory = EquipmentFactory.Create(1, ModulesType.CommandModuleFrigateSize).ToCommand();

            // Assert
            Assert.AreEqual(expectedModuleName, moduleFromCommandModuleFactory.Name);
            Assert.AreEqual(ModuleCategory.Command, moduleFromCommandModuleFactory.Category);

            Assert.AreEqual(expectedModuleName, moduleFromEquipmentFactory.Name);
            Assert.AreEqual(ModuleCategory.Command, moduleFromEquipmentFactory.Category);

            Assert.AreEqual(expectedArmor, moduleFromEquipmentFactory.ArmorActual);
            Assert.AreEqual(expectedArmorFull, moduleFromEquipmentFactory.ArmorDesign);

            Assert.AreEqual(expectedStructure, moduleFromEquipmentFactory.StructureActual);
            Assert.AreEqual(expectedStructureFull, moduleFromEquipmentFactory.StructureDesign);
        }
    }
}
