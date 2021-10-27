using System;

namespace Universe.Objects.Equipment.Shield
{
    [Serializable]
    public class ShieldModule : BaseModule, IModule, IShieldModule
    {
        public double Power { get; set; }
    }
}
