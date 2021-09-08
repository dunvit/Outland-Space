namespace Universe.Session
{
    public interface IGameSessionData
    {
        int Id { get; set; }

        int Turn { get; set; }

        bool IsPause { get; set; }

        string ScenarioName { get; set; }
    }
}