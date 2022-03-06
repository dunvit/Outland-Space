using OutlandSpaceClient.UI.Screens;

namespace OutlandSpaceClient
{
    public static class MainScreenVisibilityManager
    {
        public static void ShowFoundSignature(IGameManager gameManager)
        {
            var screen = new ScreenFoundSignature(gameManager);

            screen.ShowDialog();
        }
    }
}