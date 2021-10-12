using Engine;
using NUnit.Framework;

namespace Tests.EngineTests
{
    [TestFixture]
    public class GameSessionTests
    {
        private IGameSession session;

        [Test]
        public void Block_Test()
        {
            session = SessionFactory.ProduceSession();

            Assert.That(session.IsBlocked, Is.EqualTo(false));

            session.Block();

            Assert.That(session.IsBlocked, Is.EqualTo(true));
        }

        [Test]
        public void UnBlock_Test()
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
