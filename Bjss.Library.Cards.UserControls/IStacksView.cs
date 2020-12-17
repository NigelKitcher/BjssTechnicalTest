using Bjss.Library.Cards.FrenchSuited;

namespace Bjss.Library.Cards.UserControls
{
    public interface IStacksView
    {
        /// <summary>
        /// Displays the card.
        /// </summary>
        /// <param name="card">The card.</param>
        void DisplayCard(IFrenchSuitedCard card);

        /// <summary>
        /// Removes all cards from display.
        /// </summary>
        void RemoveAllCardsFromDisplay();
    }
}
