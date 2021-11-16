using Engine;
using NUnit.Framework;
using Universe.Objects.Equipment;
using Universe.Objects.Equipment.Weapon;

namespace OutlandSpace.Integration.Tests
{
    public class SpaceshipSimpleShotTests
    {
        private GlobalEnvironment _environment;

        [SetUp]
        protected void Init()
        {
            _environment = Global.GetOneAsteroidEnvironment();
        }

        [Test]
        public void SpaceshipSimpleShotTest()
        {
            // Arrange

            const int exceptedId = 1000000001;

            // Act

            _environment.Session = _environment.TurnCalculator.Execute(_environment.Session, 1);

            var spaceship = _environment.Session.GetPlayerSpaceShip();

            var missileLauncher = (IWeaponModule)EquipmentFactory.Create(spaceship.Id, ModulesType.WeaponModuleLightMissileLauncher);

            var command = missileLauncher.Shot(_environment.Session.GetCelestialObjects()[1].Id);

            _environment.Server.Command(_environment.Session.Id, command);

            var commendOnServerSide = new Command(command);

            // Assert

            Assert.AreEqual(exceptedId, spaceship.Id);
            Assert.AreEqual(exceptedId, commendOnServerSide.CelestialObjectId);
        }
    }
}