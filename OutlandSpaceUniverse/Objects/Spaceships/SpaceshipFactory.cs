using System.Collections.Generic;
using OutlandSpaceCommon;
using Universe.Characters;
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
            spaceship.ToSpaceship().Modules.Add(EquipmentFactory.Create(spaceship.Id, ModulesType.CommandModuleFrigateSize));

            return spaceship;
        }

        public static ICelestialObject GenerateFuryClassSpaceshipWithCrew()
        {
            var spaceship = new BaseSpaceship
            {
                Id = RandomGenerator.GetId(),
                Name = RandomGenerator.GenerateCelestialObjectName(),
                MaxSpeed = 12,
                Type = CelestialObjectTypes.SpaceshipNpcNeutral,
                Modules = new List<IModule>()
            };

            var shield = EquipmentFactory.Create(spaceship.Id, ModulesType.ShieldModuleStandardMediumShield);
            spaceship.ToSpaceship().Modules.Add(shield);

            var energy = EquipmentFactory.Create(spaceship.Id, ModulesType.EnergyModulesStandardLargeBattery);
            spaceship.ToSpaceship().Modules.Add(energy);

            var weapon = EquipmentFactory.Create(spaceship.Id, ModulesType.WeaponModuleLightMissileLauncher);
            spaceship.ToSpaceship().Modules.Add(weapon);

            var commandModule = EquipmentFactory.Create(spaceship.Id, ModulesType.CommandModuleFrigateSize);
            spaceship.ToSpaceship().Modules.Add(commandModule);

            spaceship.Crew.Add(CrewMemberFactory.GenerateRandomCrewMember(spaceship.Id, shield.Id));
            spaceship.Crew.Add(CrewMemberFactory.GenerateRandomCrewMember(spaceship.Id, energy.Id));
            spaceship.Crew.Add(CrewMemberFactory.GenerateRandomCrewMember(spaceship.Id, weapon.Id));
            spaceship.Crew.Add(CrewMemberFactory.GenerateRandomCrewMember(spaceship.Id, commandModule.Id));

            return spaceship;
        }
    }
}