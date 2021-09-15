using Engine.Generation;
using NUnit.Framework;
using Universe.Objects;

namespace Tests.EngineTests.Generation
{
    [TestFixture]
    public class PlayerSpacecraftTests
    {
        [Test]
        public void GenerateBaseSpaceshipTest()
        {
            var spaceMap = PlayerSpacecraft.Generate();

            Assert.That(spaceMap.Direction, Is.EqualTo(90));
            Assert.That(spaceMap.Name, Is.EqualTo("Glowworm"));
            Assert.That(spaceMap.PositionX, Is.EqualTo(10000));
            Assert.That(spaceMap.PositionY, Is.EqualTo(10000));
            Assert.That(spaceMap.Type, Is.EqualTo(CelestialObjectTypes.SpaceshipPlayer));
        }
    }
}
