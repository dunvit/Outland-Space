using Engine.DataProcessing;
using OutlandSpaceCommon;
using Universe.Session;

namespace Engine
{
    public class TurnCalculator: ITurnCalculator
    {
        private readonly EngineSettings _engineSettings = new EngineSettings();

        public IGameSessionData Execute(IGameSession session, int turns)
        {
            if (turns <= 0)
            {
                // Pause or wrong turns value
                return new SessionDataDto{IsValid = false};
            }

            for (var i = 0; i < turns; i++)
            {
                session = Execute(session);
            }

            return session.Export();
        }

        private IGameSession Execute(IGameSession session)
        {
            var processingData = session.DeepClone();

            processingData = new Coordinates().Recalculate(processingData, _engineSettings);

            processingData.FinishTurn();

            return processingData.DeepClone();
        }
    }

    
}
