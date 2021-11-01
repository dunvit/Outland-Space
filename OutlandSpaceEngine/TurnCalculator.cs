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
            if ((DateTime.Now - session.LastUpdate).TotalMilliseconds < 1000) return session;

            for (var i = 0; i < turns; i++)
            {
                Logger.Debug($"Refresh Session Data. Turn is {session.Turn}");

                session = Execute(session);
            }

            session.LastUpdate = DateTime.Now;

            return session;
        }

        private IGameSession Execute(IGameSession session)
        {
            var processingData = session.DeepClone();

            var sessionAfterCoordinatesRecalculate = new Coordinates().Recalculate(processingData, _engineSettings);

            var sessionAfterCommandsExecute = new Commands().Execute(sessionAfterCoordinatesRecalculate, new EngineSettings());

            processingData = sessionAfterCommandsExecute;

            processingData.FinishTurn();

            return processingData.DeepClone();
        }
    }

    
}
