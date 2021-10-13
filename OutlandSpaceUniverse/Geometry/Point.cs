using System;

namespace Universe.Geometry
{
    [Serializable]
    public class Point
    {
        public double X { get; set; }

        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public bool IsEqualTo(Point point)
        {
            return (Math.Abs(point.X - X) < 0.001 && Math.Abs(point.Y - Y) < 0.001);
        }
    }
}
