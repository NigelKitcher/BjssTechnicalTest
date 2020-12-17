using Bjss.Library.Cards.Contracts;
using Bjss.Sevens.Domain.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bjss.Sevens.Domain.UnitTests
{
    [TestClass]
    public class SevensGameServiceTests : BaseCardTests
    {
        private ISevensGameService _service;
        private string _eventString;
        private int _eventRaisedCount;
        private ICard _card;

        [TestInitialize]
        public void Initialise()
        {
            _service = new SevensGameService();
            _eventRaisedCount = 0;
            _service.CardPlayed += (sender, args) =>
            {
                _eventString = args.Card.Name;
                _card = args.Card;
                _eventRaisedCount++;
            };

            BaseInitialise();
        }

        [TestMethod]
        public void GIVEN_diamonds_has_not_been_played_WHEN_first_card_played_is_a_seven_of_diamonds_THEN_card_is_accepted()
        {
            // Arrange

            // Act
            _service.AcceptCard(SevenDiamonds.Object);

            // Assert
            Assert.AreEqual(1, _eventRaisedCount);
            Assert.AreEqual("7 Diamonds", _eventString);
            Assert.AreEqual(SevenDiamonds.Object, _card);
        }

        [TestMethod, ExpectedException(typeof(InvalidMoveException))]
        public void GIVEN_diamonds_has_not_been_played_WHEN_first_card_played_is_a_six_of_diamonds_THEN_exception_is_thrown()
        {
            // Arrange

            // Act
            _service.AcceptCard(SixDiamonds.Object);

            // Assert
        }

        [TestMethod, ExpectedException(typeof(InvalidMoveException))]
        public void GIVEN_a_card_has_been_played_WHEN_the_same_card_is_tried_to_be_played_again_THEN_exception_is_thrown()
        {
            // Arrange
            _service.AcceptCard(SevenDiamonds.Object);

            // Act
            _service.AcceptCard(SevenDiamonds.Object);

            // Assert
        }

        [TestMethod]
        public void GIVEN_a_card_has_been_played_WHEN_adjoining_lower_card_is_played_THEN_card_is_accepted()
        {
            // Arrange
            _service.AcceptCard(SevenDiamonds.Object);
            _eventRaisedCount = 0;

            // Act
            _service.AcceptCard(SixDiamonds.Object);

            // Assert
            Assert.AreEqual(1, _eventRaisedCount);
        }

        [TestMethod, ExpectedException(typeof(InvalidMoveException))]
        public void GIVEN_a_card_has_been_played_WHEN_non_adjoining_lower_card_is_played_THEN_exception_is_thrown()
        {
            // Arrange
            _service.AcceptCard(SevenDiamonds.Object);

            // Act
            _service.AcceptCard(FiveDiamonds.Object);

            // Assert
        }

        [TestMethod]
        public void GIVEN_a_card_has_been_played_WHEN_adjoining_higher_card_is_played_THEN_card_is_accepted()
        {
            // Arrange
            _service.AcceptCard(SevenDiamonds.Object);
            _eventRaisedCount = 0;

            // Act
            _service.AcceptCard(EightDiamonds.Object);

            // Assert
            Assert.AreEqual(1, _eventRaisedCount);
        }

        [TestMethod, ExpectedException(typeof(InvalidMoveException))]
        public void GIVEN_a_card_has_been_played_WHEN_non_adjoining_higher_card_is_played_THEN_exception_is_thrown()
        {
            // Arrange
            _service.AcceptCard(SevenDiamonds.Object);

            // Act
            _service.AcceptCard(NineDiamonds.Object);

            // Assert
        }

        [TestMethod, ExpectedException(typeof(InvalidMoveException))]
        public void GIVEN_a_card_has_been_played_of_one_suit_WHEN_playing_an_adjoining_rank_of_a_different_suit_Then_Exception_is_thrown()
        {
            // Arrange
            _service.AcceptCard(SevenDiamonds.Object);

            // Act
            _service.AcceptCard(EightHearts.Object);

            // Assert
        }

        [TestMethod]
        public void GIVEN_cards_played_down_to_the_two_and_ace_is_low_WHEN_ace_is_played_THEN_card_is_accepted()
        {
            // Arrange
            _service.AcceptCard(SevenDiamonds.Object);
            _service.AcceptCard(SixDiamonds.Object);
            _service.AcceptCard(FiveDiamonds.Object);
            _service.AcceptCard(FourDiamonds.Object);
            _service.AcceptCard(ThreeDiamonds.Object);
            _service.AcceptCard(TwoDiamonds.Object);

            _eventRaisedCount = 0;

            // Act
            _service.AcceptCard(AceDiamonds.Object);

            // Assert
            Assert.AreEqual(1, _eventRaisedCount);
        }

        [TestMethod, ExpectedException(typeof(InvalidMoveException))]
        public void GIVEN_cards_played_up_to_the_king_and_ace_is_low_WHEN_ace_is_played_THEN_exception_is_thrown()
        {
            // Arrange
            _service.AcceptCard(SevenDiamonds.Object);
            _service.AcceptCard(EightDiamonds.Object);
            _service.AcceptCard(NineDiamonds.Object);
            _service.AcceptCard(TenDiamonds.Object);
            _service.AcceptCard(JackDiamonds.Object);
            _service.AcceptCard(QueenDiamonds.Object);
            _service.AcceptCard(KingDiamonds.Object);

            // Act
            _service.AcceptCard(AceDiamonds.Object);

            // Assert
        }
    }
}

