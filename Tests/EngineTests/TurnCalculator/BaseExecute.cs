using System;
using Engine;
using NUnit.Framework;

namespace Tests.EngineTests.TurnCalculator
{
    [TestFixture]
    public class BaseExecute
    {
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void RefreshGameSessionTest(int value)
        {
            ITurnCalculator server = new Engine.TurnCalculator();

            Assert.Throws<NotImplementedException>(() => server.Execute(value));
        }
    }
}