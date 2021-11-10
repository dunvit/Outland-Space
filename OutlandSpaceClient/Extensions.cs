using System;
using System.Drawing;
using System.Reflection;
using log4net;
using Universe.Geometry;
using Universe.Objects;

namespace OutlandSpaceClient
{
    public static class Extensions
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public static PointF Location(this ICelestialObject celestialObject, DateTime lastUpdate)
        {
            var ms = (DateTime.UtcNow - lastUpdate).TotalMilliseconds / 1000;

            var location = GeometryTools.RecalculateAtomicObjectLocation(celestialObject, ms);

            return new PointF((float)location.X, (float)location.Y);
        }


        public static PointF Location(this ICelestialObject celestialObject, int turn, int step)
        {
            if (step == 0) return Finalization(celestialObject, turn, step, new PointF((float)celestialObject.PositionX, (float)celestialObject.PositionY));

            if (celestialObject.AtomicLocation.Count == 0) return Finalization(celestialObject, turn, step, new PointF((float)celestialObject.PositionX, (float)celestialObject.PositionY));

            if (celestialObject.AtomicLocation.Count <= step)
                return Finalization(celestialObject, turn, step, new PointF((float)celestialObject.AtomicLocation[celestialObject.AtomicLocation.Count - 1].Item2.X, (float)celestialObject.AtomicLocation[celestialObject.AtomicLocation.Count - 1].Item2.Y));

            if (celestialObject.AtomicLocation.Count > step)
            {
                return Finalization(celestialObject, turn, step, new PointF((float)celestialObject.AtomicLocation[step].Item2.X, (float)celestialObject.AtomicLocation[step].Item2.Y));
            }

            return Finalization(celestialObject, turn, step, new PointF((float)celestialObject.PositionX, (float)celestialObject.PositionY)); ;
        }

        private static PointF Finalization(ICelestialObject celestialObject, int turn, int step, PointF point)
        {
            Logger.Debug($"[Location turn {turn} step {step}] AtomicLocation count is {celestialObject.AtomicLocation.Count} Position x is {point.X}");

            return point;
        }
    }
}