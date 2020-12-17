using Bjss.Library.Cards.Contracts;
using Bjss.Library.Cards.FrenchSuited;
using System.Collections.Generic;

namespace Bjss.Sevens.Domain.Contracts
{
    /// <summary>
    /// Dealer deals a shuffle deck of cards to a given collection of players
    /// </summary>
    /// <seealso cref="Bjss.Sevens.Domain.Contracts.IDealer" />
    public interface IDealer
    {
        /// <summary>
        /// Gets the players.
        /// </summary>
        /// <value>
        /// The players.
        /// </value>
        IEnumerable<IPlayer> Players { get; }

        /// <summary>
        /// Gets the deck.
        /// </summary>
        /// <value>
        /// The deck.
        /// </value>
        IDeck<IFrenchSuitedCard> Deck { get; }

        /// <summary>
        /// Deals the deck to the players.
        /// </summary>
        void Deal();
    }
}
