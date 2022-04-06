using Universe.Geometry;
using Universe.Objects;
using Universe.Objects.Points;

namespace Engine.Generation
{
    public interface ICelestialObjectBuilder
    {
        ICelestialObjectBuilder BuildLocation(SpacePoint centerMap, int radius);

        ICelestialObjectBuilder BuildLocation(Point location);

        ICelestialObjectBuilder BuildNavigation();

        ICelestialObjectBuilder BuildGeneralData();

        ICelestialObject Build();
    }
}