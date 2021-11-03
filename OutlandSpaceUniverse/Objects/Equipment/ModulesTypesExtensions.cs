using Universe.Objects.Equipment.Energy;
using Universe.Objects.Equipment.Shield;
using Universe.Objects.Equipment.Weapon;

namespace Universe.Objects.Equipment
{
    public static class ModulesTypesExtensions
    {
        public static int ToInt(this ModulesType module)
        {
            return (int)module;
        }

        public static int ToInt(this EnergyModulesTypes module)
        {
            return (int)module;
        }

        //IRechargeableBattery

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
    }
}
