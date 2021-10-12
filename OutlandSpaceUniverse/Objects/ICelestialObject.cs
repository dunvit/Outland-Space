
using System;
using System.Collections.Generic;

namespace Universe.Objects
{
    public interface ICelestialObject
    {
        int Id { get; set; }
        string Name { get; set; }
        double Direction { get; set; }
        double Speed { get; set; }
        double PositionX { get; set; }
        double PositionY { get; set; }

        double PreviousPositionX { get; set; }
        double PreviousPositionY { get; set; }

        List<Tuple<int, Geometry.Point>> AtomicLocation { get; set; }

        CelestialObjectTypes Type { get; set; }
    }
}
