using Bjss.Library.Cards.Contracts;
using System;
using System.Collections.Generic;
using Bjss.Library.Cards.Domain;

namespace Bjss.Library.Cards.PileShuffle
{
    public class PileShuffleStrategy<T> : IShuffleStrategy<T> where T : ICard
    {
        private const int NumberOfPiles = 5;
        private readonly IRandomGenerator _randomGenerator;

        public event EventHandler ShuffleProgress;
        public event EventHandler ShuffleCompleted;

        public PileShuffleStrategy(IRandomGenerator randomGenerator)
        {
            _randomGenerator = randomGenerator;
        }

        private Dictionary<int, List<T>> CreatePiles()
        {
            var piles = new Dictionary<int, List<T>>();
            for (int i = 0; i < NumberOfPiles; i++)
            {
                var pile = new List<T>();
                piles.Add(i, pile);
            }

            return piles;
        }

        private Dictionary<int, List<T>> SplitIntoPiles(ICollection<T> cards)
        {
            var piles = CreatePiles();

            foreach (var card in cards)
            {
                var randomPile = _randomGenerator.Next(0, NumberOfPiles - 1);
                piles[randomPile].Add(card);
            }

            return piles;
        }

        private Stack<T> StackPiles(Dictionary<int, List<T>> piles)
        {
            var shuffledCards = new Stack<T>();
            for (int i = 0; i < NumberOfPiles; i++)
            {
                foreach (var card in piles[i])
                {
                    shuffledCards.Push(card);
                }
            }

            return shuffledCards;
        }

        /// <summary>
        /// Execute Pile Shuffle
        /// </summary>
        /// <param name="cards"></param>
        /// <remarks>Pile shuffle places cards randomly into one of several piles and then collects the piles</remarks>
        /// <returns></returns>
        public Stack<T> Shuffle(ICollection<T> cards)
        {
            var piles = SplitIntoPiles(cards);
            var shuffledCards = StackPiles(piles);
            
            return shuffledCards;
        }

        void RaiseShuffleProgress(int percentage)
        {
            OnShuffleProgressChanged(new ShuffleProgressEventArgs(percentage));
        }

        void RaiseShuffleCompleted(TimeSpan timeTaken)
        {
            OnShuffleCompleted(new ShuffleCompletedEventArgs(timeTaken));
        }

        protected virtual void OnShuffleProgressChanged(ShuffleProgressEventArgs e)
        {
            ShuffleProgress?.Invoke(this, e);
        }

        protected virtual void OnShuffleCompleted(ShuffleCompletedEventArgs e)
        {
            ShuffleCompleted?.Invoke(this, e);
        }
    }
}
