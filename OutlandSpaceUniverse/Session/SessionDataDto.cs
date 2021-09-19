namespace Universe.Session
{
    public struct SessionDataDto: IGameSessionData
    {
        public int Id { get; set; }

        public int Turn { get; set; }

        public bool IsPause { get; set; }

        public string ScenarioName { get; set; }
        public bool IsValid { get; set; }
    }
}
