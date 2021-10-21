﻿namespace OutlandSpaceClient.UI.Model
{
    public interface IMapDrawSettings
    {
        bool IsDrawCelestialObjectCoordinates { get; set; }

        bool IsDrawCelestialObjectDirections { get; set; }

        bool IsDrawSpaceshipInformation { get; set; }

        bool IsCenterOnSpaceship { get; set; }
    }
}