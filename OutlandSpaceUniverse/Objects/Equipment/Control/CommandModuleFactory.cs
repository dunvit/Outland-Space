using OutlandSpaceCommon;
using System;

namespace Universe.Objects.Equipment.Control
{
    public class CommandModuleFactory
    {
        public static IModule Create(int ownerId, ModulesType moduleType)
        {
            IModule module;

            switch (moduleType)
            {
                case ModulesType.CommandModuleFrigateSize:
                    module = new CommandModule()
                    {
                        Id = RandomGenerator.GetId(),
                        OwnerId = ownerId,
                        ActivationCost = 0,
                        Category = ModuleCategory.Command,
                        Name = "Command Module FS Mk I",
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
