using System;
using System.Collections.Generic;
using Universe.Objects;
using Universe.Session;

namespace Engine.Sessions
{
    public class SessionFactory
    {
        public static IGameSession ProduceSession(int sessionId = -1)
        {
            if (sessionId == -1)
                return EmptySession();

            throw new NotImplementedException();
        }

        public static IGameSession GenerateBaseSession(CelestialMap celestialMap = null)
        {
            if(celestialMap is null)
            {
                celestialMap = new CelestialMap(new List<ICelestialObject>());
            }

            var result = new GameSession(celestialMap)
            {
                Id = OutlandSpaceCommon.RandomGenerator.GetId(),
                IsPause = true,
                IsValid = true,
                ScenarioName = "Base session scenario"
            };

            return result;
        }

        private static IGameSession EmptySession()
        {
            var result = new GameSession
            {
                Id = OutlandSpaceCommon.RandomGenerator.GetId(),
                IsPause = true,
                IsValid = true,
                ScenarioName = "Empty session scenario"
            };

            return result;
        }
    }
}