using Engine;
using Engine.Generation;
using NUnit.Framework;
using Universe;
using Universe.Geometry;
using Universe.Objects.Equipment;
using Universe.Objects.Equipment.Weapon;

namespace OutlandSpace.Integration.Tests
{
    public class SpaceshipSimpleShotTests
    {
        private IGameSession session;
        private IGameServer _server;
        private TurnCalculator _turnCalculator;

        [SetUp]
        protected void Init()
        {
            _server = new LocalGameServer();
            _turnCalculator = new TurnCalculator();
        }

        [Test]
        public void SpaceshipSimpleShotTest()
        {
            // Arrange

            var exceptedId = 1000000001;

            // Act

            var spaceMap = GlobalSpaceMap.GenerateEmptyBase();

            session = new GameSession(spaceMap);

            var asteroid = AsteroidFactory.GenerateSmall(new Point(10100, 10100));
            session.AddCelestialObject(asteroid);

            _server.SessionInitialization(session.ToGameSession(), true);

            session = _turnCalculator.Execute(session, 1);

            var spaceship = session.GetPlayerSpaceShip();

            var missileLauncher = (IWeaponModule)EquipmentFactory.Create(spaceship.Id, ModulesType.WeaponModuleLightMissileLauncher);

            var command = missileLauncher.Shot(asteroid.Id);

            _server.Command(session.Id, command);

            // Assert

            Assert.AreEqual(exceptedId, spaceship.Id);
        }
    }
}