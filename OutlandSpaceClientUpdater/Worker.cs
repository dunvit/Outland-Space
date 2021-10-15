using System;
using log4net;
using System.Diagnostics;
using System.Reflection;
using OutlandSpaceCommon;
using Universe;
using Engine;
using Universe.Session;

namespace Updater
{
    public class Worker: IGameEvents
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IGameServer _gameServer;
        private IGameSessionData _session;

        public event Action<IGameSessionData> OnStartGame;
        public event Action<IGameSessionData> OnEndTurn;
        public event Action<IGameSessionData, int> OnEndTurnStep;

        public Worker()
        {
            _gameServer = new LocalGameServer();
        }

        public void SessionResume()
        {
            Logger.Info($"Game resumed. Turn is {_session.Turn}");

            _gameServer.ResumeSession(_session.Id);
        }

        public void SessionPause()
        {
            Logger.Info($"Game paused. Turn is {_session.Turn}");
        }

        public void StartNewGameSession()
        {
            _session = _gameServer.SessionInitialization(false, true);

            OnStartGame?.Invoke(_session);

            Scheduler.Instance.ScheduleTask(50, 50, GetDataFromServer, null);

            Scheduler.Instance.ScheduleTask(50, 50, RefreshSessionData, null);
        }

        private void RefreshSessionData()
        {
            if (_session is null) return;

            _session.Step++;

            OnEndTurnStep?.Invoke(_session, _session.Step);
        }

        private bool _inProgress;

        public void GetDataFromServer()
        {
            if (_inProgress) return;

            _inProgress = true;

            var timeMetricGetGameSession = Stopwatch.StartNew();

            var gameSession = _gameServer.RefreshGameSession(_session.Id);

            if (gameSession.Turn > _session.Turn)
            {
                OnEndTurn?.Invoke(gameSession);

                _session = gameSession;

                _session.Step = 0;
            }

            timeMetricGetGameSession.Stop();

            Logger.Debug($"Turn [{gameSession.Turn}] Get data from server is finished {timeMetricGetGameSession.Elapsed.TotalMilliseconds} ms.");

            if (gameSession.IsPause)
            {
                _inProgress = false;
                return;
            }

            _inProgress = false;
        }
    }
}
