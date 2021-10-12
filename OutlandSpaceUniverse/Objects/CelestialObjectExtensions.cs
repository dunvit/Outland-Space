
using System.Drawing;

namespace Universe.Objects
{
    public static class CelestialObjectExtensions
    {
        public static PointF GetLocation(this ICelestialObject celestialObject)
        {
            return new PointF((float) celestialObject.PositionX, (float) celestialObject.PositionY);
        }

        public static bool IsNameCorrect(this ICelestialObject celestialObject)
        {
            try
            {
                if(celestialObject.Name.Length != 16) return false;

                var data = celestialObject.Name.Split('-');

                if (data.Length != 3) return false;
                if (data[0].Length != 6) return false;
                if (data[1].Length != 4) return false;
                if (data[2].Length != 4) return false;

                return true;
            }
            catch 
            {
                return false;
            }
            
        }
    }
}
