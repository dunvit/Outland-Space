using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine.Generation.Celestial;
using OutlandSpaceClient.Tools;
using OutlandSpaceClient.UI.DrawEngine.TacticalMap;
using Universe.Geometry;

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

            MouseClick += MapClick;
            MouseMove += MapMouseMove;

            if (Global.Game == null) return;

            bmpLive = new Bitmap(Width, Height);
            bmpLast = (Bitmap)bmpLive.Clone();            

            log.Info("Build 'ControlTacticalMap' control");
        }

        private void MapMouseMove(object sender, MouseEventArgs e)
        {
            var mouseScreenCoordinates = GeometryTools.ToRelativeCoordinates(e.Location, Global.Game.State.ScreenInfo.Center);

            var mouseLocation = GeometryTools.ToTacticalMapCoordinates(mouseScreenCoordinates, Global.Game.State.ScreenInfo.CenterScreenOnMap);
        }

        private void MapClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        internal void Initialization()
        {
            log.Info("Initialization 'ControlTacticalMap' control");

            _celestialBackground = new CelestialBackground(300, Width, Height);

            bmpbase = new Bitmap(Width, Height);
            
            Draw.DrawBaseTacticalMapScreen(bmpbase, Global.Game.State.ScreenInfo, _session, _celestialBackground);

            imageTacticalMap.Image = (Bitmap)bmpbase.Clone();            
        }

        private void RefreshControl()
        {
            lblFps.Text = $@"FPS: {lastFrameRate} Location turn {_session.Turn} step {_session.Step}";

            Image image = (Bitmap)bmpbase.Clone();

            Draw.DrawTacticalMapScreen(image, Global.Game.State.ScreenInfo, _session, _celestialBackground, currentFrameRate);

            imageTacticalMap.Image?.Dispose();
            imageTacticalMap.Image = image;
        }

        protected override async Task Render()
        {
            if (_inProgress) return;

            _inProgress = true;
            
            log.Debug($"frame is {_session.Turn}.{currentFrameRate} ");

            lock (bmpLast)
            {
                lock(bmpbase)
                {
                    try
                    {
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

        
    }
}
