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
        public event Action<IGameSessionData> OnRefreshLocations;
        public event Action<IGameSessionData, int> OnChangeChangeActiveObject;
        public event Action<IGameSessionData, int> OnChangeChangeSelectedObject;
        public event Action<IGameSessionData, int> OnEndTurnStep;

        public Worker()
        {
            _gameServer = new LocalGameServer();
        }

        public bool IsRunning()
        {
            return _session != null;
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

        public void StartNewGameSession(int ticks = 25)
        {
            _session = _gameServer.SessionInitialization(false, true);

            OnStartGame?.Invoke(_session);

            if (ticks <= 0) return;

            Scheduler.Instance.ScheduleTask(1, ticks, GetDataFromServer);
            Scheduler.Instance.ScheduleTask(1, ticks, RefreshLocations);
        }

        private void RefreshLocations()
        {
            var gameSession = _gameServer.RefreshGameSession(_session.Id);

            _session = gameSession;

            OnRefreshLocations?.Invoke(gameSession);

            Logger.Debug("Refresh Session Data. " +
                        $"Turn is {_session.Turn} " +
                        $"Step is {_session.Step} " +
                        $"Atomic results is {_session.CelestialObjects[1].PositionX:N2}");
        }

        private bool _inProgress;

        public void GetDataFromServer()
        {
            if (_inProgress) return;

            _inProgress = true;

            if (_session == null) throw new NullReferenceException();

            var timeMetricGetGameSession = Stopwatch.StartNew();

            var lastUpdateDateTime = _session.LastUpdate;

            var gameSession = _gameServer.RefreshGameSession(_session.Id);

            //gameSession.LastUpdate = DateTime.UtcNow;

            if (gameSession.Turn > _session.Turn)
            {
                var ms = (gameSession.LastUpdate - _session.LastUpdate).TotalMilliseconds ;

                Logger.Debug($"Last update is {ms} ms before. Server answear delay is {(DateTime.UtcNow - gameSession.ExecuteTime).TotalMilliseconds} ms.");

                OnEndTurn?.Invoke(gameSession);

                _session.Step = 0;

                Logger.Debug($"Turn [{gameSession.Turn}] Get data from server is finished {timeMetricGetGameSession.Elapsed.TotalMilliseconds} ms.");
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
