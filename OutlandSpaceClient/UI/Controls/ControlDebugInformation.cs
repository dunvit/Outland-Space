using System.Reflection;
using System.Windows.Forms;
using log4net;
using OutlandSpaceClient.Tools;
using Universe.Session;

namespace OutlandSpaceClient.UI.Controls
{
    public partial class ControlDebugInformation : UserControl
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ControlDebugInformation()
        {
            InitializeComponent();

            if (Global.Game == null) return;

            Global.Game.OnStartGame += Event_StartGame;
            Global.Game.OnEndTurn += Event_EndTurn;
            Global.Game.OnEndTurnStep += Event_OnEndTurnStep;
        }

        private void Event_OnEndTurnStep(IGameSessionData session, int step)
        {
            Logger.Debug($"Refresh game information for turn '{session.Turn} and step {step}'.");

            this.PerformSafely(RefreshControl, session);
        }

        private void Event_EndTurn(IGameSessionData session)
        {
            Logger.Debug($"Refresh game information for turn '{session.Turn}'.");

            this.PerformSafely(RefreshControl, session);
        }

        private void Event_StartGame(IGameSessionData session)
        {
            Logger.Debug($"Game with id = '{session.Id} started.");

            this.PerformSafely(RefreshControl, session);
        }

        public void RefreshControl(IGameSessionData session)
        {
            if (session is null) return;

            txtTurn.Text = @"Turn: " + session.Turn + "";
            txtMode.Text = @"Mode: " + session.IsPause;
            txtId.Text = @"session Id: " + session.Id + "";
            txtLocation.Text = @"Location X: " + session.CelestialObjects[1].PositionX + "";

            if (session.CelestialObjects[1].AtomicLocation.Count > 0 && session.Step < 21)
            {
                var locationX = $"{session.CelestialObjects[1].AtomicLocation[session.Step].Item2.X:0.00}";

                label1.Text = @"Location X: " + locationX + "";
                Logger.Debug($" location {locationX} Turn {session.Turn} step {session.Step}");
            }
        }
    }
}
