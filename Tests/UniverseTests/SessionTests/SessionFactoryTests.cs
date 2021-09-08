using NUnit.Framework;
using Universe.Session;

namespace Tests.UniverseTests.SessionTests
{
    [TestFixture]
    public class SessionFactoryTests
    {
        [Test]
        public void GenerateEmptySessionTest()
        {
            var session = SessionFactory.ProduceSession();

            Assert.That(session.Turn, Is.EqualTo(1));
            Assert.That(session.IsPause, Is.True);
            Assert.That(session.Id, Is.InRange(1000000000, 2147483647));
            Assert.That(session.ScenarioName, Is.EqualTo("Empty session scenario"));
        }
    }
}