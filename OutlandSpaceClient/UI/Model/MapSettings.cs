
namespace OutlandSpaceClient.UI.Model
{
    public class MapSettings : IMapDrawSettings
    {
        public bool IsDrawCelestialObjectCoordinates { get; set; } = false;

        public bool IsDrawCelestialObjectDirections { get; set; } = true;

        public bool IsDrawSpaceshipInformation { get; set; } = true;

        public bool IsCenterOnSpaceship { get; set; } = true;
        public int Scale { get; private set; } = 1;

        public void ChangeScale(int delta)
        {
            if (delta > 0) ScaleIncrease();

            if (delta < 0) ScaleDecrease();
        }

        private void ScaleDecrease()
        {
            switch (Scale)
            {
                case 1:
                    Scale = 1;
                    break;

                case 5:
                    Scale = 1;
                    break;

                case 10:
                    Scale = 5;
                    break;
            }
        }

        private void ScaleIncrease()
        {
            switch (Scale)
            {
                case 1:
                    Scale = 5;
                    break;

                case 5:
                    Scale = 10;
                    break;

                case 10:
                    Scale = 10;
                    break;
            }
        }
    }
}