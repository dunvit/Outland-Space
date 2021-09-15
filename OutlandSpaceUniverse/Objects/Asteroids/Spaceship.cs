using System;
using System.Collections.Generic;
using Universe.Modules;

namespace Universe.Objects.Asteroids
{
    [Serializable]
    public class Spaceship : BaseCelestialObject, ICelestialObject
    {
        public int MaxSpeed { get; set; }

        public List<IModule> Modules { get; set; } = new List<IModule>();
    }
}
