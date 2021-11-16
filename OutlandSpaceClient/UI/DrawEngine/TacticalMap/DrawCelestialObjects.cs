using System.Drawing;
using System.Reflection;
using log4net;
using OutlandSpaceClient.Tools;
using OutlandSpaceClient.UI.Model;
using Universe.Objects;
using Universe.Session;

namespace OutlandSpaceClient.UI.DrawEngine.TacticalMap
{
    public class DrawCelestialObjects
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static void Execute(Graphics graphics, IGameSessionData session, IScreenInfo screenInfo, int frame)
        {
            foreach (var currentObject in session.CelestialObjects)
            {
                switch (currentObject.Type)
                {
                    case CelestialObjectTypes.Missile:
                        DrawMissile(graphics, session, screenInfo, currentObject);
                        break;
                    case CelestialObjectTypes.SpaceshipPlayer:
                        DrawSpaceship(graphics, session, screenInfo, currentObject);
                        break;
                    case CelestialObjectTypes.SpaceshipNpcNeutral:
                        DrawSpaceship(graphics, session, screenInfo, currentObject);
                        break;
                    case CelestialObjectTypes.SpaceshipNpcEnemy:
                        DrawSpaceship(graphics, session, screenInfo, currentObject);
                        break;
                    case CelestialObjectTypes.SpaceshipNpcFriend:
                        DrawSpaceship(graphics, session, screenInfo, currentObject);
                        break;
                    case CelestialObjectTypes.Asteroid:
                        DrawAsteroid(graphics, session, screenInfo, currentObject, frame);
                        break;
                    case CelestialObjectTypes.Explosion:
                        break;
                }
            }
        }

        private static void DrawMissile(Graphics graphics, IGameSessionData session, IScreenInfo screenInfo, ICelestialObject celestialObject)
        {

        }

        private static void DrawAsteroid(Graphics graphics, IGameSessionData session, IScreenInfo screenInfo, ICelestialObject celestialObject, int frame)
        {
            var screenCoordinates = UiTools.ToScreenCoordinates(screenInfo, celestialObject.Location(session));

            var color = Color.Gray;

            graphics.FillEllipse(new SolidBrush(color), screenCoordinates.X - 2, screenCoordinates.Y - 2, 4, 4);
            graphics.DrawEllipse(new Pen(color), screenCoordinates.X - 4, screenCoordinates.Y - 4, 8, 8);

            Logger.Debug($"Turn: {session.Turn} Frame: {frame} Location: {screenCoordinates}");
        }

        private static void DrawSpaceship(Graphics graphics, IGameSessionData session, IScreenInfo screenInfo, ICelestialObject spaceShip)
        {
            var screenCoordinates = UiTools.ToScreenCoordinates(screenInfo, spaceShip.Location(session));
            var ship = spaceShip;
            var color = Color.Black;

            switch (ship.Type)
            {
                case CelestialObjectTypes.SpaceshipPlayer:
                    color = Color.DarkOliveGreen;
                    break;

                case CelestialObjectTypes.SpaceshipNpcEnemy:
                    color = Color.DarkRed;
                    break;

                case CelestialObjectTypes.SpaceshipNpcFriend:
                    color = Color.SeaGreen;
                    break;

                case CelestialObjectTypes.SpaceshipNpcNeutral:
                    color = Color.DarkGray;
                    break;
            }

            graphics.FillEllipse(new SolidBrush(color), screenCoordinates.X - 2, screenCoordinates.Y - 2, 4, 4);
            graphics.DrawEllipse(new Pen(color), screenCoordinates.X - 4, screenCoordinates.Y - 4, 8, 8);
        }
    }
}