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
        public static void DrawTacticalMapScreen(Image image, GameState state, IGameSessionData session, CelestialBackground _celestialBackground, int currentFrameRate)
        {
            var graphics = Graphics.FromImage(image);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            DrawStartFlicker.Execute(graphics, session, state.ScreenInfo, _celestialBackground);

            DrawCelestialObjects.Execute(graphics, session, state.ScreenInfo, currentFrameRate);

            DrawControlsConnectors.Execute(graphics, session, state);
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
