using System;
using OutlandSpaceCommon;

namespace Universe.Objects.Equipment.Energy
{
    public class EnergyModuleFactory
    {
        public static IModule Create(int ownerId, ModulesType moduleType)
        {
            IModule module;

            switch (moduleType)
            {
                case ModulesType.EnergyModulesStandardLargeBattery:
                    module = new RechargeableBattery()
                    {
                        Id = RandomGenerator.GetId(),
                        OwnerId = ownerId,
                        ActivationCost = 100,
                        MaxCapacity = 300,
                        Capacity = 300,
                        Category = ModuleCategory.RechargeableBattery,
                        Name = "Standard Large Battery Mk I",
                        ArmorActual = 10,
                        ArmorDesign = 10,
                        StructureActual = 5,
                        StructureDesign = 5
                    };
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(moduleType), moduleType, null);
            }

            return module;
        }
    }
}
