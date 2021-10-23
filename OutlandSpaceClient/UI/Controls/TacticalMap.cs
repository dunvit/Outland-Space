using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Reflection;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using log4net;
using OutlandSpaceClient.UI.DrawEngine.TacticalMap;
using OutlandSpaceClient.UI.Model;
using OutlandSpaceCommon;
using Universe.Geometry;
using Universe.Session;

namespace OutlandSpaceClient.UI.Controls
{
    public partial class TacticalMap : UserControl
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private bool _refreshInProgress;
        private IGameSessionData _session;
        private int _frame;
        private readonly EngineSettings _settings;

        public TacticalMap()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            UpdateStyles();

            if (Global.Game == null) return;

            Global.Game.OnStartGame += Event_StartGame;
            Global.Game.OnEndTurn += Event_EndTurn;

            _settings = Global.Game.State.Settings;

            var frameInMilliseconds = 1000 / (double)_settings.FramesPerSecond;

            //Scheduler.Instance.ScheduleTask(1, 1000, V1);

            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += RecalculateCelestialObjectPositionsEvent1;
            aTimer.Interval = 20;
            aTimer.Enabled = true;

            bmpLive = new Bitmap(Width, Height);
            bmpLast = (Bitmap)bmpLive.Clone();

            var renderThread = new Thread(RenderForever);
            renderThread.Start();

            var frameCounterThread = new Thread(FrameCounterForever);
            frameCounterThread.Start();
        }

        private int frameId;

        
        private void FrameCounterForever()
        {
            double maxFPS = 60;
            double minFramePeriodMsec = 1000.0 / maxFPS;

            Stopwatch stopwatch = new Stopwatch();
            while (true)
            {
                stopwatch.Restart();

                if (_session != null && _session.IsPause == false)
                {
                    if (_lastTurn < _session.Turn)
                    {
                        frameId = 0;
                    }

                    frameId++;
                }
                else
                {
                    frameId = 0;
                }

                double msToWait = minFramePeriodMsec - stopwatch.ElapsedMilliseconds;
                if (msToWait > 0)
                    Thread.Sleep((int)msToWait);
            }
        }


        private void RecalculateCelestialObjectPositionsEvent1(object sender, ElapsedEventArgs e)
        {
            lock (bmpLast)
            {
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = (Bitmap)bmpLast.Clone();
            }
        }

        private static int turns;
        static Bitmap bmpLive;
        static Bitmap bmpLast;
        private void RenderForever()
        {
            double maxFPS = 60;
            double minFramePeriodMsec = 1000.0 / maxFPS;

            Stopwatch stopwatch = new Stopwatch();
            while (true)
            {
                stopwatch.Restart();

                if (_session != null && _session.IsPause == false)
                {
                    if (_lastTurn < _session.Turn)
                    {
                        Logger.Info(_printFrames);
                        _frame = 0;
                        _printFrames = "";
                        _lastTurn = _session.Turn;
                    }

                    _frame++;
                    _printFrames = $"Last frame is {frameId}/{_frame}"; //_printFrames + Environment.NewLine + _lastTurn + " - " + _frame;

                    //lock (bmpLast)
                    //{
                    //    bmpLast.Dispose();
                    //    bmpLast = (Bitmap)bmpLive.Clone();
                    //}
                }

                double msToWait = minFramePeriodMsec - stopwatch.ElapsedMilliseconds;
                if (msToWait > 0)
                    Thread.Sleep((int)msToWait);
            }
        }

        private string _printFrames;
        private int _lastTurn;

        private void RecalculateCelestialObjectPositionsEvent(object sender, ElapsedEventArgs e)
        {
            if (_session is null) return;

            if (_session.IsPause)
            {
                return;
            }

            if (_lastTurn < _session.Turn)
            {
                Logger.Info(_printFrames);
                _frame = 0;
                _printFrames = "";
                _lastTurn = _session.Turn;
            }

            _frame++;
            _printFrames = _printFrames + Environment.NewLine + _lastTurn + " - " + _frame;

            //Logger.Info($"[Event_OnEndTurnStep] Turn {_session.Turn} Frame is {_frame}");
            //RecalculateCelestialObjectPositions();
        }

        private void RecalculateCelestialObjectPositions()
        {
            if (_session is null) return;

            //Logger.Debug($"[Event_OnEndTurnStep] Turn {_session.Turn} Step is {_frame}");

            if (_session.IsPause)
            {
                RefreshControl(_session);
                return;
            }

            _frame++;

            foreach (var celestialObject in _session.CelestialObjects)
            {
                var location = GeometryTools.RecalculateAtomicObjectLocation(celestialObject, _settings, _frame);

                celestialObject.PositionX = location.X;
                celestialObject.PositionY = location.Y;
            }

            //RefreshControl(_session);
        }

        private void Event_EndTurn(IGameSessionData session)
        {
            Logger.Info($"[Event_EndTurn] Turn {session.Turn}");

            _session = session;
            _frame = 0;
        }

        private void Event_StartGame(IGameSessionData session)
        {
            _session = session;
            _frame = 0;

            RecalculateCelestialObjectPositions();
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

            CelestialObjects.Draw(graphics, session, screenParameters, _frame);
        }
    }
}
