namespace Universe.Session
{
    public interface IGameSessionExporter
    {
        IGameSessionData ToGameSession();
    }
}