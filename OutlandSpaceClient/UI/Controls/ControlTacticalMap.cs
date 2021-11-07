using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine.Generation.Celestial;
using OutlandSpaceClient.Tools;
using OutlandSpaceClient.UI.DrawEngine.TacticalMap;
using OutlandSpaceClient.UI.Model;
using Universe.Session;

namespace OutlandSpaceClient.UI.Controls
{
    public partial class ControlTacticalMap : BaseRenderControl
    {
        static Bitmap bmpLive;
        static Bitmap bmpLast;
        static Bitmap bmpbase;

        private bool _inProgress;

        private CelestialBackground _celestialBackground;

        public ControlTacticalMap()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            UpdateStyles();

            imageTacticalMap.Dock = DockStyle.Fill;

            if (Global.Game == null) return;

            bmpLive = new Bitmap(Width, Height);
            bmpLast = (Bitmap)bmpLive.Clone();
            

            log.Info("This is a 'ControlTacticalMap' message");
        }

        internal void Initialization()
        {
            _celestialBackground = new CelestialBackground(300, Width, Height);

            bmpbase = new Bitmap(Width, Height);

            DrawBaseTacticalMapScreen(bmpbase, Global.Game.State.ScreenInfo);

            lock (bmpLast)
            {
                imageTacticalMap.Image = (Bitmap)bmpbase.Clone();
            }
        }

        private void RefreshControl()
        {
            lblFps.Text = $@"FPS: {lastFrameRate} Location turn {_session.Turn} step {_session.Step}";
        }

        protected override async Task Render()
        {
            if (_inProgress) return;

            _inProgress = true;
            
            log.Info($"frame is {_session.Turn}.{currentFrameRate} ");

            lock (bmpLast)
            {
                lock(bmpbase)
                {
                    try
                    {
                        //imageTacticalMap.Image?.Dispose();
                        //imageTacticalMap.Image = (Bitmap)bmpLast.Clone();

                        Image image = (Bitmap)bmpbase.Clone();

                        DrawTacticalMapScreen(image, Global.Game.State.ScreenInfo, _session);

                        //bmpLast = (Bitmap)image.Clone();

                        imageTacticalMap.Image?.Dispose();
                        imageTacticalMap.Image = image;

                        this.PerformSafely(RefreshControl);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }                
            }

            _inProgress = false;
        }

        private void DrawTacticalMapScreen(Image image, IScreenInfo screenParameters, IGameSessionData session)
        {
            //Logger.Debug($"[Event_OnEndTurnStep] Location turn {session.Turn} step {session.Step}");

            var graphics = Graphics.FromImage(image);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            // TODO: Calculate celestial object position by timespan instead of frame 
            // recalculate frame number for draw process 

            // TODO: Refactor Draw process to stand alone file

            StartFlicker.Draw(graphics, session, screenParameters, _celestialBackground);

            CelestialObjects.Draw(graphics, session, screenParameters, currentFrameRate);
        }

        private void DrawBaseTacticalMapScreen(Image image, IScreenInfo screenParameters)
        {
            //Logger.Debug($"[Event_OnEndTurnStep] Location turn {session.Turn} step {session.Step}");

            var graphics = Graphics.FromImage(image);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            BackGround.Draw(graphics, screenParameters);

            Grid.Draw(graphics, screenParameters);

            StartFlicker.Draw(graphics, _session, screenParameters, _celestialBackground);
        }
    }
}
