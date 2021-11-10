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

        public IGameSession Recalculate(IGameSession gameSession, EngineSettings settings)
        {
            var updatedSession = gameSession.GetCelestialObjects();

            foreach (var celestialObject in updatedSession)
            {
                RecalculateGeneralObjectLocation(celestialObject, settings);
            }

            gameSession.ReplaceCelestialObjects(updatedSession);

            return gameSession;
        }

        private void RecalculateGeneralObjectLocation(ICelestialObject celestialObject, EngineSettings settings)
        {
            var position = GeometryTools.Move(
                new Point(celestialObject.PositionX, celestialObject.PositionY),
                celestialObject.Speed,
                celestialObject.Direction);

            Logger.Debug($"Object '{celestialObject.Name}' id='{celestialObject.Id}' moved from {celestialObject.GetLocation()} to {position}");

            celestialObject.PreviousPositionX = celestialObject.PositionX;
            celestialObject.PreviousPositionY = celestialObject.PositionY;

            celestialObject.PositionX = position.X;
            celestialObject.PositionY = position.Y;
        }

        
    }
}