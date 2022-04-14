namespace OutlandSpaceCommon
{
    public record CelestialObjectRecord(int id, string name);

    public record CelestialObject(int id, CelestialObjectRecord Data);

    public class ExampleTest
    {
        public ExampleTest()
        {
            var element = new CelestialObjectRecord(100, "Bonny");

            var a = element.id;

            var elementComplex = new CelestialObject(101, element);

            var b = elementComplex.Data.id;
        }
    }
}