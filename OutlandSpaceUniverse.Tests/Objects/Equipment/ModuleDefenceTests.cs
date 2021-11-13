using NUnit.Framework;
using Universe.Objects.Equipment;

namespace OutlandSpaceUniverse.Tests.Objects.Equipment
{
    [TestFixture]
    public class ModuleDefenceTests
    {
        [Test]
        public void BaseStructureShouldBeCorrect()
        {
            // Arrange

            var expectedStructure = 5;
            var expectedStatus = ModuleStatus.Workable;

            // Act

            var missileLauncher = EquipmentFactory.Create(1, ModulesType.WeaponModuleLightMissileLauncher);

            // Assert

            Assert.AreEqual(expectedStructure, missileLauncher.StructureActual);
            Assert.AreEqual(expectedStatus, missileLauncher.Status);
        }

        [Test]
        public void ModuleShouldBeDestroyed()
        {
            // Arrange

            var expectedStructure = -5;
            var expectedStructureFull = 5;
            var expectedStatus = ModuleStatus.Destroyed;

            // Act

            var missileLauncher = EquipmentFactory.Create(1, ModulesType.WeaponModuleLightMissileLauncher);
            missileLauncher.Hit(10);

            // Assert

            Assert.AreEqual(expectedStructureFull, missileLauncher.StructureDesign);
            Assert.AreEqual(expectedStructure, missileLauncher.StructureActual);
            Assert.AreEqual(expectedStatus, missileLauncher.Status);
        }
    }
}
