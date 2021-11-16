using System.Drawing;
using OutlandSpaceClient.UI.Model;
using Universe.Geometry;

namespace OutlandSpaceClient.UI.DrawEngine.TacticalMap
{
    public class DrawCommon
    {
        public static void DrawBrokenLine(Graphics graphics, Color color, PointF center, int radius, int brokenLength, int direction, IScreenInfo screenInfo)
        {
            var pen = new Pen(color);

            var externalLine = CalculateLineByAngle(center, direction, radius);
            var internalLine = CalculateLineByAngle(center, direction, brokenLength);

            graphics.DrawLine(pen, externalLine.To, internalLine.To);

            graphics.DrawLine(pen, externalLine.From, internalLine.From);
        }

        public static Line CalculateLineByAngle(PointF center, float direction, float length)
        {
            var result = new Line(
                GeometryTools.MoveObject(center, length, direction.To360Degrees()),
                GeometryTools.MoveObject(center, length, (direction - 180).To360Degrees())
            );

            return result;
        }
    }
}
