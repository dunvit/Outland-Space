using System;
using Engine.DataProcessing;
using OutlandSpaceCommon;

namespace Engine
{
    public class TurnCalculator: ITurnCalculator
    {
        private readonly EngineSettings _engineSettings = new EngineSettings();

        public IGameSession Execute(IGameSession session, int turns)
        {
            if (turns <= 0)
            {
                // Pause or wrong turns value
                return new GameSession {IsValid = false};
            }

            // Run execute once in second
            if ((DateTime.Now - session.LastUpdate).TotalMilliseconds < 1000) return session;

            for (var i = 0; i < turns; i++)
            {
                session = Execute(session);
            }

            session.LastUpdate = DateTime.Now;

            return session;
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
