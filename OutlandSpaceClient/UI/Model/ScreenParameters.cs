﻿using System.Drawing;

namespace OutlandSpaceClient.UI.Model
{
    public class ScreenParameters : IScreenInfo
    {
        public PointF Center { get; }
        public float Width { get; }
        public float Height { get; }
        public int DrawInterval { get; set; }
        public PointF CenterScreenOnMap { get; set; }
        public Graphics GraphicSurface { get; set; }
        public IMapDrawSettings Settings { get; set; } = new MapSettings();
        public Point ControlActiveCelestialObjectLocation { get; set; }
        public int ActiveCelestialObjectId { get; set; }

        public ScreenParameters(float width, float height, int centerScreenX = 10000, int centerScreenY = 10000)
        {
            Center = new PointF(width / 2, height / 2);

            // Start player ship coordinates in each battle (10000, 10000)
            CenterScreenOnMap = new PointF(centerScreenX, centerScreenY);

            Width = width;
            Height = height;
        }

        public RectangleF VisibleScreen()
        {
            return new RectangleF(CenterScreenOnMap.X - Width / 2,
                CenterScreenOnMap.Y - Height / 2,
                Width, Height);
        }

        public bool PointInVisibleScreen(float x, float y)
        {
            return VisibleScreen().Contains((int)x, (int)y);
        }

        public bool PointInVisibleScreen(PointF point)
        {
            return VisibleScreen().Contains((int)point.X, (int)point.Y);
        }
    }
}