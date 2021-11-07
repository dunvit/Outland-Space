using Engine.Generation.Celestial;
using OutlandSpaceClient.UI.Model;
using System.Drawing;
using Universe.Session;

namespace OutlandSpaceClient.UI.DrawEngine.TacticalMap
{
    public class DrawStartFlicker
    {
        public static void Execute(Graphics graphics, IGameSessionData session, IScreenInfo screenInfo, CelestialBackground frame)
        {
            try
            {
                foreach (var star in frame.GetBackgroundStarts())
                {
                    graphics.FillRectangle(new SolidBrush(star.Color), new RectangleF((float)star.Location.X, (float)star.Location.Y, 2, 2));
                }
            }
            catch
            {

            }
        }
    }
}
