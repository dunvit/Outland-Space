
namespace Universe.Objects.Equipment.Energy
{
    public interface IRechargeableBattery: IModule
    {
        public double Capacity { get; set; }
        public double MaxCapacity { get; set; }
    }
}
