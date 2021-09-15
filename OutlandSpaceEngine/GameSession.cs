﻿using Engine.Generation;
using Universe.Session;

namespace Engine
{
    public class GameSession: IGameSession
    {
        public int Id { get; set; }
        public int Turn { get; set; }
        public bool IsPause { get; set; }
        public string ScenarioName { get; set; }
        public CelestialMap SpaceMap { get; set; }

        public GameSession()
        {
            SpaceMap = GlobalSpaceMap.GenerateEmpty();
        }

        public IGameSessionData Export()
        {
            return new SessionDataDto
            {
                Id = Id,
                Turn = Turn,
                IsPause = IsPause,
                ScenarioName = ScenarioName
            };
        }
    }
}