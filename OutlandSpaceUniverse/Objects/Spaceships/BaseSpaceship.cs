using System;
using System.Collections.Generic;
using System.Linq;
using Universe.Objects.Equipment;
using Universe.Objects.Equipment.Energy;
using Universe.Objects.Equipment.Shield;
using Universe.Objects.Equipment.Weapon;

namespace Universe.Objects.Spaceships
{
    [Serializable]
    public class BaseSpaceship: BaseCelestialObject, ISpaceship
    {
        public List<IModule> Modules { get; set; } = new List<IModule>();

        public float MaxSpeed { get; set; }
        public List<IWeaponModule> GetWeaponModules()
        {
            return Modules.
                Where(module => module.Category == ModuleCategory.Weapon).
                Select(weaponModule => weaponModule.ToWeapon()).
                ToList();
        }

        public List<IShieldModule> GetShieldModules()
        {
            return Modules.
                Where(module => module.Category == ModuleCategory.Shield).
                Select(weaponModule => weaponModule.ToShield()).
                ToList();
        }

        public List<IRechargeableBattery> GetRechargeableBatteryModules()
        {
            return Modules.
                Where(module => module.Category == ModuleCategory.RechargeableBattery).
                Select(weaponModule => weaponModule.ToRechargeableBattery()).
                ToList();
        }
    }
}
