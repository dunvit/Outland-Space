using OutlandSpaceCommon;
using System.Collections.Generic;

namespace Engine.Generation.Celestial
{
    public class CelestialBackground
    {
        private int _starts { get; }
        private int _width { get; }
        private int _height { get; }
        private List<BackgroundStar> _stars;

        public CelestialBackground(int startsCount, int sizeWidth, int sizeHeight)
        {
            _width = sizeWidth;
            _height = sizeHeight;
            _starts = startsCount;

            _stars = Generation(_starts, _width, _height);
        }


        public List<BackgroundStar> GetBackgroundStarts()
        {
            CalculateFlicker();

            return _stars.DeepClone();
        }

        private void CalculateFlicker()
        {
            foreach(var backgroundStar in _stars)
            {
                backgroundStar.Flick();
            }
        }

        private List<BackgroundStar> Generation(int startsCount, int sizeWidth, int sizeHeight)
        {
            List<BackgroundStar> result = new List<BackgroundStar>();

            for (int i = 0; i < startsCount; i++)
            {
                var newbackgroundStar = new BackgroundStar(RandomGenerator.GetInteger(1, sizeWidth), RandomGenerator.GetInteger(1, sizeHeight));

                result.Add(newbackgroundStar);
            }

            return result;
        }
    }
}
