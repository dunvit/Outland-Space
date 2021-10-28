using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Universe.Objects.Equipment;
using Universe.Objects.Equipment.Shield;

namespace OutlandSpaceUniverse.Tests.Objects.Equipment
{
    [TestFixture]
    public class FactoryTests
    {
        [Test]
        public void ShouldReturnShieldNodule()
        {
            // Arrange

            // Act
            var sup = Factory.Create(1, "SSM5001");

            // Assert
            Assert.That(sup.Category, Is.EqualTo(Category.Shield));
            Assert.That(sup.OwnerId, Is.EqualTo(1));
            Assert.That(sup.ActivationCost, Is.EqualTo(100));
            Assert.That(sup.Name, Is.EqualTo("Shield Mk I"));

            var shieldModule = (IShieldModule)sup;
            Assert.That(shieldModule.Power, Is.EqualTo(200));
        }

        [Test]
        public void ShouldThrowExceptionOnCreateModuleWithWrongId()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<Exception>(() => Factory.Create(1, "KSM5001"));
        }
    }
}
