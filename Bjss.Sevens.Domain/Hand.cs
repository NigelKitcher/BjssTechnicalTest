using Bjss.Library.Cards.FrenchSuited;
using System.Collections.Generic;
using System.Linq;
using Bjss.Sevens.Domain.Contracts;

namespace Bjss.Sevens.Domain
{
    public class Hand : IHand
    {
        public List<IFrenchSuitedCard> Cards { get; }

        public Hand()
        {
            Cards = new List<IFrenchSuitedCard>();
        }

        public Hand(List<IFrenchSuitedCard> hand)
        {
            Cards = hand;
        }

        public bool IsHoldingOpeningCard()
        {
            return Cards.Any(x => x.Suit == GameRules.OpeningSuit && x.Rank == GameRules.FirstRank);
        }

        public IFrenchSuitedCard GetOpeningCard()
        {
            return Cards.FirstOrDefault(x => x.Suit == GameRules.OpeningSuit && x.Rank == GameRules.FirstRank);
        }

        public void RemoveCard(IFrenchSuitedCard card)
        {
            Cards.Remove(card);
        }

        public bool IsHoldingKing(Suit suit)
        {
            return Cards.Any(x => x.Rank == Rank.King && x.Suit == suit);
        }

        public bool IsHoldingAce(Suit suit)
        {
            return Cards.Any(x => x.Rank == Rank.Ace && x.Suit == suit);
        }

        public int CountOfHigherCards(IFrenchSuitedCard card)
        {
            return Cards.Count(x => card.Suit == x.Suit && card.Rank > Rank.Seven && card.Rank < x.Rank);
        }

        public int CountOfLowerCards(IFrenchSuitedCard card)
        {
            return Cards.Count(x => card.Suit == x.Suit && card.Rank < Rank.Seven && card.Rank > x.Rank);
        }

        public IList<IFrenchSuitedCard> GetStartingCards()
        {
            return Cards.Where(x => x.Rank == GameRules.FirstRank).ToList();
        }
    }
}
