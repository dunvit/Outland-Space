using NUnit.Framework;
using Updater;

namespace OutlandSpaceClient.Tests
{
    [TestFixture]
    public class GameManagerTests
    {
        [Test]
        public void ShouldBeCreateGameManagerWithRunningWorker()
        {
            // Arrange
            const bool actual = true;
            var sup = new Worker();

            // Act
            sup.StartNewGameSession(0);
            sup.GetDataFromServer();
            var gameManager = new GameManager(sup);

            // Assert
            Assert.That(actual, Is.EqualTo(sup.IsRunning()));
        }
    }
}
