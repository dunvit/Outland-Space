using NUnit.Framework;
using Universe.Objects;
using Universe.Objects.Spaceships;

namespace Tests.EngineTests.Generation
{
    [TestFixture]
    public class SpaceshipFactoryTests
    {
        [Test]
        public void GenerateFuryClassSpaceshipTest()
        {
            var furyClassSpaceship = SpaceshipFactory.GenerateFuryClassSpaceship();

            Assert.That(furyClassSpaceship.Id, Is.InRange(1000000000, 2147483647));
            Assert.That(furyClassSpaceship.Type, Is.EqualTo(CelestialObjectTypes.SpaceshipNpcNeutral));
            Assert.That(furyClassSpaceship.IsNameCorrect, Is.EqualTo(true));

            Assert.That(furyClassSpaceship.Modules.Count, Is.EqualTo(0));
        }
    }
}