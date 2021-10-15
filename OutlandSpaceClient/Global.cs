namespace OutlandSpaceClient
{
    public class Global
    {
        public static GameManager Game { get; private set; }

        public static void GameInitialization()
        {
            log4net.Config.XmlConfigurator.Configure();

            Game = new GameManager();
        }
    }
}