using Engine.Generation;
using Engine.Sessions;
using NUnit.Framework;
using System.Collections.Generic;
using Universe.Geometry;

namespace OutlandSpaceClient.Tests.Tools
{
    [TestFixture]
    public class OuterSpaceTests
    {
        [Test]
        public void OuterSpaceShouldWorkCorrectWithChangeActiveObjectEvent()
        {
            // Arrange
            var changeActiveObjectEvents = new List<int>();

            // Act

            var session = SessionFactory.GenerateBaseSession(GlobalSpaceMap.GenerateEmptyBase());
            var asteroid = AsteroidFactory.GenerateSmall(new Point(10100, 10100));
            session.AddCelestialObject(asteroid);

            var sessionData = session.ToGameSession();

            var outerSpace = new OutlandSpaceClient.Tools.OuterSpace();

            outerSpace.OnChangeActiveObject += delegate (int id)
            {
                changeActiveObjectEvents.Add(id);
            };

            outerSpace.Refresh(sessionData, new Point(10100, 10100), OutlandSpaceClient.Tools.MouseArguments.Move);
            outerSpace.Refresh(sessionData, new Point(10150, 10150), OutlandSpaceClient.Tools.MouseArguments.Move);
            outerSpace.Refresh(sessionData, new Point(10101, 10101), OutlandSpaceClient.Tools.MouseArguments.Move);
            outerSpace.Refresh(sessionData, new Point(10150, 10150), OutlandSpaceClient.Tools.MouseArguments.Move);
            outerSpace.Refresh(sessionData, new Point(10107, 10091), OutlandSpaceClient.Tools.MouseArguments.Move);
            
            // Assert

            Assert.AreEqual(asteroid.Id, changeActiveObjectEvents[0]);
            Assert.AreEqual(0, changeActiveObjectEvents[1]);
            Assert.AreEqual(asteroid.Id, changeActiveObjectEvents[2]);
            Assert.AreEqual(0, changeActiveObjectEvents[3]);
            Assert.AreEqual(asteroid.Id, changeActiveObjectEvents[4]);
        }

        [Test]
        public void OuterSpaceShouldWorkCorrectWithChangeselectedObjectEvent()
        {
            // Arrange
            var changeSelectedObjectEvents = new List<int>();

            // Act

            var session = SessionFactory.GenerateBaseSession(GlobalSpaceMap.GenerateEmptyBase());
            var firstAsteroid = AsteroidFactory.GenerateSmall(new Point(10100, 10100));
            session.AddCelestialObject(firstAsteroid);
            var secondAsteroid = AsteroidFactory.GenerateSmall(new Point(10300, 10100));
            session.AddCelestialObject(secondAsteroid);

            var outerSpace = new OutlandSpaceClient.Tools.OuterSpace();

            outerSpace.OnChangeSelectedObject += delegate (int id)
            {
                changeSelectedObjectEvents.Add(id);
            };

            var sessionData = session.ToGameSession();

            outerSpace.Refresh(sessionData, new Point(10100, 10100), OutlandSpaceClient.Tools.MouseArguments.LeftClick);
            outerSpace.Refresh(sessionData, new Point(10150, 10150), OutlandSpaceClient.Tools.MouseArguments.LeftClick);
            outerSpace.Refresh(sessionData, new Point(10101, 10101), OutlandSpaceClient.Tools.MouseArguments.LeftClick);
            outerSpace.Refresh(sessionData, new Point(10150, 10150), OutlandSpaceClient.Tools.MouseArguments.LeftClick);
            outerSpace.Refresh(sessionData, new Point(10107, 10091), OutlandSpaceClient.Tools.MouseArguments.LeftClick);
            outerSpace.Refresh(sessionData, new Point(10300, 10100), OutlandSpaceClient.Tools.MouseArguments.LeftClick);
            outerSpace.Refresh(sessionData, new Point(10105, 10105), OutlandSpaceClient.Tools.MouseArguments.LeftClick);
            // Assert

            Assert.AreEqual(firstAsteroid.Id, changeSelectedObjectEvents[0]);
            Assert.AreEqual(firstAsteroid.Id, changeSelectedObjectEvents[1]);
            Assert.AreEqual(firstAsteroid.Id, changeSelectedObjectEvents[2]);
            Assert.AreEqual(secondAsteroid.Id, changeSelectedObjectEvents[3]);
            Assert.AreEqual(firstAsteroid.Id, changeSelectedObjectEvents[4]);
        }

        [Test]
        public void OuterSpaceShouldTrackMouseCoordinates()
        {
            // Arrange

            // Act

            var sessionData = SessionFactory.GenerateBaseSession(GlobalSpaceMap.GenerateEmptyBase()).ToGameSession();
            var outerSpace = new OutlandSpaceClient.Tools.OuterSpace();

            // Assert

            outerSpace.Refresh(sessionData, new Point(10100, 10100), OutlandSpaceClient.Tools.MouseArguments.Move);
            Assert.AreEqual(true, new Point(10100, 10100).IsEqualTo(outerSpace.MouseCoordinates));
            outerSpace.Refresh(sessionData, new Point(10150, 10150), OutlandSpaceClient.Tools.MouseArguments.LeftClick);
            Assert.AreEqual(true, new Point(10150, 10150).IsEqualTo(outerSpace.MouseCoordinates));
            outerSpace.Refresh(sessionData, new Point(10101, 10101), OutlandSpaceClient.Tools.MouseArguments.RightClick);
            Assert.AreEqual(true, new Point(10101, 10101).IsEqualTo(outerSpace.MouseCoordinates));
            outerSpace.Refresh(sessionData, new Point(10150, 10150), OutlandSpaceClient.Tools.MouseArguments.Move);
            Assert.AreEqual(true, new Point(10150, 10150).IsEqualTo(outerSpace.MouseCoordinates));
            outerSpace.Refresh(sessionData, new Point(10107, 10091), OutlandSpaceClient.Tools.MouseArguments.Move);
            Assert.AreEqual(true, new Point(10107, 10091).IsEqualTo(outerSpace.MouseCoordinates));
        }
    }
}
