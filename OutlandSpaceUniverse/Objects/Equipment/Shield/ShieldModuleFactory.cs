using System;
using OutlandSpaceCommon;

namespace Universe.Objects.Equipment.Shield
{
    public class ShieldModuleFactory
    {
        public static IModule Create(int ownerId, ModulesType moduleType)
        {
            IModule module;

            switch (moduleType)
            {
                case ModulesType.ShieldModuleStandardMediumShield:
                    module = new ShieldModule
                    {
                        Id = RandomGenerator.GetId(),
                        OwnerId = ownerId,
                        ActivationCost = 100,
                        Power = 200,
                        Category = ModuleCategory.Shield,
                        Name = "Standard Medium Shield Mk I"
                    };
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(moduleType), moduleType, null);
            }

            return module;
        }
    }
}
