using System;

namespace Engine
{
    public class SessionFactory
    {
        public static IGameSession ProduceSession(int sessionId = -1)
        {
            if (sessionId == -1)
                return EmptySession();

            throw new NotImplementedException();
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