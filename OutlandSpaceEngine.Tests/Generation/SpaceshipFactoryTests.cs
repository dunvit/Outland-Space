﻿using NUnit.Framework;
using Universe.Objects;
using Universe.Objects.Equipment;
using Universe.Objects.Spaceships;

namespace OutlandSpaceEngine.Tests.Generation
{
    [TestFixture]
    public class SpaceshipFactoryTests
    {
        [Test]
        public void GenerateFuryClassSpaceship()
        {
            var furyClassSpaceship = SpaceshipFactory.GenerateFuryClassSpaceship();

            Assert.That(furyClassSpaceship.Id, Is.InRange(1000000000, 2147483647));
            Assert.That(furyClassSpaceship.Type, Is.EqualTo(CelestialObjectTypes.SpaceshipNpcNeutral));
            Assert.That(furyClassSpaceship.IsNameCorrect, Is.EqualTo(true));

            Assert.That(furyClassSpaceship.ToSpaceship().Modules.Count, Is.EqualTo(2));

            IModule shieldModule = furyClassSpaceship.ToSpaceship().Modules[0];

            Assert.That(shieldModule.OwnerId, Is.EqualTo(furyClassSpaceship.Id));
            Assert.That(shieldModule.Category, Is.EqualTo(Category.Shield));
            Assert.That(shieldModule.Name, Is.EqualTo("Shield Mk I"));

            IModule weaponModule = furyClassSpaceship.ToSpaceship().Modules[1];

            Assert.That(weaponModule.OwnerId, Is.EqualTo(furyClassSpaceship.Id));
            Assert.That(weaponModule.Category, Is.EqualTo(Category.Weapon));
            Assert.That(weaponModule.Name, Is.EqualTo("Light Missile Launcher I"));
        }
    }
}