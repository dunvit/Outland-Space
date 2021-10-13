using System;
using System.Collections.Generic;
using Universe.Objects;

namespace Universe.Session
{
    [Serializable]
    public class SessionDataDto: IGameSessionData
    {
        public int Id { get; set; }

        public int Turn { get; set; }

        public int Step { get; set; }

        public bool IsPause { get; set; }

        public string ScenarioName { get; set; }
        public bool IsValid { get; set; }

        public List<ICelestialObject> CelestialObjects { get; set; } = new List<ICelestialObject>();
    }
}
