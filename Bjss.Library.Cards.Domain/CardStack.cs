using System;
using System.Collections.Generic;
using System.Linq;
using Bjss.Library.Cards.Contracts;

namespace Bjss.Library.Cards.Domain
{
    public class CardStack : ICardStack
    {
        private readonly Stack<ICard> _cards = new Stack<ICard>();

        public void Add(ICard card)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));

            _cards.Push(card);
        }

        public void AddRange(IEnumerable<ICard> cards)
        {
            if (cards == null) throw new ArgumentNullException(nameof(cards));

            foreach (var card in cards)
            {
                _cards.Push(card);   
            }
        }

        public void Clear()
        {
            _cards.Clear();
        }

        public IEnumerable<ICard> GetCards()
        {
            return _cards.ToList();
        }

        public bool HasCards()
        {
            return _cards.Count > 0;
        }

        public ICard TopCard()
        {
            return _cards.Peek();
        }
    }
}
