using OutlandSpaceCommon;
using Universe.Geometry;
using Universe.Objects;
using Universe.Objects.Points;

namespace Engine.Generation
{
    public class CelestialObjectBuilder: ICelestialObjectBuilder
    {
        private readonly ICelestialObject _celestialObject;


        public CelestialObjectBuilder(ICelestialObject celestialObject)
        {
            _celestialObject = celestialObject;
        }

        public ICelestialObjectBuilder BuildLocation(SpacePoint centerMap, int radius)
        {
            _celestialObject.PositionX = RandomGenerator.GetDouble(centerMap.X - radius, centerMap.X + radius);
            _celestialObject.PositionY = RandomGenerator.GetDouble(centerMap.Y - radius, centerMap.Y + radius);

            return this;
        }

        public ICelestialObjectBuilder BuildLocation(Point location)
        {
            _celestialObject.PositionX = location.X;
            _celestialObject.PositionY = location.Y;
            
            return this;
        }

        public ICelestialObjectBuilder BuildNavigation()
        {
            _celestialObject.Direction = RandomGenerator.GetDouble(0, 359.99);
            _celestialObject.Speed = RandomGenerator.GetDouble(0, 50);

            return this;
        }

        public ICelestialObjectBuilder BuildGeneralData()
        {
            _celestialObject.Id = RandomGenerator.GetId();
            _celestialObject.Name = RandomGenerator.GenerateCelestialObjectName();
            return this;
        }

        public ICelestialObject Build()
        {
            return _celestialObject;
        }
    }
}