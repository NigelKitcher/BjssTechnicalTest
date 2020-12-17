using System.Windows.Forms;

namespace Bjss.Library.UI.Adapters
{
    public class RichTextBoxAdapter : ControlAdapter, IRichTextBox
    {
        private readonly RichTextBox _richTextBox;

        public RichTextBoxAdapter(RichTextBox richTextBox)
            : base(richTextBox)
        {
            _richTextBox = richTextBox;
        }

        public string Text
        {
            get => _richTextBox.Text;
            set => _richTextBox.Text = value;
        }

        public void AppendText(string text)
        {
            _richTextBox.AppendText(text);
        }
    }
}