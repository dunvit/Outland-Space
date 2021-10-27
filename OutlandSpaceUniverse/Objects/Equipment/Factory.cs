using OutlandSpaceCommon;
using System;
using Universe.Objects.Equipment.Shield;

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

                default:
                    throw new Exception($"Module with id is {id} not found in database.");
            }

            return module;
        }
    }
}
