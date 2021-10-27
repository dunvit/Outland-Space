using System.Collections.Generic;
using Universe.Objects.Equipment;

namespace Universe.Objects.Spaceships
{
    public interface ISpaceship
    {
        public List<IModule> Modules { get; set; }

        float MaxSpeed { get; set; }
    }
}
