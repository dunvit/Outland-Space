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

        private List<int> _runnedSessions = new List<int>();

        public IGameSession CloneSession(int sessionId)
        {
            return _sessions.Get(sessionId).DeepClone();
        }

        public IGameSessionData RefreshGameSession(int sessionId)
        {
            Validation(sessionId);

            return _sessions.Get(sessionId).Export();
        }

        public void ResumeSession(int sessionId)
        {
            Validation(sessionId);

            _runnedSessions.Add(sessionId);

            ExecuteTurnCalculation();
        }

        public void PauseSession(int sessionId)
        {
            Validation(sessionId);

            _runnedSessions.Remove(sessionId);
        }

        public void Command(int sessionId, string command)
        {
            Validation(sessionId);

            _sessions.Get(sessionId).AddCommand(1, command);
        }

        public int GetTurn(int sessionId)
        {
            Validation(sessionId);

            return _sessions.Get(sessionId).Turn;
        }

        public IGameSessionData SessionInitialization(bool debug = false, bool isGenerateStartMap = false, int sessionId = -1)
        {
            var session = SessionFactory.ProduceSession(sessionId);

            if(isGenerateStartMap) session.GenerateDebugSpaceMap();

            _sessions.Set(session);

            if(debug is false)
                Scheduler.Instance.ScheduleTask(50, 50, ExecuteTurnCalculation);

            return session.Export();
        }

        private bool isDebug;
        private bool isExecute;

        private void ExecuteTurnCalculation()
        {
            if(isExecute) return;

            isExecute = true;

            foreach (var session in _sessions.GetAll())
            {
                // TODO: Refactor update session pause status
                session.IsPause = !_runnedSessions.Contains(session.Id);

                if (session.IsPause) continue;
                if (isDebug) continue;

                Execute(session.Id);
            }

            isExecute = false;
        }

        public IGameSessionData Execute(int sessionId, int turns = 1)
        {
            Validation(sessionId);

            isDebug = true;

            var session = _sessions.Get(sessionId).DeepClone();

            _sessionLock.EnterWriteLock();
            session.Block();

            var result = new TurnCalculator().Execute(session, turns);            

            _sessions.Update(result);

            session.UnBlock();
            _sessionLock.ExitWriteLock();

            isDebug = false;

            return result.Export();
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
