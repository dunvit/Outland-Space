using Engine;
using Engine.Sessions;
using NUnit.Framework;

namespace OutlandSpaceEngine.Tests
{
    [TestFixture]
    public class GameSessionTests
    {
        private IGameSession session;

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
    }
}
