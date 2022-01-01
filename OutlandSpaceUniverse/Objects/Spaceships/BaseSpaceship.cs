using System;
using System.Collections.Generic;
using System.Linq;
using Universe.Characters;
using Universe.Objects.Equipment;
using Universe.Objects.Equipment.Control;
using Universe.Objects.Equipment.Energy;
using Universe.Objects.Equipment.Shield;
using Universe.Objects.Equipment.Weapon;

namespace Universe.Objects.Spaceships
{
    [Serializable]
    public class BaseSpaceship: BaseCelestialObject, ISpaceship
    {
        public List<IModule> Modules { get; set; } = new List<IModule>();

        public List<ICharacter> Crew { get; set; } = new List<ICharacter>();

        public float MaxSpeed { get; set; }

        public bool IsDestroyed { get {

                if (GetWorkableRechargeableBatteryModules().Count == 0)
                {
                    return true;
                }

                if (GetWorkableCommandModules().Count == 0)
                {
                    return true;
                }

                return false;
            } 
        }

        public List<IWeaponModule> GetWeaponModules()
        {
            return Modules.
                Where(module => module.Category == ModuleCategory.Weapon).
                Select(weaponModule => weaponModule.ToWeapon()).
                ToList();
        }

        public List<IWeaponModule> GetWorkableWeaponModules()
        {
            return Modules.
                Where(module => module.Category == ModuleCategory.Weapon && module.Status == ModuleStatus.Workable).
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

        public List<IShieldModule> GetWorkableShieldModules()
        {
            return Modules.
                Where(module => module.Category == ModuleCategory.Shield && module.Status == ModuleStatus.Workable).
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

        public List<IRechargeableBattery> GetWorkableRechargeableBatteryModules()
        {
            return Modules.
                Where(module => module.Category == ModuleCategory.RechargeableBattery && module.Status == ModuleStatus.Workable).
                Select(weaponModule => weaponModule.ToRechargeableBattery()).
                ToList();
        }

        

        public List<ICommandModule> GetCommandModules()
        {
            return Modules.
                Where(module => module.Category == ModuleCategory.Command).
                Select(commandModule => commandModule.ToCommand()).
                ToList();
        }

        public List<ICommandModule> GetWorkableCommandModules()
        {
            return Modules.
                Where(module => module.Category == ModuleCategory.Command && module.Status == ModuleStatus.Workable).
                Select(commandModule => commandModule.ToCommand()).
                ToList();
        }
    }
}
