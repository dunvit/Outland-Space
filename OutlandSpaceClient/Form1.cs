using System;
using System.Reflection;
using System.Windows.Forms;
using log4net;

namespace OutlandSpaceClient
{
    public partial class Form1 : Form
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint , true);

            UpdateStyles();

            crlTacticalMap.Dock = DockStyle.Fill;

            if (Global.Game == null) return;

            Logger.Debug("Base game screen initialization finished.");

            Global.Game.StartGameSession();
        }

        private void cmdResume_Click(object sender, EventArgs e)
        {
            Global.Game.SessionResume();
        }
    }
}
