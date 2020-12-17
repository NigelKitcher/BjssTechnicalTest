using Bjss.Library.Cards.FrenchSuited;
using Bjss.Sevens.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bjss.Sevens.Domain
{
    public class SevensGameService : ISevensGameService
    {
        private const Rank OpeningMoveRank = Rank.Seven;

        private Dictionary<Suit, List<IFrenchSuitedCard>> _playedCards;

        public event EventHandler<CardPlayedAcceptedEventArgs> CardPlayed;

        public SevensGameService()
        {
           NewGame();
        }

        public void NewGame()
        {
            _playedCards = new Dictionary<Suit, List<IFrenchSuitedCard>>
            {
                [Suit.Clubs] = new List<IFrenchSuitedCard>(),
                [Suit.Diamonds] = new List<IFrenchSuitedCard>(),
                [Suit.Hearts] = new List<IFrenchSuitedCard>(),
                [Suit.Spades] = new List<IFrenchSuitedCard>()
            };
        }

        private bool IsOpeningMove()
        {
            return (_playedCards[Suit.Clubs].Count + _playedCards[Suit.Diamonds].Count +
                    _playedCards[Suit.Hearts].Count + _playedCards[Suit.Spades].Count) == 0;
        }

        private bool IsOpeningMoveCard(IFrenchSuitedCard card)
        {
            return card.Suit == GameRules.OpeningSuit && card.Rank == GameRules.FirstRank;
        }

        private bool IsStartingMoveOnSuit(IFrenchSuitedCard card)
        {
            return _playedCards[card.Suit].Count == 0;
        }

        private bool IsNotValidOpeningCard(IFrenchSuitedCard card)
        {
            return card.Rank != OpeningMoveRank;
        }

        private bool HasCardBeenPlayedAlready(IFrenchSuitedCard card)
        {
            var b = _playedCards[card.Suit].Any(x => x.Rank == card.Rank);
            return b;
        }

        private bool IsCardNotAdjacentToExistingCard(IFrenchSuitedCard card)
        {
            var playedSuit = _playedCards[card.Suit];
            var isAdjacent = playedSuit.Any(x => Math.Abs(x.Rank - card.Rank) == 1);
            return !isAdjacent;
        }

        private void AddCardToPlayed(IFrenchSuitedCard card)
        {
            _playedCards[card.Suit].Add(card);
        }

        public List<IFrenchSuitedCard> PlayedCards
        {
            get
            {
                var x = new List<IFrenchSuitedCard>();
                x.AddRange(_playedCards[Suit.Clubs]);
                x.AddRange(_playedCards[Suit.Diamonds]);
                x.AddRange(_playedCards[Suit.Hearts]);
                x.AddRange(_playedCards[Suit.Spades]);
                return x;
            }
        }

        public void AcceptCard(IFrenchSuitedCard card)
        {
            if (IsOpeningMove() && !IsOpeningMoveCard(card)) throw new InvalidMoveException($"Can not play '{card.Name}' as opening move");

            if (IsStartingMoveOnSuit(card))
            {
                if (IsNotValidOpeningCard(card)) throw new InvalidMoveException($"Opening move for a suit must be a {OpeningMoveRank}");
            }
            else
            {
                if (HasCardBeenPlayedAlready(card)) throw new InvalidMoveException($"Card '{card.Name}' has already been played");
                if (IsCardNotAdjacentToExistingCard(card)) throw new InvalidMoveException($"Card '{card.Name}' is not adjacent to a previously played card");
            }

            AddCardToPlayed(card);

            OnCardAccepted(this, new CardPlayedAcceptedEventArgs(card));
        }

        public void OnCardAccepted(object sender, CardPlayedAcceptedEventArgs e)
        {
            CardPlayed?.Invoke(sender, e);
        }
    }
}
