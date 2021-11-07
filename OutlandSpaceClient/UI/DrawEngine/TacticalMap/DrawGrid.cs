using System;
using System.Drawing;
using OutlandSpaceClient.Tools;
using OutlandSpaceClient.UI.Model;

namespace OutlandSpaceClient.UI.DrawEngine.TacticalMap
{
    public class DrawGrid
    {
        public static void Execute(Graphics graphics, IScreenInfo screenInfo)
        {
            try
            {
                double xLeftPosition = screenInfo.CenterScreenOnMap.X - screenInfo.Center.X;
                double yLeftPosition = screenInfo.CenterScreenOnMap.Y - screenInfo.Center.Y;

                DrawGridByStep(graphics, screenInfo, xLeftPosition, yLeftPosition, 10, Color.FromArgb(8, 8, 8));
                DrawGridByStep(graphics, screenInfo, xLeftPosition, yLeftPosition, 100, Color.FromArgb(18, 18, 18));
            }
            catch
            {

            }
        }

        private static void DrawGridByStep(Graphics graphics, IScreenInfo screenInfo, double xLeftPosition, double yLeftPosition, int step, Color color)
        {
            var smallGridPen = new Pen(color);

            const int offsetX = 400;
            const int offsetY = 400;

            var leftCornerX = (int)Math.Round(xLeftPosition / step) * step - offsetX;
            var leftCornerY = (int)Math.Round(yLeftPosition / step) * step - offsetY;

            for (var i = leftCornerX;
                i < screenInfo.CenterScreenOnMap.X + screenInfo.Center.X + offsetX * 2;
                i += step)
            {
                var lineFrom = UiTools.ToScreenCoordinates(screenInfo, new PointF(i, leftCornerY));
                var lineTo = UiTools.ToScreenCoordinates(screenInfo, new PointF(i, leftCornerY + screenInfo.Height + offsetY));


                graphics.DrawLine(smallGridPen, lineFrom.X, lineFrom.Y, lineTo.X, lineTo.Y);
            }

            for (var i = leftCornerY;
                i < screenInfo.CenterScreenOnMap.Y + screenInfo.Center.Y + offsetY * 2;
                i += step)
            {
                var lineFrom = UiTools.ToScreenCoordinates(screenInfo, new PointF(leftCornerX, i));
                var lineTo = UiTools.ToScreenCoordinates(screenInfo, new PointF(leftCornerX + screenInfo.Width + offsetX * 2, i));

                graphics.DrawLine(smallGridPen, lineFrom.X, lineFrom.Y, lineTo.X, lineTo.Y);
            }
        }
    }
}