using System;
using System.Reflection;
using log4net;
using OutlandSpaceClient.Tools;
using Universe.Geometry;
using Universe.Session;
using Updater;

namespace OutlandSpaceClient
{
    public class GameManager: IGameManager
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        public event Action<IGameSessionData> OnStartGame;
        public event Action<IGameSessionData> OnEndTurn;
        public event Action<IGameSessionData> OnRefreshLocations;
        public event Action<IGameSessionData, int> OnEndTurnStep;
        public event Action<IGameSessionData, int> OnChangeChangeActiveObject;
        public event Action<IGameSessionData, int> OnChangeChangeSelectedObject;

        public event Action<Point> OnMouseMove;

        public GameState State { get; set; }
        private readonly OuterSpace _outerSpace;

        private readonly Worker _worker;
        

        public GameManager(Worker worker)
        {
            State = new GameState();

            _outerSpace = new OuterSpace();
            _outerSpace.OnChangeActiveObject += Event_ChangeActiveObject;
            _outerSpace.OnChangeSelectedObject += Event_ChangeSelectedObject;

            _worker = worker;
            _worker.OnEndTurn += Event_EndTurn;
            _worker.OnEndTurnStep += Event_EndTurnStep;
            _worker.OnStartGame += Event_StartGame;
            _worker.OnRefreshLocations += Event_RefreshLocations;
        }

        private void Event_ChangeSelectedObject(int celestialObjectId)
        {
            OnChangeChangeSelectedObject?.Invoke(State.GetGameSession(), celestialObjectId);
        }

        private void Event_ChangeActiveObject(int celestialObjectId)
        {
            if (celestialObjectId == 0) return;

            State.SetActiveCelestialObject(celestialObjectId);

            OnChangeChangeActiveObject?.Invoke(State.GetGameSession(), celestialObjectId);
        }


        public void RefreshOuterSpace(Point coordinates, MouseArguments type)
        {
            _outerSpace.Refresh(State.GetGameSession(), coordinates, type);

            if (type == MouseArguments.RightClick)
            {
                State.ScreenInfo.ActiveCelestialObjectId = 0;
                _outerSpace.ClearActiveObject();
                OnChangeChangeActiveObject?.Invoke(State.GetGameSession(), 0);
            }

            OnMouseMove?.Invoke(coordinates);
        }

        private void Event_RefreshLocations(IGameSessionData session)
        {
            State.SetSession(session);
            OnRefreshLocations?.Invoke(session);
        }

        private void Event_StartGame(IGameSessionData session)
        {
            State.SetSession(session);
            OnStartGame?.Invoke(session);
        }

        public void StartGameSession()
        {
            _worker.StartNewGameSession();
        }

        public void SessionResume()
        {
            _worker.SessionResume();
        }

        private void Event_EndTurnStep(IGameSessionData session, int step)
        {
            Logger.Debug($"[EndTurn] session.Id = {session.Id} session.Turn = {session.Turn}");

            State.SetSession(session);

            OnEndTurnStep?.Invoke(session, step);
        }

        private void Event_EndTurn(IGameSessionData session)
        {
            Logger.Debug($"[EndTurn] session.Id = {session.Id} session.Turn = {session.Turn}");

            State.SetSession(session);

            OnEndTurn?.Invoke(session);
        }        
    }
}