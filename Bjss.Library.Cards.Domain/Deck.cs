using Bjss.Library.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Bjss.Library.Cards.Domain
{
    public class Deck<T> : IDeck<T> where T : ICard
    {
        private readonly object _lock = new object();
        private Stack<T> Cards { get; set; }

        public Deck(IPack<T> pack)
        {
            Pack = pack;
        }

        public void OpenDeck()
        {
            var cardsInPack = Pack.GetCards();

            lock (_lock)
            {
                Cards = new Stack<T>();
                AddCards(cardsInPack.Reverse(), true);               
            }
        }

        public int CardCount
        {
            get
            {
                CheckDeckOpened();
                return Cards.Count;
            }
        }

        public IPack<T> Pack { get; }

        public Image BackImage
        {
            get
            {
                return Cards.Count > 0
                    ? Pack.GetCardBackImage()
                    : null;
            }
        }

        private void CheckDeckOpened()
        {
            if (Cards == null) throw new DeckNotOpenedException();
        }

        private bool IsFromThisPack(ICard card)
        {
            return card.GetType() == Pack.CardType;
        }

        private void CheckCard(ICard card)
        {
            if (!IsFromThisPack(card))
            {
                throw new InvalidCardException(card.Name + " does not below to " + Pack.Name);
            }
        }

        private bool IsFullDeck()
        {
            return Cards.Count == Pack.NumberInPack;
        }

        private bool IsOutOfCards()
        {
            return Cards.Count == 0;
        }

        public void Shuffle(IShuffleStrategy<T> shuffleStrategy)
        {
            if (shuffleStrategy == null) throw new ArgumentNullException(nameof(shuffleStrategy));

            lock (_lock)
            {
                CheckDeckOpened();
                if (!IsFullDeck())
                {
                    throw  new NotFullDeckException("Can not shuffle a deck with incorrect number of cards");
                }

                Cards = shuffleStrategy.Shuffle(Cards.ToList());
            }
        }

        public T Deal()
        {
            lock (_lock)
            {
                CheckDeckOpened();
                if (IsOutOfCards())
                {
                    throw new OutOfCardsException("No more cards to be dealt");
                }

                return Cards.Pop();
            }
        }

        public void Sort()
        {
            lock (_lock)
            {
                var stackedCards = Cards.ToList();
                var orderedCards = stackedCards.OrderByDescending(card => card.Number);
                Cards.Clear();
                foreach (var card in orderedCards)
                {
                    Cards.Push(card);
                }
            }
        }


        public void AddCards(IEnumerable<T> cards)
        {
            AddCards(cards, false);
        }

        private void AddCards(IEnumerable<T> cards, bool isOpening)
        {
            lock (_lock)
            {
                if (!isOpening) CheckDeckOpened();

                foreach (var card in cards)
                {
                    CheckCard(card);
                    Cards.Push(card);
                }
            }
        }

    }
}
