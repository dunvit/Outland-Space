using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using OutlandSpaceClient.Tools;

namespace OutlandSpaceClient.UI.Controls
{
    public partial class ControlTacticalMap : BaseRenderControl
    {
        static Bitmap bmpLive;
        static Bitmap bmpLast;

        private bool _inProgress;

        public ControlTacticalMap()
        {
            InitializeComponent();

            imageTacticalMap.Dock = DockStyle.Fill;

            if (Global.Game == null) return;

            bmpLive = new Bitmap(Width, Height);
            bmpLast = (Bitmap)bmpLive.Clone();


            log.Info("This is a 'ControlTacticalMap' message");
        }

        private void RefreshControl()
        {
            lblFps.Text = $@"FPS: {lastFrameRate}";
        }

        protected override async Task Render()
        {
            if (_inProgress) return;

            _inProgress = true;
            
            log.Info($"frame is {_session.Turn}.{currentFrameRate} ");

            lock (bmpLast)
            {
                try
                {
                    imageTacticalMap.Image?.Dispose();
                    imageTacticalMap.Image = (Bitmap)bmpLast.Clone();

                    this.PerformSafely(RefreshControl);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }



            _inProgress = false;
        }
    }
}
