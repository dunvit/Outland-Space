using NUnit.Framework;
using Universe.Geometry;

namespace OutlandSpaceUniverse.Tests.Geometry
{
    [TestFixture]
    public class PointTests
    {
        [Test]
        public void EqualsTwoPointsShouldBeCorrect()
        {
            // Arrange

            // Act

            // Assert
            Assert.AreEqual(true, new Point(2.0, 3.01).IsEqualTo(new Point(2.0, 3.01)));
            Assert.AreEqual(true, new Point(2.0, 3.0001).IsEqualTo(new Point(2.0, 3.0002)));
            Assert.AreEqual(true, new Point(2, 3).IsEqualTo(new Point(2, 3)));
        }



    }
}
