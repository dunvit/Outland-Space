using System;
using System.Collections.Generic;
using Universe.Geometry;

namespace Universe.Objects
{
    [Serializable]
    public class BaseCelestialObject
    {
        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public double PreviousPositionX { get; set; }
        public double PreviousPositionY { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Direction { get; set; }
        public double Speed { get; set; }
        public CelestialObjectTypes Type { get; set; }
        public List<Tuple<int, Point>> AtomicLocation { get; set; } = new List<Tuple<int, Point>>();

        public DateTime LastUpdate { get; set; } = DateTime.UtcNow;
    }


}
