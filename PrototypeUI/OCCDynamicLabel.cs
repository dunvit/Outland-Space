using System.ComponentModel;
using System.Windows.Forms;
using OutlandSpaceClient.Tools;
using OutlandSpaceCommon;

namespace PrototypeUI
{
    public class OccDynamicLabel : Label
    {
        private string _textFull;
        private string _textShown;

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public string DynamicText
        {
            get => _textFull;
            set => _textFull = value;
        }

        public OccDynamicLabel()
        {
            Text = "";
            base.Text = "";
        }

        private bool _isShown;

        public void StartShow()
        {
            _textShown = "";
            _textFull = DynamicText;
            _shownLetters = 0;

            if (_isShown == false)
            {
                Scheduler.Instance.ScheduleTask(50, 30, DrawTextPart);
            }

            _isShown = true;
        }

        private int _shownLetters;

        private void DrawTextPart()
        {
            if (_shownLetters >= _textFull.Length)
            {
                return;
            }

            _textShown += _textFull.ToCharArray()[_shownLetters];

            this.PerformSafely(RefreshControl, _textShown);

            _shownLetters++;
        }

        private void RefreshControl(string value)
        {
            if (_shownLetters + 1 >= _textFull.Length)
            {
                base.Text = value ;
            }
            else
            {
                base.Text = value + @"_";
            }
        }
    }
}
