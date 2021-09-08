using System;

namespace Universe.Session
{
    public class SessionFactory
    {
        public static IGameSessionData ProduceSession(int sessionId = -1)
        {
            if (sessionId == -1)
                return EmptySession();

            throw new NotImplementedException();
        }

        private static IGameSessionData EmptySession()
        {
            return new SessionDataDto
            {
                Id = OutlandSpaceCommon.RandomGenerator.GetId(),
                Turn = 1,
                IsPause = true,
                ScenarioName = "Empty session scenario"
            };
        }
    }
}