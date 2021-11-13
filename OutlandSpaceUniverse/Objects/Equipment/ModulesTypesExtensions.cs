using Universe.Objects.Equipment.Control;
using Universe.Objects.Equipment.Energy;
using Universe.Objects.Equipment.Shield;
using Universe.Objects.Equipment.Weapon;

namespace Universe.Objects.Equipment
{
    public static class ModulesTypesExtensions
    {
        public static IRechargeableBattery ToRechargeableBattery(this IModule module)
        {
            return (IRechargeableBattery)module;
        }

        public static IWeaponModule ToWeapon(this IModule module)
        {
            return (IWeaponModule)module;
        }

        public static IShieldModule ToShield(this IModule module)
        {
            return (IShieldModule)module;
        }

        public static ICommandModule ToCommand(this IModule module)
        {
            return (ICommandModule)module;
        }
    }
}
