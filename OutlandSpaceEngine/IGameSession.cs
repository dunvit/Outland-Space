using Universe.Session;

namespace Engine
{
    public interface IGameSession: IGameSessionData, IGameSessionExporter
    {
        CelestialMap SpaceMap { get; set; }

        void FinishTurn();
    }
}