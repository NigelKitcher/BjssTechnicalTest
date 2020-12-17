using Bjss.Library.Cards.UserControls;
//using Bjss.Library.UI.Adapters;

namespace Bjss.Sevens.Client.UI
{
    /// <summary>
    /// TODO: Given further time this would use the Bjss.Library.UI.Adapters project (this has not been included with the solution)
    /// TODO: This provides interfaces and adapters to allow mocking and thus unit testing of the main form
    /// </summary>
    public interface IMainFormView
    {
        IStacksView CardStacks { get; }

        //ILabel Player2Label { get; }

        //ILabel Player3Label { get; }

        IHandView Player1HandView { get; }

        IHandView Player2HandView { get; }

        IHandView Player3HandView { get; }

        //IButton NewGameButton { get; }

        //IButton KnockButton { get; }

        //IButton PeekButton { get; }

        //IRichTextBox GameLog { get; }
    }
}
