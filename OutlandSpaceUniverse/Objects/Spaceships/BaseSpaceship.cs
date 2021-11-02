using System;
using System.Collections.Generic;
using Universe.Objects.Equipment;

namespace Universe.Objects.Spaceships
{
    [Serializable]
    public class BaseSpaceship: BaseCelestialObject, ISpaceship
    {
        public List<IModule> Modules { get; set; } = new List<IModule>();

        public float MaxSpeed { get; set; }
    }
}
