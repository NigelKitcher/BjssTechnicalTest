using System.Collections.Generic;
using Bjss.Library.Cards.FrenchSuited;
using Bjss.Sevens.Domain.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Bjss.Sevens.Domain.UnitTests
{
    [TestClass]
    public class BasicGamePlayStrategyTests : BaseCardTests
    {
        private IGamePlayStrategy _basicGamePlayStrategy;
        private Mock<IFrenchSuitedCard> _openingCard;

        [TestInitialize]
        public void Initialise()
        {
            _basicGamePlayStrategy = new BasicGamePlayStrategy();

            _openingCard = new Mock<IFrenchSuitedCard>();
            _openingCard.Setup(x => x.Suit).Returns(GameRules.OpeningSuit);
            _openingCard.Setup(x => x.Rank).Returns(GameRules.FirstRank);

            BaseInitialise();
        }

        [TestMethod]
        public void GIVEN_no_cards_have_been_played_WHEN_hand_contains_opening_card_THEN_card_is_played()
        {
            // Arrange
            var playedCards = new List<IFrenchSuitedCard>(); 
            var hand = new List<IFrenchSuitedCard>();
            hand.Add(_openingCard.Object);

            // Act
            var card = _basicGamePlayStrategy.GetMove(playedCards, hand);

            // Assert   
            Assert.AreEqual(GameRules.FirstRank, card.Rank);
            Assert.AreEqual(GameRules.OpeningSuit, card.Suit);
        }

        [TestMethod, ExpectedException(typeof(KnockException))]
        public void GIVEN_no_cards_have_been_played_WHEN_hand_does_not_contain_opening_card_THEN_exception_thrown()
        {
            // Arrange
            var playedCards = new List<IFrenchSuitedCard>();
            var hand = new List<IFrenchSuitedCard>();

            // Act
            var card = _basicGamePlayStrategy.GetMove(playedCards, hand);

            // Assert   
        }

        [TestMethod]
        public void GIVEN_cards_have_been_played_WHEN_hand_contains_an_adjacent_card_THEN_card_is_played()
        {
            // Arrange
            var playedCards = new List<IFrenchSuitedCard>
            {
                SevenDiamonds.Object
            };

            var hand = new List<IFrenchSuitedCard>
            {
                EightDiamonds.Object
            };

            // Act
            var card = _basicGamePlayStrategy.GetMove(playedCards, hand);

            // Assert
            Assert.AreEqual(Rank.Eight, card.Rank);
            Assert.AreEqual(Suit.Diamonds, card.Suit);
        }

        [TestMethod]
        public void GIVEN_cards_have_been_played_WHEN_hand_does_not_contain_an_adjacent_card_but_does_contain_an_opening_card_THEN_card_is_played()
        {
            // Arrange
            var playedCards = new List<IFrenchSuitedCard>
            {
                SevenDiamonds.Object
            };

            var hand = new List<IFrenchSuitedCard>
            {
                SevenHearts.Object
            };

            // Act
            var card = _basicGamePlayStrategy.GetMove(playedCards, hand);

            // Assert
            Assert.AreEqual(Rank.Seven, card.Rank);
            Assert.AreEqual(Suit.Hearts, card.Suit);
        }

        [TestMethod, ExpectedException(typeof(KnockException))]
        public void GIVEN_cards_have_been_played_WHEN_hand_does_not_contain_an_adjacent_card_or_an_opening_card_THEN_exception_thrown()
        {
            // Arrange
            var playedCards = new List<IFrenchSuitedCard>
            {
                SevenDiamonds.Object
            };

            var hand = new List<IFrenchSuitedCard>
            {
                TenDiamonds.Object
            };

            // Act
            var card = _basicGamePlayStrategy.GetMove(playedCards, hand);

            // Assert
        }
    }
}
