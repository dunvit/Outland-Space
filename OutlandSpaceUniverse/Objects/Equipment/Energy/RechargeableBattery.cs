using System;

namespace Universe.Objects.Equipment.Energy
{
    [Serializable]
    public class RechargeableBattery : BaseModule, IRechargeableBattery
    {
        public double Capacity { get; set; }
        public double MaxCapacity { get; set; }
    }
}
