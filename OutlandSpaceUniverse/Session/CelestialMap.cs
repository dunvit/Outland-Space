using System.Collections.Generic;
using OutlandSpaceCommon;
using Universe.Objects;

namespace Universe.Session
{
    public class CelestialMap
    {
        public string Id { get; set; }
        private List<ICelestialObject> _celestialObjects = new List<ICelestialObject>();

        public CelestialMap(List<ICelestialObject> objects)
        {
            _celestialObjects = objects;
        }

        public List<ICelestialObject> GetCelestialObjects()
        {
            return _celestialObjects.DeepClone();
        }

        public void Add(List<ICelestialObject> celestialObjects)
        {
            foreach (var celestialObject in celestialObjects)
            {
                _celestialObjects.Add(celestialObject);
            }
        }

        public void Add(ICelestialObject celestialObject)
        {
            _celestialObjects.Add(celestialObject);
        }
    }
}
