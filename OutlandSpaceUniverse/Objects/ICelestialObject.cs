
namespace Universe.Objects
{
    public interface ICelestialObject
    {
        int Id { get; set; }
        string Name { get; set; }
        double Direction { get; set; }
        double Speed { get; }
        double PositionX { get; set; }
        double PositionY { get; set; }

        CelestialObjectTypes Type { get; set; }
    }
}
