using Engine;
using Engine.Sessions;
using NUnit.Framework;
using Universe;
using Universe.Objects.Equipment;
using Universe.Objects.Equipment.Weapon;

namespace OutlandSpaceEngine.Tests
{
    [TestFixture]
    public class GameSessionTests
    {
        private IGameSession session;
        private IGameServer _server;

        [SetUp]
        protected void Init()
        {
            _server = new LocalGameServer();
        }

        [Test]
        public void Block()
        {
            session = SessionFactory.ProduceSession();

            Assert.That(session.IsBlocked, Is.EqualTo(false));

            session.Block();

            Assert.That(session.IsBlocked, Is.EqualTo(true));
        }

        [Test]
        public void UnBlock()
        {
            session = SessionFactory.ProduceSession();

            Assert.That(session.IsBlocked, Is.EqualTo(false));

            session.Block();

            Assert.That(session.IsBlocked, Is.EqualTo(true));

            session.UnBlock();

            Assert.That(session.IsBlocked, Is.EqualTo(false));
        }

        [Test]
        public void BaseCommandsInitialization()
        {
            session = SessionFactory.ProduceSession();

            Assert.That(session.GetTurnCommands().Count, Is.EqualTo(0));
        }

        [Test]
        public void AddBaseCommand()
        {
            session = SessionFactory.ProduceSession();

            var command = ((IWeaponModule)Factory.Create(1, "WRS5002")).Shot(201);

            session.AddCommand(1, command);

            Assert.That(session.GetTurnCommands().Count, Is.EqualTo(1));
        }
    }
}
