using System;
using System.Windows.Forms;
using log4net;

namespace OutlandSpaceClient
{
    static class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Global.GameInitialization();
            

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Logger.Info("Start 'Outland Space' game desktop client.");

            var mainScreen = new Form1();

            mainScreen.Initialization(Global.Game);

            Application.Run(mainScreen);
        }
    }
}
