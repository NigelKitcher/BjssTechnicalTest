using Bjss.Library.Cards.FrenchSuited;
using Bjss.Sevens.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bjss.Sevens.Domain
{
    /// <summary>
    /// Advanced Game play
    /// </summary>
    /// <remarks>
    /// This provides the advanced game play for the game of "Sevens"
    /// The card selected for a given will move will preferably a card that advances play towards a King or Ace if we hold either of those cards
    /// In addition the card selected will also be the card that provides opportunity to play more cards in the future.
    /// TODO: Game play is a bit predictable and would be better if injected the IRandomGenerator to chose a card at random when they are equally rated
    /// </remarks>
    /// <seealso cref="Bjss.Sevens.Domain.Contracts.IGamePlayStrategy" />
    public class AdvancedGamePlayStrategy : IGamePlayStrategy
    {
        private class ScoreCard
        {
            public IFrenchSuitedCard Card { get; }
            public int Score { get; set; }

            public ScoreCard(IFrenchSuitedCard card)
            {
                Card = card;
                Score = 0;
            }
        }

        private IList<IFrenchSuitedCard> _playedCards;

        private IHand _playersHand;

        private bool IsOpeningMove() => _playedCards.Count == 0;

        private bool IsCardsAdjacent(IFrenchSuitedCard cardA, IFrenchSuitedCard cardB)
        {
            return (Math.Abs(cardA.Rank - cardB.Rank) == 1) && cardA.Suit == cardB.Suit;
        }

        private IList<IFrenchSuitedCard> GetCardsInHandAdjacentToPlayedCards()
        {
            var cards = new List<IFrenchSuitedCard>();
            foreach (var card in _playersHand.Cards)
            {
                if (_playedCards.Any(x => IsCardsAdjacent(x, card)))
                {
                    cards.Add(card);
                }
            }

            return cards;
        }

        private IList<IFrenchSuitedCard> GetPlayableCards()
        {
            var playableCards = new List<IFrenchSuitedCard>();
            playableCards.AddRange(GetCardsInHandAdjacentToPlayedCards());
            playableCards.AddRange(_playersHand.GetStartingCards());

            if (playableCards.Count == 0) throw new KnockException();

            return playableCards;
        }

        private List<ScoreCard> GetScoreCards(IList<IFrenchSuitedCard> cards)
        {
            var scoreCards = new List<ScoreCard>();
            foreach (var card in cards)
            {
                scoreCards.Add(new ScoreCard(card));
            }

            return scoreCards;
        }

        private void PreferEndHoldingAdvancementCards(IList<ScoreCard> scoreCards)
        {
            foreach (ScoreCard scoreCard in scoreCards)
            {
                var card = scoreCard.Card;
                var isHoldingKing = _playersHand.IsHoldingKing(card.Suit);
                var isHoldingAce = _playersHand.IsHoldingAce(card.Suit);

                var isHoldingKingAndHeadingTowardsIt = isHoldingKing && card.Rank >= Rank.Seven;
                var isHoldingAceAndHeadingTowardsIt = isHoldingAce && card.Rank <= Rank.Seven;

                if (isHoldingKingAndHeadingTowardsIt || isHoldingAceAndHeadingTowardsIt)
                {
                    scoreCard.Score++;
                }
            }
        }

        private int CountOfFutureCards(IFrenchSuitedCard card)
        {
            if (card.Rank > Rank.Seven)
            {
                return _playersHand.CountOfHigherCards(card);
            }

            if (card.Rank < Rank.Seven)
            {
                return _playersHand.CountOfLowerCards(card);
            }

            return 0;
        }

        private void PreferCardsWhereHaveMoreCardsToPlayInFuture(IList<ScoreCard> scoreCards)
        {
            foreach (var scoreCard in scoreCards)
            {
                var card = scoreCard.Card;
                scoreCard.Score += CountOfFutureCards(card);
            }
        }

        private void PreferEndCards(IList<ScoreCard> scoreCards)
        {
            foreach (var scoreCard in scoreCards)
            {
                var card = scoreCard.Card;
                if (card.Rank == Rank.King || card.Rank == Rank.Ace)
                {
                    scoreCard.Score += 5;
                }
            }
        }

        private IFrenchSuitedCard GetOptimalCard()
        {
            var playableCards = GetPlayableCards();

            var scoreCards = GetScoreCards(playableCards);
            PreferEndCards(scoreCards);
            PreferEndHoldingAdvancementCards(scoreCards);
            PreferCardsWhereHaveMoreCardsToPlayInFuture(scoreCards);

            return scoreCards.OrderByDescending(x => x.Score).First().Card;
        }

        public IFrenchSuitedCard GetMove(IEnumerable<IFrenchSuitedCard> playedCards, List<IFrenchSuitedCard> hand)
        {
            _playedCards = playedCards.ToList();
            _playersHand = new Hand(hand);

            if (IsOpeningMove())
            {
                if (_playersHand.IsHoldingOpeningCard()) return _playersHand.GetOpeningCard();
                throw new KnockException();
            }

            return GetOptimalCard();
        }
    }
}
