using System;
using System.Collections.Generic;
using System.Threading;
using Engine.Sessions;
using OutlandSpaceCommon;
using Universe;
using Universe.Session;

namespace Engine
{
    public class LocalGameServer: IGameServer
    {
        private readonly ISessionsCollection _sessions = new SessionsCollection();

        private readonly ReaderWriterLockSlim _sessionLock = new ReaderWriterLockSlim();

        private readonly List<int> _runningSessions = new List<int>();

        public IGameSession CloneSession(int sessionId)
        {
            return _sessions.Get(sessionId).DeepClone();
        }

        public IGameSessionData RefreshGameSession(int sessionId)
        {
            Validation(sessionId);

            return _sessions.Get(sessionId).ToGameSession();
        }

        public void ResumeSession(int sessionId)
        {
            Validation(sessionId);

            _runningSessions.Add(sessionId);

            ExecuteTurnCalculation();
        }

        public void PauseSession(int sessionId)
        {
            Validation(sessionId);

            _runningSessions.Remove(sessionId);
        }

        public void Command(int sessionId, string command)
        {
            Validation(sessionId);

            _sessions.Get(sessionId).AddCommand(RandomGenerator.GetId(), command);
        }

        public int GetTurn(int sessionId)
        {
            Validation(sessionId);

            return _sessions.Get(sessionId).Turn;
        }

        public IGameSessionData SessionInitialization(IGameSessionData session, bool debug = false)
        {
            var gameSession = new GameSession(session);

            _sessions.Set(gameSession.DeepClone());

            if (debug is false)
                Scheduler.Instance.ScheduleTask(50, 50, ExecuteTurnCalculation);

            return gameSession.ToGameSession();
        }

        public IGameSessionData SessionInitialization(bool debug = false, bool isGenerateStartMap = false, int sessionId = -1)
        {
            var session = SessionFactory.ProduceSession(sessionId);

            if(isGenerateStartMap) session.GenerateDebugSpaceMap();

            return SessionInitialization(session.ToGameSession(), debug);
        }

        private bool _isDebug;
        private bool _isExecute;

        private void ExecuteTurnCalculation()
        {
            if(_isExecute) return;

            _isExecute = true;

            foreach (var session in _sessions.GetAll())
            {
                // TODO: Refactor update session pause status
                session.IsPause = !_runningSessions.Contains(session.Id);

                if (session.IsPause) continue;
                if (_isDebug) continue;

                Execute(session.Id);
            }

            _isExecute = false;
        }

        public IGameSessionData Execute(int sessionId, int turns = 1)
        {
            Validation(sessionId);

            _isDebug = true;

            var session = _sessions.Get(sessionId).DeepClone();

            _sessionLock.EnterWriteLock();
            session.Block();

            var result = new TurnCalculator().Execute(session, turns);            

            _sessions.Update(result);

            session.UnBlock();
            _sessionLock.ExitWriteLock();

            _isDebug = false;

            return result.ToGameSession();
        }

        private void Validation(int sessionId)
        {
            if (_sessions.IsExists(sessionId) == false)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
