using System;
using System.Collections.Generic;
using Bjss.Library.Cards.FrenchSuited;

namespace Bjss.Sevens.Domain.Contracts
{
    /// <summary>
    /// Service interface for tracking cards that have been played and accepting cards to be played
    /// </summary>
    public interface ISevensGameService
    {
        /// <summary>
        /// Creates new game.
        /// </summary>
        void NewGame();

        /// <summary>
        /// Gets the cards that have been played.
        /// </summary>
        /// <value>
        /// The played cards.
        /// </value>
        List<IFrenchSuitedCard> PlayedCards { get; }

        /// <summary>
        /// Accepts the card.
        /// </summary>
        /// <param name="card">The card.</param>
        /// <exception cref="InvalidMoveException">Raised if the card played is an invalid move</exception>
        void AcceptCard(IFrenchSuitedCard card);

        /// <summary>
        /// Occurs when [card played].
        /// </summary>
        event EventHandler<CardPlayedAcceptedEventArgs> CardPlayed;
    }
}
