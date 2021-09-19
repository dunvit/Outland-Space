using System;
using Engine.Generation;
using Universe.Session;

namespace Engine
{
    [Serializable]
    public class GameSession: IGameSession
    {
        public int Id { get; set; }
        public int Turn { get; private set; }
        public bool IsPause { get; set; }
        public string ScenarioName { get; set; }
        public bool IsValid { get; set; } = true;
        public CelestialMap SpaceMap { get; set; }

        public GameSession()
        {
            Turn = 1;
            SpaceMap = GlobalSpaceMap.GenerateEmpty();
        }

        public void FinishTurn()
        {
            Turn++;
        }

        public IGameSessionData Export()
        {
            return new SessionDataDto
            {
                Id = Id,
                Turn = Turn,
                IsPause = IsPause,
                ScenarioName = ScenarioName,
                IsValid = IsValid
            };
        }
    }
}