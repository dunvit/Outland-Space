using System.Collections.Generic;
using OutlandSpaceCommon;
using Universe.Objects.Equipment;

namespace Universe.Objects.Spaceships
{
    public class SpaceshipFactory
    {
        public static ICelestialObject GenerateFuryClassSpaceship()
        {
            var spaceship = new BaseSpaceship
            {
                Id = RandomGenerator.GetId(),
                Name = RandomGenerator.GenerateCelestialObjectName(),
                MaxSpeed = 12,
                Type = CelestialObjectTypes.SpaceshipNpcNeutral,
                Modules = new List<IModule>()
            };

            spaceship.ToSpaceship().Modules.Add(EquipmentFactory.Create(spaceship.Id, ModulesType.ShieldModuleStandardMediumShield));
            spaceship.ToSpaceship().Modules.Add(EquipmentFactory.Create(spaceship.Id, ModulesType.EnergyModulesStandardLargeBattery));
            spaceship.ToSpaceship().Modules.Add(EquipmentFactory.Create(spaceship.Id, ModulesType.WeaponModuleLightMissileLauncher));

            return spaceship;
        }
    }
}