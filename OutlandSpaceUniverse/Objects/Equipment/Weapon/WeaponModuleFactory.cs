using System;
using OutlandSpaceCommon;

namespace Universe.Objects.Equipment.Weapon
{
    public class WeaponModuleFactory
    {
        public static IModule Create(int ownerId, ModulesType moduleType)
        {
            IModule module;

            switch (moduleType)
            {
                case ModulesType.WeaponModuleLightMissileLauncher:
                    module = new LightMissileLauncher
                    {
                        Id = RandomGenerator.GetId(),
                        OwnerId = ownerId,
                        ActivationCost = 100,
                        Category = ModuleCategory.Weapon,
                        ReloadTime = 5,
                        Reloading = 5,
                        AmmoId = 101,
                        BaseAccuracy = 100,
                        Name = "Light Missile Launcher I"
                    };
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(moduleType), moduleType, null);
            }

            return module;
        }
    }
}
