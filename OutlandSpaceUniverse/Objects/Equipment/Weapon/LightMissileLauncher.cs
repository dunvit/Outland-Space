
using System;

namespace Universe.Objects.Equipment.Weapon
{
    [Serializable]
    public class LightMissileLauncher: BaseModule, IModule, IWeaponModule
    {
        public int AmmoId { get; set; }
        public int BaseAccuracy { get; set; }
    }
}
