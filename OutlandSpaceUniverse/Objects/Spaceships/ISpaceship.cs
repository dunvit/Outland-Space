using System.Collections.Generic;
using Universe.Characters;
using Universe.Objects.Equipment;
using Universe.Objects.Equipment.Control;
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
        List<ICommandModule> GetCommandModules();
        List<IRechargeableBattery> GetRechargeableBatteryModules();

        List<IWeaponModule> GetWorkableWeaponModules();
        List<IShieldModule> GetWorkableShieldModules();
        List<ICommandModule> GetWorkableCommandModules();
        List<IRechargeableBattery> GetWorkableRechargeableBatteryModules();

        public List<ICharacter> Crew { get; set; }
    }
}
