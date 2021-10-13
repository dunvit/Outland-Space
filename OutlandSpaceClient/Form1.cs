using System;
using System.Reflection;
using System.Windows.Forms;
using log4net;
using OutlandSpaceClient.Tools;
using Universe.Session;
using Updater;

namespace OutlandSpaceClient
{
    public partial class Form1 : Form
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly Worker _worker = new Worker();

        private IGameSessionData _session;

        public Form1()
        {
            InitializeComponent();

            if (_worker != null)
            {
                _worker.OnEndTurn += Event_EndTurn;
            }
        }

        private void Event_EndTurn(IGameSessionData environment)
        {
            _session = environment;

            Logger.Debug($"Refresh game information for turn '{_session.Turn}'.");

            this.PerformSafely(RefreshControl);
        }

        private void RefreshControl()
        {
            txtTurn.Text = _session.Turn + "";
            txtMode.Text = _session.IsPause.ToString();
            txtId.Text = _session.Id + "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _worker.StartNewGameSession();
        }

        private void cmdResume_Click(object sender, EventArgs e)
        {
            _worker.SessionResume();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
