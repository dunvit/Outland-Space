
using System;

namespace Universe.Objects
{
    [Serializable]
    public class BaseCelestialObject
    {
        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public int Id { get; set; }

        public string Name { get; set; }
        public double Direction { get; set; }
        public double Speed { get; set; }
        public CelestialObjectTypes Type { get; set; }
    }


}
