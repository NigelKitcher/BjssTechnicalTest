namespace Bjss.Library.UI.Adapters
{
    public interface IRichTextBox
    {
        string Text { get; set; }

        void AppendText(string text);
    }
}
