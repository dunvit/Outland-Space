﻿using System.Drawing;
using OutlandSpaceClient.UI.Model;

namespace OutlandSpaceClient.UI.DrawEngine.TacticalMap
{
    public class BackGround
    {
        public static void Draw(Graphics graphics, IScreenInfo screenInfo)
        {
            try
            {
                graphics.FillRectangle(new SolidBrush(Color.Black), new RectangleF(0, 0, screenInfo.Width, screenInfo.Height));
            }
            catch
            {

            }
        }
    }
}