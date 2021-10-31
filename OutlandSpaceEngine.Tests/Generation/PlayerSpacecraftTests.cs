using Engine.Generation;
using NUnit.Framework;
using Universe.Objects;
using Universe.Objects.Spaceships;

namespace OutlandSpaceEngine.Tests.Generation
{
    [TestFixture]
    public class PlayerSpacecraftTests
    {
        [Test]
        public void GenerateBaseSpaceship()
        {
            var celestialObject = PlayerSpacecraft.Generate();

            Assert.That(celestialObject.Direction, Is.EqualTo(90));
            Assert.That(celestialObject.Name, Is.EqualTo("Glowworm"));
            Assert.That(celestialObject.PositionX, Is.EqualTo(10000));
            Assert.That(celestialObject.PositionY, Is.EqualTo(10000));
            Assert.That(celestialObject.Type, Is.EqualTo(CelestialObjectTypes.SpaceshipPlayer));

            ISpaceship spaceship = celestialObject.ToSpaceship();

            Assert.That(spaceship.Modules.Count, Is.EqualTo(2));
        }

        
    }
}
