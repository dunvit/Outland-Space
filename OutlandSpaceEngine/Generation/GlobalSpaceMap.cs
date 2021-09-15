using System.Collections.Generic;
using Universe.Objects;
using Universe.Session;

namespace Engine.Generation
{
    public class GlobalSpaceMap
    {
        public static CelestialMap GenerateEmpty()
        {
            var objects = new List<ICelestialObject>();

            objects.Add(PlayerSpacecraft.Generate());

            return new CelestialMap(objects);
        }
    }
}
