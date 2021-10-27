using NUnit.Framework;
using System;
using Universe.Objects.Equipment;
using Universe.Objects.Equipment.Shield;

namespace Tests.EngineTests.Generation
{
    [TestFixture]
    public class EquipmentFactoryTests
    {
        [Test]
        public void EquipmentFactoryShieldsGeneration_NegativeTest()
        {
            Assert.Throws<Exception>(() => Factory.Create(1, ""));
        }

        [Test]
        public void EquipmentFactoryShieldsGeneration_PositiveTest()
        {
            IModule module = Factory.Create(1, "SSM5001");

            Assert.That(module.Name, Is.EqualTo("Shield Mk I"));
            Assert.That(module.OwnerId, Is.EqualTo(1));
            Assert.That(module.ActivationCost, Is.EqualTo(100));            
            Assert.That(module.Category, Is.EqualTo(Category.Shield));

            IShieldModule shieldModule = (IShieldModule)module;

            Assert.That(shieldModule.Power, Is.EqualTo(200));
        }
    }
}
