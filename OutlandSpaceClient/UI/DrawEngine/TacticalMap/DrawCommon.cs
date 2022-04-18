using System.Drawing;
using System.Drawing.Drawing2D;
using OutlandSpaceClient.Tools;
using OutlandSpaceClient.UI.Model;
using Universe.Geometry;
using Universe.Objects;

namespace OutlandSpaceClient.UI.DrawEngine.TacticalMap
{
    public class DrawCommon
    {
        public static void DrawBrokenLine(Graphics graphics, Color color, PointF center, int radius, int brokenLength, int direction, bool isArrow = false)
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

        public static void DrawArrow(Graphics graphics, SpaceMapVector line, Color color, int arrowSize = 4)
        {
            // Base arrow line
            graphics.DrawLine(new Pen(color), line.PointFrom.X, line.PointFrom.Y, line.PointTo.X, line.PointTo.Y);

            // Arrow left line
            var leftArrowLine = GeometryTools.MoveObject(line.PointTo, arrowSize, line.Direction + 150);
            graphics.DrawLine(new Pen(color), line.PointTo.X, line.PointTo.Y, leftArrowLine.X, leftArrowLine.Y);

            // Arrow right line
            var rightArrowLine = GeometryTools.MoveObject(line.PointTo, arrowSize, line.Direction - 150);
            graphics.DrawLine(new Pen(color), line.PointTo.X, line.PointTo.Y, rightArrowLine.X, rightArrowLine.Y);

            graphics.FillEllipse(new SolidBrush(Color.Coral), line.PointTo.X - 2, line.PointTo.Y - 2, 4, 4);
        }

        public static void DrawArrow(IScreenInfo screenInfo, ICelestialObject currentObject, Graphics graphics, Color color,int padding = 0, int arrowSize = 4)
        {
            var screenCoordinates = UiTools.ToScreenCoordinates(screenInfo, new PointF((float)currentObject.PositionX, (float)currentObject.PositionY));

            var startArrowPoint = GeometryTools.MoveObject(screenCoordinates, padding, currentObject.Direction);

            var endArrowPoint = GeometryTools.MoveObject(startArrowPoint, currentObject.Speed * 5, currentObject.Direction);

            DrawArrow(graphics, new SpaceMapVector(startArrowPoint, endArrowPoint, currentObject.Direction), color, arrowSize);
        }

        public static void DrawLongLine(IScreenInfo screenInfo, ICelestialObject currentObject, Graphics graphics, Color color)
        {
            var screenCoordinates = UiTools.ToScreenCoordinates(screenInfo, new PointF((float)currentObject.PositionX, (float)currentObject.PositionY));

            var line = new SpaceMapVector(
                screenCoordinates,
                GeometryTools.MoveObject(screenCoordinates, 4000, currentObject.Direction),
                currentObject.Direction);

            using var dashedPen = new Pen(color, 2) { DashStyle = DashStyle.DashDot };

            graphics.DrawLine(dashedPen, line.PointFrom.X, line.PointFrom.Y, line.PointTo.X, line.PointTo.Y);
        }
    }
}
