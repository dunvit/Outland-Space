using System;
using Engine;
using Engine.Sessions;
using NUnit.Framework;

namespace OutlandSpaceEngine.Tests.Sessions
{
    [TestFixture]
    public class SessionsCollectionTests
    {
        private ISessionsCollection sessions;

        [SetUp]
        protected void Init()
        {
            sessions = new SessionsCollection();
        }

        [Test]
        public void IsExists_Negative()
        {
            Assert.That(sessions.IsExists(111), Is.False); 
        }

        [Test]
        public void IsExists_Positive()
        {
            var session = new GameSession();

            sessions.Set(session);

            Assert.That(sessions.Count, Is.EqualTo(1));
            Assert.That(sessions.IsExists(session.Id), Is.True);
        }

        [Test]
        public void Set_Positive()
        {
            Assert.That(sessions.Count, Is.EqualTo(0));

            sessions.Set(new GameSession());

            Assert.That(sessions.Count, Is.EqualTo(1));
        }

        [Test]
        public void Set_Negative()
        {
            Assert.That(sessions.Count, Is.EqualTo(0));

            var session = new GameSession();

            sessions.Set(session);

            Assert.That(sessions.Count, Is.EqualTo(1));

            Assert.Throws<InvalidOperationException>(() => sessions.Set(session));
        }

        [Test]
        public void Get_Positive()
        {
            var session = new GameSession();

            sessions.Set(session);

            var sessionDto = sessions.Get(session.Id);

            Assert.That(sessionDto.Id, Is.EqualTo(session.Id));
        }

        [Test]
        public void Update_Positive()
        {
            var session = new GameSession();

            sessions.Set(session);

            Assert.That(sessions.Count, Is.EqualTo(1));

            session.ScenarioName = "test";

            sessions.Update(session);

            var sessionAfterUpdate = sessions.Get(session.Id);

            Assert.That(sessionAfterUpdate.ScenarioName, Is.EqualTo("test"));
        }

        [Test]
        public void Update_Negative()
        {
            var session = new GameSession();

            Assert.Throws<InvalidOperationException>(() => sessions.Update(session));
        }
    }
}
