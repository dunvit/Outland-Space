
using System;

namespace Universe.Objects.Stations
{
    [Serializable]
    public class Station : BaseCelestialObject, ICelestialObject
    {
        public bool IsVisited { get; set; }
    }
}
