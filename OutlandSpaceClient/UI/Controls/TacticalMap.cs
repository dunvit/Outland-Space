using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Reflection;
using System.Windows.Forms;
using log4net;
using OutlandSpaceClient.UI.DrawEngine.TacticalMap;
using OutlandSpaceClient.UI.Model;
using Universe.Session;

namespace OutlandSpaceClient.UI.Controls
{
    public partial class TacticalMap : UserControl
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private bool _refreshInProgress;

        public TacticalMap()
        {
            InitializeComponent();

            if (Global.Game == null) return;

            Global.Game.OnStartGame += Event_StartGame;
            Global.Game.OnEndTurn += Event_EndTurn;
            Global.Game.OnEndTurnStep += Event_OnEndTurnStep;
        }

        private void Event_OnEndTurnStep(IGameSessionData session, int step)
        {
            Logger.Debug($"[Event_OnEndTurnStep] Turn {session.Turn} Step is {step}");

            RefreshControl(session);
        }

        private void Event_EndTurn(IGameSessionData session)
        {
            Logger.Debug($"[Event_EndTurn] Turn {session.Turn}");

            RefreshControl(session);
        }

        private void Event_StartGame(IGameSessionData session)
        {
            RefreshControl(session);
        }

        private void RefreshControl(IGameSessionData session)
        {
            if (_refreshInProgress) return;

            var timeDrawScreen = Stopwatch.StartNew();

            _refreshInProgress = true;

            Image image = new Bitmap(Width, Height);

            var graphics = Graphics.FromImage(image);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            DrawTacticalMapScreen(graphics, Global.Game.State.ScreenInfo, session);

            BackgroundImage = image;

            _refreshInProgress = false;

            Logger.Debug($"Refresh space map for turn '{session.Turn}' was finished successful. Time {timeDrawScreen.Elapsed.TotalMilliseconds} ms.");
        }

        private void DrawTacticalMapScreen(Graphics graphics, IScreenInfo screenParameters, IGameSessionData session)
        {
            Logger.Debug($"[Event_OnEndTurnStep] Location turn {session.Turn} step {session.Step}");

            BackGround.Draw(graphics, screenParameters);

            Grid.Draw(graphics, screenParameters);

            CelestialObjects.Draw(graphics, session, screenParameters);
        }
    }
}
