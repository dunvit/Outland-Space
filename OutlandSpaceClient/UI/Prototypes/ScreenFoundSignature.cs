using System;
using System.Windows.Forms;

namespace OutlandSpaceClient.UI.Screens
{
    public partial class ScreenFoundSignature : Form
    {
        private IGameManager _gameManager;

        public ScreenFoundSignature(IGameManager gameManager)
        {
            InitializeComponent();

            _gameManager = gameManager;

            RefreshUi();
        }

        private void RefreshUi()
        {
            if (_gameManager?.State?.ScreenInfo?.ActiveCelestialObjectId <= 0) return;

            var activeObject = _gameManager.State.GetActiveCelestialObject();

            txtSpeed.Text = activeObject.Speed.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

            txtId.Text = activeObject.Name;
        }
        
        private void lblExitScreen_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }
}
