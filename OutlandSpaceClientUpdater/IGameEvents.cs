using System;
using Universe.Session;

namespace Updater
{
    public interface IGameEvents
    {
        event Action<IGameSessionData> OnStartGame;
        event Action<IGameSessionData> OnEndTurn;
        event Action<IGameSessionData, int> OnEndTurnStep;
        event Action<IGameSessionData> OnRefreshLocations;
        event Action<IGameSessionData, int> OnChangeChangeActiveObject;
        event Action<IGameSessionData, int> OnChangeChangeSelectedObject;
    }
}