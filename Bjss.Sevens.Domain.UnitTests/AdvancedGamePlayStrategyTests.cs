using System.Collections.Generic;
using Bjss.Library.Cards.FrenchSuited;
using Bjss.Sevens.Domain.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Bjss.Sevens.Domain.UnitTests
{
    [TestClass]
    public class AdvancedGamePlayStrategyTests : BaseCardTests
    {
        private IGamePlayStrategy _advancedGamePlayStrategy;
        private Mock<IFrenchSuitedCard> _openingCard;

        [TestInitialize]
        public void Initialise()
        {
            _advancedGamePlayStrategy = new AdvancedGamePlayStrategy();

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
            var card = _advancedGamePlayStrategy.GetMove(playedCards, hand);

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
            var card = _advancedGamePlayStrategy.GetMove(playedCards, hand);

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
            var card = _advancedGamePlayStrategy.GetMove(playedCards, hand);

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
            var card = _advancedGamePlayStrategy.GetMove(playedCards, hand);

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
            var card = _advancedGamePlayStrategy.GetMove(playedCards, hand);

            // Assert
        }

        [TestMethod]
        public void GIVEN_choice_of_playing_two_cards_WHEN_holding_a_King_THEN_card_towards_the_king_is_chosen()
        {
            // Arrange
            var playedCards = new List<IFrenchSuitedCard>
            {
                SevenDiamonds.Object
            };

            var hand = new List<IFrenchSuitedCard>
            {
                KingDiamonds.Object,
                EightDiamonds.Object,
                SixDiamonds.Object
            };

            // Act
            var card = _advancedGamePlayStrategy.GetMove(playedCards, hand);

            // Assert
            Assert.AreEqual(Rank.Eight, card.Rank);
            Assert.AreEqual(Suit.Diamonds, card.Suit);
        }

        [TestMethod]
        public void GIVEN_choice_of_playing_two_cards_WHEN_holding_an_Ace_THEN_card_towards_the_Ace_is_chosen()
        {
            // Arrange
            var playedCards = new List<IFrenchSuitedCard>
            {
                SevenDiamonds.Object
            };

            var hand = new List<IFrenchSuitedCard>
            {
                AceDiamonds.Object,
                EightDiamonds.Object,
                SixDiamonds.Object
            };

            // Act
            var card = _advancedGamePlayStrategy.GetMove(playedCards, hand);

            // Assert
            Assert.AreEqual(Rank.Six, card.Rank);
            Assert.AreEqual(Suit.Diamonds, card.Suit);
        }

        [TestMethod]
        public void GIVEN_choice_of_playing_two_cards_WHEN_holding_more_higher_cards_to_play_THEN_higher_card_is_chosen()
        {
            // Arrange
            var playedCards = new List<IFrenchSuitedCard>
            {
                SevenDiamonds.Object
            };

            var hand = new List<IFrenchSuitedCard>
            {
                NineDiamonds.Object,
                EightDiamonds.Object,
                SixDiamonds.Object
            };

            // Act
            var card = _advancedGamePlayStrategy.GetMove(playedCards, hand);

            // Assert
            Assert.AreEqual(Rank.Eight, card.Rank);
            Assert.AreEqual(Suit.Diamonds, card.Suit);
        }

        [TestMethod]
        public void GIVEN_choice_of_playing_two_cards_WHEN_holding_more_lower_cards_to_play_THEN_lower_card_is_chosen()
        {
            // Arrange
            var playedCards = new List<IFrenchSuitedCard>
            {
                SevenDiamonds.Object
            };

            var hand = new List<IFrenchSuitedCard>
            {
                EightDiamonds.Object,
                SixDiamonds.Object,
                FiveDiamonds.Object
            };

            // Act
            var card = _advancedGamePlayStrategy.GetMove(playedCards, hand);

            // Assert
            Assert.AreEqual(Rank.Six, card.Rank);
            Assert.AreEqual(Suit.Diamonds, card.Suit);
        }

        [TestMethod]
        public void GIVEN_choice_of_playing_two_cards_WHEN_one_card_is_a_King_THEN_the_King_is_chosen()
        {
            // Arrange
            var playedCards = new List<IFrenchSuitedCard>
            {
                SevenHearts.Object,
                QueenDiamonds.Object
            };

            var hand = new List<IFrenchSuitedCard>
            {
                EightHearts.Object,
                KingDiamonds.Object,
            };

            // Act
            var card = _advancedGamePlayStrategy.GetMove(playedCards, hand);

            // Assert
            Assert.AreEqual(Rank.King, card.Rank);
            Assert.AreEqual(Suit.Diamonds, card.Suit);
        }

        [TestMethod]
        public void GIVEN_choice_of_playing_two_cards_WHEN_one_card_is_an_Ace_Then_the_Ace_is_chosen()
        {
            // Arrange
            var playedCards = new List<IFrenchSuitedCard>
            {
                SevenHearts.Object,
                TwoDiamonds.Object
            };

            var hand = new List<IFrenchSuitedCard>
            {
                EightHearts.Object,
                AceDiamonds.Object,
            };

            // Act
            var card = _advancedGamePlayStrategy.GetMove(playedCards, hand);

            // Assert
            Assert.AreEqual(Rank.Ace, card.Rank);
            Assert.AreEqual(Suit.Diamonds, card.Suit);
        }

        [TestMethod]
        public void GIVEN_choice_of_playing_of_two_sevens_WHEN_we_hold_an_ace_card_THEN_seven_of_that_suit_is_returned()
        {
            // Arrange
            var playedCards = new List<IFrenchSuitedCard>
            {
                SevenDiamonds.Object
            };

            var hand = new List<IFrenchSuitedCard>()
            {
                TwoHearts.Object,
                FourHearts.Object,
                SevenHearts.Object,
                AceSpades.Object,
                SevenSpades.Object,
                TenSpades.Object
            };

            // Act
            var card = _advancedGamePlayStrategy.GetMove(playedCards, hand);

            // Assert
            Assert.AreEqual(Rank.Seven, card.Rank);
            Assert.AreEqual(Suit.Spades, card.Suit);
        }

        [TestMethod]
        public void GIVEN_choice_of_playing_of_two_sevens_WHEN_we_hold_a_king_card_THEN_seven_of_that_suit_is_returned()
        {
            // Arrange
            var playedCards = new List<IFrenchSuitedCard>
            {
                SevenDiamonds.Object
            };

            var hand = new List<IFrenchSuitedCard>()
            {
                TwoHearts.Object,
                FourHearts.Object,
                SevenHearts.Object,
                SixSpades.Object,
                SevenSpades.Object,
                KingSpades.Object
            };

            // Act
            var card = _advancedGamePlayStrategy.GetMove(playedCards, hand);

            // Assert
            Assert.AreEqual(Rank.Seven, card.Rank);
            Assert.AreEqual(Suit.Spades, card.Suit);
        }

        [TestMethod]
        public void GIVEN_choice_of_playing_of_more_than_one_seven_WHEN_they_are_equally_valid_THEN_first_seven_in_hand_is_returned()
        {
            // Arrange
            var playedCards = new List<IFrenchSuitedCard>
            {
                SevenDiamonds.Object
            };

            var hand = new List<IFrenchSuitedCard>()
            {
                SixHearts.Object,
                SevenHearts.Object,
                SixSpades.Object,
                SevenSpades.Object,
            };

            // Act
            var card = _advancedGamePlayStrategy.GetMove(playedCards, hand);

            // Assert
            Assert.AreEqual(Rank.Seven, card.Rank);
            Assert.AreEqual(Suit.Hearts, card.Suit);
        }
    }
}