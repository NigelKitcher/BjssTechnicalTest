using System;
using System.Collections.Generic;

namespace Bjss.Library.Cards.Contracts
{
    public interface IShuffleStrategy<T> where T : ICard
    {
        /// <summary>
        /// Event for signalling progress status on the shuffle
        /// </summary>
        event EventHandler ShuffleProgress;

        /// <summary>
        /// Event for signalling when shuffling is complete
        /// </summary>
        event EventHandler ShuffleCompleted;

        /// <summary>
        /// Shuffles a given collection of cards and returns a shuffled stack of cards
        /// </summary>
        /// <param name="cards">Cards to be shuffled</param>
        /// <returns></returns>
        Stack<T> Shuffle(ICollection<T> cards);
    }
}
