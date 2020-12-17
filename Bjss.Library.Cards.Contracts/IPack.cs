using System;
using System.Collections.Generic;
using System.Drawing;

namespace Bjss.Library.Cards.Contracts
{
    public interface IPack<T> where T : ICard
    {
        /// <summary>
        /// Gets the name of the pack of cards
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the type of cards in this pack
        /// </summary>
        Type CardType { get; }

        /// <summary>
        /// Gets the number of cards in the Pack
        /// </summary>
        int NumberInPack { get; }

        /// <summary>
        /// Gets a set of new ordered cards from the pack
        /// </summary>
        /// <returns></returns>
        ICollection<T> GetCards();

        /// <summary>
        /// Gets the image for the back of the card
        /// </summary>
        /// <returns></returns>
        Image GetCardBackImage();
    }
}
