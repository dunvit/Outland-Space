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
                _worker.OnEndTurnStep += Event_EndTurn;
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
            txtTurn.Text = @"Turn: " + _session.Turn + "";
            txtMode.Text = @"Mode: " + _session.IsPause;
            txtId.Text = @"session Id: " + _session.Id + "";
            txtLocation.Text = @"Location X: " + _session.CelestialObjects[1].PositionX + "";

            if (_session.CelestialObjects[1].AtomicLocation.Count > 0 && _session.Step < 21)
            {
                label1.Text = @"Location X: " + _session.CelestialObjects[1].AtomicLocation[_session.Step].Item2.X + "";
                Logger.Info($" location {_session.CelestialObjects[1].AtomicLocation[_session.Step].Item2.X} Turn {_session.Turn} step {_session.Step}");

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _worker.StartNewGameSession();
        }

        private void cmdResume_Click(object sender, EventArgs e)
        {
            _worker.SessionResume();
        }
    }
}
