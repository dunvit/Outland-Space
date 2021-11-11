
using System;
using System.Drawing;

namespace Universe.Objects.Asteroids
{
    [Serializable]
    public class Asteroid : BaseCelestialObject, ICelestialObject
    {
        public bool IsOreScanned { get; set; }
        
    }
}
