using Bjss.Library.Cards.FrenchSuited;
using Bjss.Sevens.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bjss.Sevens.Domain
{
    /// <summary>
    /// Simple playing strategy
    /// </summary>
    /// <remarks>Plays the first card it finds that it can play</remarks>
    /// <seealso cref="Bjss.Sevens.Domain.Contracts.IGamePlayStrategy" />
    public class BasicGamePlayStrategy : IGamePlayStrategy
    {
        private IList<IFrenchSuitedCard> _playedCards;
        private IList<IFrenchSuitedCard> _hand;

        private bool IsOpeningMove() => _playedCards.Count == 0;

        private bool IsHoldingOpeningCard()
        {
            return _hand.Any(x => x.Suit == GameRules.OpeningSuit && x.Rank == GameRules.FirstRank);
        }

        private IFrenchSuitedCard OpeningCard()
        {
            return _hand.First(x => x.Suit == GameRules.OpeningSuit && x.Rank == GameRules.FirstRank);
        }

        private bool IsCardsAdjacent(IFrenchSuitedCard cardA, IFrenchSuitedCard cardB)
        {
            return (Math.Abs(cardA.Rank - cardB.Rank) == 1) && cardA.Suit == cardB.Suit;
        }

        private bool IsHoldingAnOpeningCard()
        {
            return _hand.Any(x => x.Rank == GameRules.FirstRank);
        }

        private IFrenchSuitedCard GetOpeningCard()
        {
            return _hand.First(x => x.Rank == GameRules.FirstRank);
        }

        private IFrenchSuitedCard GetFirstPlayableCard()
        {
            foreach (var card in _hand)
            {
                if (_playedCards.Any(x => IsCardsAdjacent(x, card)))
                {
                    return card;
                }
            }

            if (IsHoldingAnOpeningCard())
            {
                return GetOpeningCard();
            }

            throw new KnockException();
        }
    

        public IFrenchSuitedCard GetMove(IEnumerable<IFrenchSuitedCard> playedCards, List<IFrenchSuitedCard> hand)
        {
            _playedCards = playedCards.ToList();
            _hand = hand.ToList();

            if (IsOpeningMove())
            {
                if (IsHoldingOpeningCard()) return OpeningCard();
                throw new KnockException();
            } 

            return GetFirstPlayableCard();
        }
    }
}
