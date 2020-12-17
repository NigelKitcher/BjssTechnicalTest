using Bjss.Library.Cards.Contracts;

namespace Bjss.Library.Cards.UserControls
{
    public interface IStackPresenter
    {
        /// <summary>
        /// Hides the cards.
        /// </summary>
        void HideCards();

        /// <summary>
        /// Shows the card.
        /// </summary>
        /// <param name="card">The card.</param>
        void ShowCard(ICard card);
    }
}
