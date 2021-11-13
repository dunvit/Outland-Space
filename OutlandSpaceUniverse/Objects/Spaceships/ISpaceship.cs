using System.Collections.Generic;
using Universe.Objects.Equipment;
using Universe.Objects.Equipment.Energy;
using Universe.Objects.Equipment.Shield;
using Universe.Objects.Equipment.Weapon;

namespace Universe.Objects.Spaceships
{
    public interface ISpaceship: ICelestialObject
    {
        public List<IModule> Modules { get; set; }

        float MaxSpeed { get; set; }

        bool IsDestroyed { get; }

        List<IWeaponModule> GetWeaponModules();
        List<IShieldModule> GetShieldModules();
        List<IRechargeableBattery> GetRechargeableBatteryModules();

        List<IWeaponModule> GetWorkableWeaponModules();
        List<IShieldModule> GetWorkableShieldModules();
        List<IRechargeableBattery> GetWorkableRechargeableBatteryModules();
    }
}
