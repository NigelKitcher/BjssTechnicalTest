using System;
using System.Drawing;
using Bjss.Library.Cards.FrenchSuited;

namespace Bjss.Sevens.Domain.Contracts
{
    public interface IPlayer
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; }

        /// <summary>
        /// Gets the colour.
        /// </summary>
        /// <value>
        /// The colour.
        /// </value>
        Color Colour { get; }

        ///// <summary>
        ///// Gets the hand.
        ///// </summary>
        ///// <value>
        ///// The hand.
        ///// </value>
        IHand Hand { get; }

        /// <summary>
        /// Gets the game play strategy for this player
        /// </summary>
        /// <value>
        /// The game play strategy.
        /// </value>
        IGamePlayStrategy GamePlayStrategy { get; }

        /// <summary>
        /// Takes the turn.
        /// </summary>
        void TakeTurn();

        /// <summary>
        /// Plays the card.
        /// </summary>
        /// <param name="card">The card.</param>
        void PlayCard(IFrenchSuitedCard card);

        /// <summary>
        /// Sorts the hand.
        /// </summary>
        void SortHand();

        /// <summary>
        /// Returns any cards so have an empty hand
        /// </summary>
        void ReturnAnyCards();

        /// <summary>
        /// Occurs when [card played].
        /// </summary>
        event EventHandler<CardPlayedEventArgs> CardPlayed;
    }
}
