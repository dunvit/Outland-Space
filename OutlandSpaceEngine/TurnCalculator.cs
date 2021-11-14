using System;
using System.Reflection;
using Engine.DataProcessing;
using log4net;
using OutlandSpaceCommon;

namespace Engine
{
    public class TurnCalculator: ITurnCalculator
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly EngineSettings _engineSettings = new EngineSettings();

        public IGameSession Execute(IGameSession session, int turns)
        {
            if (turns <= 0)
            {
                // Pause or wrong turns value
                return new GameSession {IsValid = false};
            }

            // Run execute once in second
            var millesecondsAfterLastTurnExecution = (DateTime.UtcNow - session.LastUpdate).TotalMilliseconds;
            if (millesecondsAfterLastTurnExecution < 1000) 
            {
                // Recalculate celestial objects positions 10 times per second
                session = ExecuteMovement(session, 0.1);

                return session; 
            }

            for (var i = 0; i < turns; i++)
            {
                Logger.Debug($"Refresh Session Data. Turn is {session.Turn}");

                session = Execute(session);
            }

            session.LastUpdate = DateTime.UtcNow;
            session.ExecuteTime = DateTime.UtcNow;

            return session;
        }

        private IGameSession Execute(IGameSession session)
        {
            var processingData = session.DeepClone();

            processingData = new Commands().Execute(processingData, new EngineSettings());

            processingData.FinishTurn();

            return processingData.DeepClone();
        }

        private IGameSession ExecuteMovement(IGameSession session, double deltaInSeconds)
        {
            var processingData = session.DeepClone();

            processingData = new Coordinates().Recalculate(processingData, _engineSettings, deltaInSeconds);

            return processingData.DeepClone();
        }
    }

    
}
