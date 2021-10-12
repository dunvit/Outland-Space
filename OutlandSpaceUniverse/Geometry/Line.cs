using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Universe.Geometry
{
    public class Line
    {
        public PointF From { get; set; }

        public PointF To { get; set; }

        public Line(PointF from, PointF to)
        {
            From = from;
            To = to;
        }
    }
}
