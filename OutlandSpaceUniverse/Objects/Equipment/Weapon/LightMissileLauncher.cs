
using System;

namespace Universe.Objects.Equipment.Weapon
{
    [Serializable]
    public class LightMissileLauncher: BaseModule, IModule, IWeaponModule
    {
        public int AmmoId { get; set; }
        public double ReloadTime { get; set; }
        public double Reloading { get; set; }
    }
}
