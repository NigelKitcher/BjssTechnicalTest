using System.Collections.Generic;
using System.Drawing;

namespace Bjss.Library.Cards.Contracts
{
    public interface IDeck<T> : IShuffleable<T>, IDealable<T>, ISortable where T : ICard
    {
        /// <summary>
        /// Opens the deck from the decks pack
        /// </summary>
        void OpenDeck();

        /// <summary>
        /// Gets the Image on back of deck
        /// </summary>
        Image BackImage { get; }

        /// <summary>
        /// Adds a collection of cards to the deck
        /// </summary>
        /// <exception cref="InvalidCardException">Thrown when attempting to add a card from a different pack to those in this deck</exception>
        /// <param name="cards"></param>
        void AddCards(IEnumerable<T> cards);

        /// <summary>
        /// Gets the number of cards in the deck
        /// </summary>
        int CardCount { get; }
    }
}