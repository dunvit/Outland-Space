using OutlandSpaceCommon;
using System;
using Universe.Objects.Equipment.Shield;
using Universe.Objects.Equipment.Weapon;

namespace Universe.Objects.Equipment
{
    public class Factory
    {
        public static IModule Create(int ownerId, string id)
        {
            IModule module;

            switch (id)
            {
                case "SSM5001":
                    module = new ShieldModule
                    {
                        Id = RandomGenerator.GetId(),
                        OwnerId = ownerId,
                        ActivationCost = 100,
                        Power = 200,
                        Category = Category.Shield,
                        Name = "Shield Mk I"
                    };
                    break;

                case "WRS5002":
                    module = new LightMissileLauncher
                    {
                        Id = RandomGenerator.GetId(),
                        OwnerId = ownerId,
                        ActivationCost = 100,
                        Category = Category.Weapon,
                        ReloadTime = 5,
                        Reloading = 5,
                        AmmoId = 101,
                        BaseAccuracy = 100,
                        Name = "Light Missile Launcher I"
                    };
                    break;

                default:
                    throw new Exception($"Module with id is {id} not found in database.");
            }

            return module;
        }
    }
}
