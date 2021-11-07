using OutlandSpaceCommon;
using System;
using System.Drawing;

namespace Engine.Generation.Celestial
{
    [Serializable]
    public class BackgroundStar
    {
        public Universe.Geometry.Point Location { get; }

        private Color _baseColor = Color.FromArgb(60, 60, 60);
        public Color Color { get; set; } = Color.FromArgb(0, 0, 0);

        const int _flickRange = 20;

        public BackgroundStar(int x, int y)
        {
            Location = new Universe.Geometry.Point(x, y);            
        }

        public void Flick()
        {
            Color = Color.FromArgb(
                RandomGenerator.GetInteger(_baseColor.R - _flickRange, _baseColor.R + _flickRange),
                RandomGenerator.GetInteger(_baseColor.G - _flickRange, _baseColor.G + _flickRange),
                RandomGenerator.GetInteger(_baseColor.B - _flickRange, _baseColor.B + _flickRange)
                );
        }
    }
}
