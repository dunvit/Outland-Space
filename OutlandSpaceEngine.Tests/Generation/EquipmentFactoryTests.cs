using System;
using NUnit.Framework;
using Universe.Objects.Equipment;
using Universe.Objects.Equipment.Shield;
using Universe.Objects.Equipment.Weapon;

namespace OutlandSpaceEngine.Tests.Generation
{
    [TestFixture]
    public class EquipmentFactoryTests
    {
        [Test]
        public void EquipmentFactoryShieldsGeneration_Negative()
        {
            Assert.Throws<Exception>(() => Factory.Create(1, ""));
        }

        [Test]
        public void EquipmentFactoryShieldsGeneration_Positive()
        {
            IModule module = Factory.Create(1, "SSM5001");

            Assert.That(module.Name, Is.EqualTo("Shield Mk I"));
            Assert.That(module.OwnerId, Is.EqualTo(1));
            Assert.That(module.ActivationCost, Is.EqualTo(100));            
            Assert.That(module.Category, Is.EqualTo(Category.Shield));

            IShieldModule shieldModule = (IShieldModule)module;

            Assert.That(shieldModule.Power, Is.EqualTo(200));
        }

        [Test]
        public void EquipmentFactoryWeaponGeneration_Positive()
        {
            IModule module = Factory.Create(1, "WRS5002");

            Assert.That(module.Name, Is.EqualTo("Light Missile Launcher I"));
            Assert.That(module.OwnerId, Is.EqualTo(1));
            Assert.That(module.ActivationCost, Is.EqualTo(100));
            Assert.That(module.Category, Is.EqualTo(Category.Weapon));

            IWeaponModule weaponModule = (IWeaponModule)module;

            Assert.That(weaponModule.BaseAccuracy, Is.EqualTo(100));
            Assert.That(weaponModule.AmmoId, Is.EqualTo(101));
            
        }
    }
}
