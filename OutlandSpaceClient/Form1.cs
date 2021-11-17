using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using log4net;
using OutlandSpaceClient.UI.Model;

namespace OutlandSpaceClient
{
    public partial class Form1 : Form, IGlobalUpdater
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private IGameManager _gameManager;

        public Point ControlActiveCelestialObjectLocation => controlActiveCelestialObject.Location;

        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint , true);

            UpdateStyles();

            crlTacticalMap.Dock = DockStyle.Fill;

            Logger.Debug("Base game screen initialization finished.");
        }

        private void cmdResume_Click(object sender, EventArgs e)
        {
            Global.Game.SessionResume();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            crlTacticalMap.Initialization(_gameManager);
            controlActiveCelestialObject.Initialization(_gameManager);
        }

        public void Initialization(IGameManager gameManager)
        {
            _gameManager = gameManager;

            Global.Game.StartGameSession();
        }
    }
}
