using Engine.Generation.Celestial;
using OutlandSpaceClient.UI.Model;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using Universe.Session;

namespace OutlandSpaceClient.UI.DrawEngine.TacticalMap
{
    public class Draw
    {
        public static void DrawTacticalMapScreen(Image image, IScreenInfo screenParameters, IGameSessionData session, CelestialBackground _celestialBackground, int currentFrameRate)
        {
            var graphics = Graphics.FromImage(image);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            // TODO: Calculate celestial object position by timespan instead of frame 
            // recalculate frame number for draw process 

            DrawStartFlicker.Execute(graphics, session, screenParameters, _celestialBackground);

            DrawCelestialObjects.Execute(graphics, session, screenParameters, currentFrameRate);
        }

        public static void DrawBaseTacticalMapScreen(Image image, IScreenInfo screenParameters, IGameSessionData session, CelestialBackground celestialBackground)
        {
            var graphics = Graphics.FromImage(image);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            DrawGridBackGround.Execute(graphics, screenParameters);

            DrawGrid.Execute(graphics, screenParameters);

            DrawStartFlicker.Execute(graphics, session, screenParameters, celestialBackground);
        }
    }
}
