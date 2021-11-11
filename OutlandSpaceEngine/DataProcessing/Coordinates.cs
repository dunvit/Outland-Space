using System;
using System.Collections.Generic;
using System.Reflection;
using log4net;
using OutlandSpaceCommon;
using Universe.Geometry;
using Universe.Objects;

namespace Engine.DataProcessing
{
    public class Coordinates
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IGameSession Recalculate(IGameSession gameSession, EngineSettings settings, double ticks = 1)
        {
            var updatedSession = gameSession.GetCelestialObjects();

            foreach (var celestialObject in updatedSession)
            {
                RecalculateGeneralObjectLocation(gameSession, celestialObject, settings, ticks);
            }

            gameSession.ReplaceCelestialObjects(updatedSession);

            gameSession.ExecuteTime = DateTime.UtcNow;

            return gameSession;
        }

        private void RecalculateGeneralObjectLocation(IGameSession gameSession, ICelestialObject celestialObject, EngineSettings settings, double ticks = 1)
        {
            var position = GeometryTools.Move(
                new Point(celestialObject.PositionX, celestialObject.PositionY),
                celestialObject.Speed * ticks,
                celestialObject.Direction);

            if (celestialObject.Id == 1000000001)
                Logger.Debug($"Spaceship moved from {celestialObject.GetLocation().X:N2} to {position.X:N2}");

            Logger.Debug($"Object '{celestialObject.Name}' id='{celestialObject.Id}' moved from {celestialObject.GetLocation()} to {position}");

            celestialObject.PreviousPositionX = celestialObject.PositionX;
            celestialObject.PreviousPositionY = celestialObject.PositionY;

            celestialObject.PositionX = position.X;
            celestialObject.PositionY = position.Y;

            celestialObject.LastUpdate = DateTime.UtcNow;
        }

        
    }
}