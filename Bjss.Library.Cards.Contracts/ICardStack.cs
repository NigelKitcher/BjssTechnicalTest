using System.Collections.Generic;

namespace Bjss.Library.Cards.Contracts
{
    public interface ICardStack
    {
        /// <summary>
        /// Adds a card to the card stack
        /// </summary>
        /// <param name="card"></param>
        void Add(ICard card);

        /// <summary>
        /// Adds a range of cards to the card stack
        /// </summary>
        /// <param name="cards"></param>
        void AddRange(IEnumerable<ICard> cards);

        /// <summary>
        /// Gets the card on the top of the stack
        /// </summary>
        /// <returns></returns>
        ICard TopCard();

        /// <summary>
        /// Clears the card stack
        /// </summary>
        void Clear();

        /// <summary>
        /// Returns whether there are any cards on the stack
        /// </summary>
        /// <returns></returns>
        bool HasCards();

        /// <summary>
        /// Gets the collection of cards from the stack
        /// </summary>
        /// <returns></returns>
        IEnumerable<ICard> GetCards();
    }
}
