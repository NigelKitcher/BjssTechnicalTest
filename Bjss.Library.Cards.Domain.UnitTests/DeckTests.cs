using Bjss.Library.Cards.Contracts;
using Bjss.Library.Cards.UnitTests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Bjss.Library.Cards.Domain.UnitTests
{
    [TestClass]
    public class DeckTests
    {

        [TestMethod]
        [ExpectedException(typeof(DeckNotOpenedException))]
        public void GIVEN_an_unopened_deck_from_a_pack_WHEN_count_is_called_THEN_deck_not_opened_exception_thrown()
        {
            // Arrange
            var fakePack = new FakePack();

            // Act
            var deck = new Deck<IFakeCard>(fakePack);
            var _ = deck.CardCount;
        }

        [TestMethod] public void GIVEN_new_deck_from_a_pack_WHEN_count_is_called_THEN_count_equals_number_in_pack()
        {
            // Arrange
            var fakePack = new FakePack();
            var expectedNumberInPack = fakePack.NumberInPack;
            
            // Act
            var deck = new Deck<IFakeCard>(fakePack);
            deck.OpenDeck();
            var result = deck.CardCount;

            // Assert
            Assert.AreEqual(expectedNumberInPack, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DeckNotOpenedException))]
        public void GIVEN_an_unopened_deck_WHEN_deal_is_called_THEN_deck_not_opened_exception_thrown()
        {
            // Arrange
            var fakePack = new FakePack();

            // Act
            var deck = new Deck<IFakeCard>(fakePack);
            deck.Deal();
        }


        [TestMethod]
        public void GIVEN_new_deck_WHEN_deal_is_called_THEN_top_card_is_returned()
        {
            // Arrange
            var fakePack = new FakePack();
            var deck = new Deck<IFakeCard>(fakePack);
            deck.OpenDeck();

            // Act
            var result = deck.Deal();

            // Assert
            Assert.AreEqual("Fake1", result.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfCardsException))]
        public void GIVEN_a_4_card_deck_WHEN_deal_is_called_5_times_THEN_out_of_cards_exception_is_thrown()
        {
            // Arrange
            var fakePack = new FakePack();
            var deck = new Deck<IFakeCard>(fakePack);
            deck.OpenDeck();

            // Act
            deck.Deal();
            deck.Deal();
            deck.Deal();
            deck.Deal();
            deck.Deal();

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(DeckNotOpenedException))]
        public void GIVEN_an_unopened_deck_WHEN_add_cards_is_called_with_collection_containing_a_different_type_of_card_THEN_out_of_cards_exception_is_thrown()
        {
            // Arrange
            var fakePack = new FakePack();
            var deck = new Deck<IFakeCard>(fakePack);

            var cards = new List<IFakeCard>
            {
                new FakeCard(1, null),
            };

            // Act
            deck.AddCards(cards);
        }

        [TestMethod]
        public void GIVEN_a_deck_WHEN_add_cards_is_called_with_collection_THEN_cards_are_added()
        {
            // Arrange
            var fakePack = new FakePack();
            var deck = new Deck<IFakeCard>(fakePack);
            deck.OpenDeck();

            var cards = new List<IFakeCard>
            {
                new FakeCard(1, null),
            };

            // Act
            deck.AddCards(cards);
            var result = deck.CardCount;

            // Assert
            Assert.AreEqual(5, result);
        }

        //[TestMethod]
        //[ExpectedException(typeof(InvalidCardException))]
        //public void GIVEN_a_deck_WHEN_add_cards_is_called_with_collection_containing_a_different_type_of_card_THEN_out_of_cards_exception_is_thrown()
        //{
        //    // Arrange
        //    var fakePack = new FakePack();
        //    var deck = new Deck<IFakeCard>(fakePack);
        //    deck.OpenDeck();

        //    var cardsNotFromThisDecksPack = new List<IFakeCard>
        //    {
        //        new FakeCard(1, null),
        //        new FakeInvalidCard(1, null)
        //    };

        //    // Act
        //    deck.AddCards(cardsNotFromThisDecksPack);
        //}

        [TestMethod]
        public void GIVEN_a_deck_WHEN_add_cards_is_called_THEN_cards_are_added()
        {
            // Arrange
            var fakePack = new FakePack();
            var deck = new Deck<IFakeCard>(fakePack);
            deck.OpenDeck();

            var cards = new List<IFakeCard>
            {
                new FakeCard(1, null),
                new FakeCard(2, null),
            };

            // Act
            deck.AddCards(cards);
            var result = deck.CardCount;

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GIVEN_a_deck_WHEN_shuffle_is_called_with_a_null_strategy_THEN_exception_is_thrown()
        {
            // Arrange
            var fakePack = new FakePack();
            var deck = new Deck<IFakeCard>(fakePack);
            deck.OpenDeck();

            // Act
            deck.Shuffle(null);
        }

        [TestMethod]
        [ExpectedException(typeof(DeckNotOpenedException))]
        public void GIVEN_an_unopened_deck_WHEN_shuffle_THEN_exception_is_thrown()
        {
            // Arrange
            var fakePack = new FakePack();
            var fakeShuffleStrategy = new FakeShuffleStrategy();
            var deck = new Deck<IFakeCard>(fakePack);

            // Act
            deck.Shuffle(fakeShuffleStrategy);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFullDeckException))]
        public void GIVEN_a_deck_which_had_dealt_a_card_WHEN_shuffle_THEN_exception_is_thrown()
        {
            // Arrange
            var fakePack = new FakePack();
            var fakeShuffleStrategy = new FakeShuffleStrategy();
            var deck = new Deck<IFakeCard>(fakePack);
            deck.OpenDeck();
            deck.Deal();

            // Act
            deck.Shuffle(fakeShuffleStrategy);
        }

        [TestMethod]
        public void GIVEN_a_full_deck_WHEN_shuffle_THEN_shuffle_on_shuffle_strategy_is_called()
        {
            // Arrange
            var fakePack = new FakePack();
            var deck = new Deck<IFakeCard>(fakePack);
            var mockShuffleStrategy = new Mock<IShuffleStrategy<IFakeCard>>();
            deck.OpenDeck();

            // Act
            deck.Shuffle(mockShuffleStrategy.Object);

            // Assert
            mockShuffleStrategy.Verify(s => s.Shuffle(It.IsAny<IList<IFakeCard>>()));
        }

        [TestMethod]
        public void GIVEN_a_deck_with_unordered_cards_WHEN_sort_is_called_THEN_deck_is_sorted_in_order()
        {
            // Arrange
            var fakePack = new FakePack();
            var deck = new Deck<IFakeCard>(fakePack);
            deck.OpenDeck();

            var card1 = deck.Deal();
            var card2 = deck.Deal();
            var card3 = deck.Deal();

            deck.AddCards(new List<IFakeCard> { card2, card1, card3});

            // Act
            deck.Sort();

            var firstCard = deck.Deal();
            var secondCard = deck.Deal();
            var thirdCard = deck.Deal();
            var fourthCard = deck.Deal();

            // Assert
            Assert.AreEqual(1, firstCard.Number);
            Assert.AreEqual(2, secondCard.Number);
            Assert.AreEqual(3, thirdCard.Number);
            Assert.AreEqual(4, fourthCard.Number);
        }
    }
}
