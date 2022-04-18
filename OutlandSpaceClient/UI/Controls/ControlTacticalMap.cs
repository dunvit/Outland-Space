using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine.Generation.Celestial;
using OutlandSpaceClient.Tools;
using OutlandSpaceClient.UI.DrawEngine.TacticalMap;
using OutlandSpaceClient.UI.Model;
using Universe.Geometry;

namespace OutlandSpaceClient.UI.Controls
{
    public partial class ControlTacticalMap : BaseRenderControl, IGlobalUpdater
    {

        static Bitmap bmpLive;
        static Bitmap bmpLast;
        static Bitmap bmpbase;

        private bool _inProgress;
        private IGameManager _gameManager;
        private CelestialBackground _celestialBackground;

        public ControlTacticalMap()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            UpdateStyles();

            imageTacticalMap.Dock = DockStyle.Fill;

            imageTacticalMap.MouseClick += MapClick;
            imageTacticalMap.MouseMove += MapMouseMove;

            bmpLive = new Bitmap(Width, Height);
            bmpLast = (Bitmap)bmpLive.Clone();            

            log.Info("Build 'ControlTacticalMap' control");
        }

        private Universe.Geometry.Point GetCurrentMapCoordinates(System.Drawing.Point location)
        {
            var mouseScreenCoordinates = GeometryTools.ToRelativeCoordinates(location, _gameManager.State.ScreenInfo.Center);

            var mouseLocation = GeometryTools.ToTacticalMapCoordinates(mouseScreenCoordinates, _gameManager.State.ScreenInfo.CenterScreenOnMap);

            return mouseLocation;
        }

        private void MapMouseMove(object sender, MouseEventArgs e)
        {
            _gameManager.RefreshOuterSpace(GetCurrentMapCoordinates(e.Location), MouseArguments.Move);
        }

        private void MapClick(object sender, MouseEventArgs e)
        {
            var mouseButton = MouseArguments.LeftClick;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    mouseButton = MouseArguments.LeftClick;
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Right:
                    mouseButton = MouseArguments.RightClick;
                    break;
                case MouseButtons.Middle:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _gameManager.RefreshOuterSpace(GetCurrentMapCoordinates(e.Location), mouseButton);
        }

        public void Initialization(IGameManager gameManager)
        {
            log.Info("Initialization 'ControlTacticalMap' control");

            _gameManager = gameManager;

            _celestialBackground = new CelestialBackground(300, Width, Height);

            bmpbase = new Bitmap(Width, Height);

            Draw.DrawBaseTacticalMapScreen(bmpbase, _gameManager.State.ScreenInfo, _session, _celestialBackground);

            imageTacticalMap.Image = (Bitmap)bmpbase.Clone();            
        }

        private void RefreshControl()
        {
            lblFps.Text = $@"FPS: {lastFrameRate} Location turn {_session.Turn} step {_session.Step}";

            Image image = (Bitmap)bmpbase.Clone();

            if (_gameManager.State.ScreenInfo.ControlActiveCelestialObjectLocation == new System.Drawing.Point(0, 0))
            {
                _gameManager.State.ScreenInfo.ControlActiveCelestialObjectLocation = ((Form1)ParentForm).ControlActiveCelestialObjectLocation;
            }

            _gameManager.State.Refresh();

            Draw.DrawTacticalMapScreen(image, _gameManager.State, _session, _celestialBackground, currentFrameRate);

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
