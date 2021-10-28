using System;
using NUnit.Framework;
using Updater;

namespace OutlandSpaceClientUpdater.Tests
{
    [TestFixture]
    public class WorkerTests
    {
        [Test]
        public void ShouldCreateLocalServer()
        {
            // Arrange
            const bool actual = true;
            var sup = new Worker();

            // Act
            sup.StartNewGameSession(0);
            sup.GetDataFromServer();

            // Assert
            Assert.That(actual, Is.EqualTo(sup.IsRunning()));
            
        }

        [Test]
        public void ShouldCreateNotWorksWorker()
        {
            // Arrange
            const bool actual = false;
            var sup = new Worker();

            // Act

            // Assert
            Assert.That(actual, Is.EqualTo(sup.IsRunning()));

        }

        [Test]
        public void ShouldThrowNullExceptionOnExecuteEmptySession()
        {
            // Arrange
            var sup = new Worker();

            // Act

            // Assert
            Assert.Throws<NullReferenceException>( () => sup.GetDataFromServer());

        }
    }
}
