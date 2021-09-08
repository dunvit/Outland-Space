using System;

namespace Universe.Session
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
            return new GameSession
            {
                Id = OutlandSpaceCommon.RandomGenerator.GetId(),
                Turn = 1,
                IsPause = true,
                ScenarioName = "Empty session scenario"
            };
        }
    }
}