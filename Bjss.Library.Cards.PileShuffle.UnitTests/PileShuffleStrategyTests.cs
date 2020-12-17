using Bjss.Library.Cards.Contracts;
using Bjss.Library.Cards.UnitTests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Bjss.Library.Cards.PileShuffle.UnitTests
{
    [TestClass]
    public class PileShuffleStrategyTests
    {
        [TestMethod]
        public void GIVEN_a_pileShuffleStrategy_WHEN_Shuffle_is_called_THEN_cards_are_shuffled()
        {
            // Arrange
            var mockRandomGenerator = new Mock<IRandomGenerator>();

            var fakeCard1 = new FakeCard(1);
            var fakeCard2 = new FakeCard(2);
            var fakeCard3 = new FakeCard(3);
            var fakeCard4 = new FakeCard(4);
            var fakeCard5 = new FakeCard(5);

            var fakeCards = new List<ICard>() {fakeCard1, fakeCard2, fakeCard3, fakeCard4, fakeCard5};

            var randomListOfPiles = new Queue<int>();
            randomListOfPiles.Enqueue(1);
            randomListOfPiles.Enqueue(1);
            randomListOfPiles.Enqueue(0);
            randomListOfPiles.Enqueue(2);
            randomListOfPiles.Enqueue(0);

            mockRandomGenerator.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(randomListOfPiles.Dequeue);

            var pileShuffleStrategy = new PileShuffleStrategy<ICard>(mockRandomGenerator.Object);

            // Pile0  Pile1  Pile2
            //
            //    5     2
            //    3     1      4    
            //
            // This gives order on picking up piles (top of stack to the left)
            // 5, 3
            // 2, 1, 5, 3
            // 4, 2, 1, 5, 3


            // Act
            var result = pileShuffleStrategy.Shuffle(fakeCards);

            // Assert
            Assert.AreEqual(4, result.Pop().Number);
            Assert.AreEqual(2, result.Pop().Number);
            Assert.AreEqual(1, result.Pop().Number);
            Assert.AreEqual(5, result.Pop().Number);
            Assert.AreEqual(3, result.Pop().Number);
        }
    }
}
