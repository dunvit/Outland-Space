using System;
using System.Reflection;
using log4net;
using OutlandSpaceClient.Tools;
using Universe.Geometry;
using Universe.Session;
using Updater;

namespace OutlandSpaceClient
{
    public class GameManager: IGameEvents
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public event Action<IGameSessionData> OnStartGame;
        public event Action<IGameSessionData> OnEndTurn;
        public event Action<IGameSessionData> OnRefreshLocations;
        public event Action<IGameSessionData, int> OnEndTurnStep;

        public GameState State;
        private OuterSpace _outerSpace;

        private readonly Worker _worker;
        private IGameSessionData _session;

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

        private void Event_ChangeSelectedObject(int id)
        {
            // TODO: Refresh UI active entity to ControlTacticalMap
            throw new NotImplementedException();
        }

        private void Event_ChangeActiveObject(int id)
        {
            // TODO: Refresh UI active entity to ControlTacticalMap
            throw new NotImplementedException();
        }

        public void RefreshOuterSpace(Point coordinates, MouseArguments type)
        {
            _outerSpace.Refresh(_session, coordinates, type);
        }

        private void Event_RefreshLocations(IGameSessionData session)
        {
            _session = session;
            OnRefreshLocations?.Invoke(session);
        }

        private void Event_StartGame(IGameSessionData session)
        {
            _session = session;
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

            _session = session;

            OnEndTurnStep?.Invoke(session, step);
        }

        private void Event_EndTurn(IGameSessionData session)
        {
            Logger.Debug($"[EndTurn] session.Id = {session.Id} session.Turn = {session.Turn}");

            _session = session;

            OnEndTurn?.Invoke(session);
        }        
    }
}