using Bjss.Library.Cards.Contracts;
using Bjss.Library.Cards.UnitTests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bjss.Library.Cards.Domain.UnitTests
{
    [TestClass]
    public class CardStackTests
    {
        [TestMethod]
        public void GIVEN_new_card_stack_WHEN_has_cards_is_called_THEN_false_is_returned()
        {
            // Arrange
            var cardStack = new CardStack();

            // Act
            var result = cardStack.HasCards();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GIVEN_a_card_stack_WHEN_add_called_with_null_THEN_exception_is_thrown()
        {
            // Arrange
            var cardStack = new CardStack();

            // Act
            cardStack.Add(null);
        }

        [TestMethod]
        public void GIVEN_a_card_stack_WHEN_add_called_with_a_card_THEN_card_is_added()
        {
            // Arrange
            var fakeCard = new FakeCard(1, null);
            var cardStack = new CardStack();
            
            // Act
            cardStack.Add(fakeCard);
            var result = cardStack.HasCards();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GIVEN_a_card_stack_WHEN_AddRange_is_called_with_null_THEN_exception_is_thrown()
        {
            // Arrange
            var cardStack = new CardStack();

            // Act
            cardStack.AddRange(null);
        }

        [TestMethod]
        public void GIVEN_a_card_stack_WHEN_AddRange_is_called_with_a_card_THEN_card_is_added()
        {
            // Arrange
            var fakeCard1 = new FakeCard(1, null);
            var fakeCard2 = new FakeCard(2, null);
            var fakeCards = new List<ICard> {fakeCard1, fakeCard2};
            var cardStack = new CardStack();

            // Act
            cardStack.AddRange(fakeCards);
            var result = cardStack.HasCards();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GIVEN_a_card_stack_that_has_cards_WHEN_clear_is_called_THEN_stack_has_no_cards()
        {
            // Arrange
            var fakeCard1 = new FakeCard(1, null);
            var fakeCard2 = new FakeCard(2, null);
            var fakeCards = new List<ICard> { fakeCard1, fakeCard2 };
            var cardStack = new CardStack();
            cardStack.AddRange(fakeCards);

            // Act
            cardStack.Clear();
            var result = cardStack.HasCards();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GIVEN_new_card_stack_WHEN_get_cards_is_called_THEN_no_cards_are_returned()
        {
            // Arrange
            var cardStack = new CardStack();

            // Act
            var result = cardStack.GetCards();

            // Assert
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GIVEN_a_card_stack_that_has_a_card_WHEN_get_cards_is_called_THEN_a_card_is_returned()
        {
            // Arrange
            var fakeCard = new FakeCard(1, null);
            var cardStack = new CardStack();
            cardStack.Add(fakeCard);

            // Act
            var result = cardStack.GetCards().ToList();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Fake1", result.First().Name);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GIVEN_a_card_stack_with_no_cards_WHEN_top_card_is_called_THEN_exception_is_thrown()
        {
            // Arrange
            var cardStack = new CardStack();

            // Act
            var _ = cardStack.TopCard();
        }

        [TestMethod]
        public void GIVEN_a_card_stack_with_one_card_WHEN_top_card_is_called_THEN_card_is_returned()
        {
            // Arrange
            var fakeCard = new FakeCard(1, null);
            var cardStack = new CardStack();
            cardStack.Add(fakeCard);

            // Act

            var result = cardStack.TopCard();

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void GIVEN_a_card_stack_with_two_cards_WHEN_top_card_is_called_THEN_last_card_added_is_returned()
        {
            // Arrange
            var fakeCard1 = new FakeCard(1, null);
            var fakeCard2 = new FakeCard(2, null);
            var cardStack = new CardStack();
            cardStack.Add(fakeCard1);
            cardStack.Add(fakeCard2);

            // Act

            var result = cardStack.TopCard();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Fake2", result.Name);
        }
    }
}
