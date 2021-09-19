using OutlandSpaceCommon;
using Universe.Session;

namespace Engine
{
    public class TurnCalculator: ITurnCalculator
    {
        public IGameSessionData Execute(IGameSession session, int turns)
        {
            if(turns <= 0)
            {
                // Pause or wrong turns value
                return new SessionDataDto{IsValid = false};
            }

            session = Execute(session);

            return session.Export();
        }

        private IGameSession Execute(IGameSession session)
        {
            session.FinishTurn();

            return session.DeepClone();
        }
    }

    
}
