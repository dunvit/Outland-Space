using System;
using Universe.Objects.Equipment.Energy;
using Universe.Objects.Equipment.Shield;
using Universe.Objects.Equipment.Weapon;

namespace Universe.Objects.Equipment
{
    public class EquipmentFactory
    {
        public static IModule Create(int ownerId, ModulesType moduleType)
        {
            IModule module;

            switch (moduleType)
            {
                case ModulesType.EnergyModulesStandardLargeBattery:
                    module = EnergyModuleFactory.Create(ownerId, moduleType);
                    break;
                case ModulesType.WeaponModuleLightMissileLauncher:
                    module = WeaponModuleFactory.Create(ownerId, moduleType);
                    break;
                case ModulesType.ShieldModuleStandardMediumShield:
                    module = ShieldModuleFactory.Create(ownerId, moduleType);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(moduleType), moduleType, null);
            }

            return module;
        }

    }
}
