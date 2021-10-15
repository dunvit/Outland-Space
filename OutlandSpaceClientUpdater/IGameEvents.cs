using System;
using Universe.Session;

namespace Updater
{
    public interface IGameEvents
    {
        event Action<IGameSessionData> OnStartGame;
        event Action<IGameSessionData> OnEndTurn;
        event Action<IGameSessionData, int> OnEndTurnStep;
    }
}