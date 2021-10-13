using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using log4net;
using OutlandSpaceCommon;
using Universe.Geometry;
using Universe.Objects;
using Point = Universe.Geometry.Point;

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
            var position = GeometryTools.MoveObject(
                new PointF((float) celestialObject.PositionX, (float) celestialObject.PositionY),
                celestialObject.Speed,
                celestialObject.Direction);


            Logger.Debug($"Object '{celestialObject.Name}' id='{celestialObject.Id}' moved from {celestialObject.GetLocation()} to {position}");

            celestialObject.PreviousPositionX = celestialObject.PositionX;
            celestialObject.PreviousPositionY = celestialObject.PositionY;

            celestialObject.PositionX = position.X;
            celestialObject.PositionY = position.Y;

            celestialObject.AtomicLocation = new List<Tuple<int, Point>>();

            var speedInTick = celestialObject.Speed / settings.UnitsPerSecond;

            var currentAtomicPosition = new Point(celestialObject.PositionX, celestialObject.PositionY);

            // Initial turn position
            celestialObject.AtomicLocation.Add(new Tuple<int, Point>(0, new Point(currentAtomicPosition.X, currentAtomicPosition.Y)));

            for (var i = 1; i <= settings.UnitsPerSecond; i++)
            {
                currentAtomicPosition = GeometryTools.Move(
                    currentAtomicPosition,
                    speedInTick,
                    celestialObject.Direction);

                celestialObject.AtomicLocation.Add(new Tuple<int, Point>( i, new Point(currentAtomicPosition.X, currentAtomicPosition.Y)));
            }
        }
    }
}