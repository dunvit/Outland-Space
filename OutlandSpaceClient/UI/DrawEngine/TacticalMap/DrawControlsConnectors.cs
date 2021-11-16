using System.Drawing;
using OutlandSpaceClient.Tools;
using Universe.Geometry;
using Universe.Session;

namespace OutlandSpaceClient.UI.DrawEngine.TacticalMap
{
    public class DrawControlsConnectors
    {
        public static void Execute(Graphics graphics, IGameSessionData session, GameState gameState)
        {
            var celestialObject = session.GetCelestialObject(gameState.ScreenInfo.ActiveCelestialObjectId);

            if (celestialObject is null) return;

            var screenCoordinates = UiTools.ToScreenCoordinates(gameState.ScreenInfo, celestialObject.Location(session));
            var panelScreenLocation = gameState.ScreenInfo.ControlActiveCelestialObjectLocation;

            var pen = new Pen(Color.Gray);

            var distance = GeometryTools.Distance(panelScreenLocation, screenCoordinates);
            var direction = GeometryTools.Azimuth(screenCoordinates, panelScreenLocation);

            var destinationPoint = GeometryTools.MoveObject(panelScreenLocation, distance - 15, direction);

            graphics.DrawLine(pen, panelScreenLocation.X, panelScreenLocation.Y, destinationPoint.X, destinationPoint.Y);

            graphics.DrawEllipse(pen, screenCoordinates.X - 15, screenCoordinates.Y - 15, 30, 30);
        }
    }
}
