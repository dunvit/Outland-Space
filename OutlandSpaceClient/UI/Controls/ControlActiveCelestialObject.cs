using System;
using System.Drawing;
using System.Windows.Forms;
using OutlandSpaceClient.Tools;
using OutlandSpaceClient.UI.Model;
using Universe.Geometry;
using Universe.Objects;
using Universe.Session;

namespace OutlandSpaceClient.UI.Controls
{
    public partial class ControlActiveCelestialObject : UserControl, IGlobalUpdater
    {
        private int _lastCelestialObjectId;
        private IGameManager _gameManager;

        public ControlActiveCelestialObject()
        {
            InitializeComponent();

            panel1.Refresh();
        }

        private void Event_ChangeActiveObject(IGameSessionData gameSession, int celestialObjectId)
        {
            if (celestialObjectId == 0)
            {
                if (_lastCelestialObjectId == 0) return;

                if (_gameManager.State.ScreenInfo.ActiveCelestialObjectId == 0)
                {
                    Visible = false;
                }

                this.PerformSafely(RefreshControl, gameSession, _lastCelestialObjectId);
                return;
            }

            _lastCelestialObjectId = celestialObjectId;

            this.PerformSafely(RefreshControl, gameSession, celestialObjectId);

            if(Visible == false) Visible = true;
        }

        private void Event_Paint(object sender, PaintEventArgs e)
        {
            Refresh();
        }

        private void RefreshControl(IGameSessionData session, int celestialObjectId)
        {
            var celestialObject = session.GetCelestialObject(celestialObjectId);

            lblCelestialObjectName.Text = celestialObject.Name;
            lblCelestialObjecVelocity.Text = celestialObject.Speed.ToString("0.00");
            lblCelestialObjectAngle.Text = celestialObject.Direction.ToString("0.00");

            switch (celestialObject.Type)
            {
                case CelestialObjectTypes.None:
                    break;
                case CelestialObjectTypes.PointInMap:
                    break;
                case CelestialObjectTypes.Missile:
                    break;
                case CelestialObjectTypes.SpaceshipPlayer:
                    lblCelestialObjectClass.Text = @"Spaceship";
                    break;
                case CelestialObjectTypes.SpaceshipNpcNeutral:
                    lblCelestialObjectClass.Text = @"Spaceship";
                    break;
                case CelestialObjectTypes.SpaceshipNpcEnemy:
                    lblCelestialObjectClass.Text = @"Spaceship";
                    break;
                case CelestialObjectTypes.SpaceshipNpcFriend:
                    lblCelestialObjectClass.Text = @"Spaceship";
                    break;
                case CelestialObjectTypes.Asteroid:
                    lblCelestialObjectClass.Text = @"Asteroid";
                    break;
                case CelestialObjectTypes.Explosion:
                    break;
                case CelestialObjectTypes.ScanProbe:
                    break;
                case CelestialObjectTypes.Station:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(33, 33, 33)), 1, 1, Width - 2, 18);
            //e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(7, 7, 7)), 2), 1, 1, Width - 2, Height - 2);
            //e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(7, 7, 7)),2), 1, 1, Width - 2, 18);
        }

        private void lblExitScreen_MouseLeave(object sender, EventArgs e)
        {
            lblExitScreen.ForeColor = Color.Silver;
        }

        private void lblExitScreen_MouseEnter(object sender, EventArgs e)
        {
            lblExitScreen.ForeColor = Color.Orange;
        }

        private void lblExitScreen_Click(object sender, EventArgs e)
        {
            lblExitScreen.ForeColor = Color.Silver;
            Visible = false;
            _gameManager.RefreshOuterSpace(new Universe.Geometry.Point(0, 0), MouseArguments.RightClick);
        }

        public void Initialization(IGameManager gameManager)
        {
            _gameManager = gameManager;

            _gameManager.OnChangeChangeActiveObject += Event_ChangeActiveObject;
        }
    }
}
