using Bjss.Library.Cards.FrenchSuited;
using System.Collections.Generic;

namespace Bjss.Sevens.Domain.Contracts
{
    public interface IHand
    {
        /// <summary>
        /// Gets the cards.
        /// </summary>
        /// <value>
        /// The cards.
        /// </value>
        List<IFrenchSuitedCard> Cards { get; }

        /// <summary>
        /// Determines whether [is holding opening card].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is holding opening card]; otherwise, <c>false</c>.
        /// </returns>
        bool IsHoldingOpeningCard();

        /// <summary>
        /// Determines whether [is holding king] [the specified suit].
        /// </summary>
        /// <param name="suit">The suit.</param>
        /// <returns>
        ///   <c>true</c> if [is holding king] [the specified suit]; otherwise, <c>false</c>.
        /// </returns>
        bool IsHoldingKing(Suit suit);

        /// <summary>
        /// Determines whether [is holding ace] [the specified suit].
        /// </summary>
        /// <param name="suit">The suit.</param>
        /// <returns>
        ///   <c>true</c> if [is holding ace] [the specified suit]; otherwise, <c>false</c>.
        /// </returns>
        bool IsHoldingAce(Suit suit);

        /// <summary>
        /// Counts the of higher cards.
        /// </summary>
        /// <param name="card">The card.</param>
        /// <returns></returns>
        int CountOfHigherCards(IFrenchSuitedCard card);

        /// <summary>
        /// Counts the of lower cards.
        /// </summary>
        /// <param name="card">The card.</param>
        /// <returns></returns>
        int CountOfLowerCards(IFrenchSuitedCard card);

        /// <summary>
        /// Gets the starting cards.
        /// </summary>
        /// <returns></returns>
        IList<IFrenchSuitedCard> GetStartingCards();

        /// <summary>
        /// Gets the opening card.
        /// </summary>
        /// <returns></returns>
        IFrenchSuitedCard GetOpeningCard();

        /// <summary>
        /// Removes the card.
        /// </summary>
        /// <param name="card">The card.</param>
        void RemoveCard(IFrenchSuitedCard card);
    }
}
