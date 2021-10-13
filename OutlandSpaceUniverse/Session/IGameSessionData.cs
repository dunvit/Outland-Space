
using System.Collections.Generic;
using Universe.Objects;

namespace Universe.Session
{
    public interface IGameSessionData
    {
        int Id { get; set; }

        int Turn { get;}

        int Step { get; set; }

        bool IsPause { get; set; }

        string ScenarioName { get; set; }

        List<ICelestialObject> CelestialObjects { get; set; }

        bool IsValid { get; set; }
    }
}