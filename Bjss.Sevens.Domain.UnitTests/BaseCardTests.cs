using Bjss.Library.Cards.FrenchSuited;
using Moq;

namespace Bjss.Sevens.Domain.UnitTests
{
    public abstract class BaseCardTests
    {
        protected Mock<IFrenchSuitedCard> AceDiamonds;
        protected Mock<IFrenchSuitedCard> TwoDiamonds;
        protected Mock<IFrenchSuitedCard> ThreeDiamonds;
        protected Mock<IFrenchSuitedCard> FourDiamonds;
        protected Mock<IFrenchSuitedCard> FiveDiamonds;
        protected Mock<IFrenchSuitedCard> SixDiamonds;
        protected Mock<IFrenchSuitedCard> SevenDiamonds;
        protected Mock<IFrenchSuitedCard> EightDiamonds;
        protected Mock<IFrenchSuitedCard> NineDiamonds;
        protected Mock<IFrenchSuitedCard> TenDiamonds;
        protected Mock<IFrenchSuitedCard> JackDiamonds;
        protected Mock<IFrenchSuitedCard> QueenDiamonds;
        protected Mock<IFrenchSuitedCard> KingDiamonds;

        protected Mock<IFrenchSuitedCard> AceHearts;
        protected Mock<IFrenchSuitedCard> TwoHearts;
        protected Mock<IFrenchSuitedCard> ThreeHearts;
        protected Mock<IFrenchSuitedCard> FourHearts;
        protected Mock<IFrenchSuitedCard> FiveHearts;
        protected Mock<IFrenchSuitedCard> SixHearts;
        protected Mock<IFrenchSuitedCard> SevenHearts;
        protected Mock<IFrenchSuitedCard> EightHearts;
        protected Mock<IFrenchSuitedCard> NineHearts;
        protected Mock<IFrenchSuitedCard> TenHearts;
        protected Mock<IFrenchSuitedCard> JackHearts;
        protected Mock<IFrenchSuitedCard> QueenHearts;
        protected Mock<IFrenchSuitedCard> KingHearts;

        protected Mock<IFrenchSuitedCard> AceSpades;
        protected Mock<IFrenchSuitedCard> TwoSpades;
        protected Mock<IFrenchSuitedCard> ThreeSpades;
        protected Mock<IFrenchSuitedCard> FourSpades;
        protected Mock<IFrenchSuitedCard> FiveSpades;
        protected Mock<IFrenchSuitedCard> SixSpades;
        protected Mock<IFrenchSuitedCard> SevenSpades;
        protected Mock<IFrenchSuitedCard> EightSpades;
        protected Mock<IFrenchSuitedCard> NineSpades;
        protected Mock<IFrenchSuitedCard> TenSpades;
        protected Mock<IFrenchSuitedCard> JackSpades;
        protected Mock<IFrenchSuitedCard> QueenSpades;
        protected Mock<IFrenchSuitedCard> KingSpades;

        protected void BaseInitialise()
        {
            InitialiseHearts();
            InitialiseDiamonds();
            InitialiseSpades();
        }

        private void InitialiseHearts()
        {
            AceHearts = new Mock<IFrenchSuitedCard>();
            AceHearts.Setup(x => x.Rank).Returns(Rank.Ace);
            AceHearts.Setup(x => x.Suit).Returns(Suit.Hearts);

            TwoHearts = new Mock<IFrenchSuitedCard>();
            TwoHearts.Setup(x => x.Rank).Returns(Rank.Two);
            TwoHearts.Setup(x => x.Suit).Returns(Suit.Hearts);

            ThreeHearts = new Mock<IFrenchSuitedCard>();
            ThreeHearts.Setup(x => x.Rank).Returns(Rank.Three);
            ThreeHearts.Setup(x => x.Suit).Returns(Suit.Hearts);

            FourHearts = new Mock<IFrenchSuitedCard>();
            FourHearts.Setup(x => x.Rank).Returns(Rank.Four);
            FourHearts.Setup(x => x.Suit).Returns(Suit.Hearts);

            FiveHearts = new Mock<IFrenchSuitedCard>();
            FiveHearts.Setup(x => x.Rank).Returns(Rank.Five);
            FiveHearts.Setup(x => x.Suit).Returns(Suit.Hearts);

            SixHearts = new Mock<IFrenchSuitedCard>();
            SixHearts.Setup(x => x.Rank).Returns(Rank.Six);
            SixHearts.Setup(x => x.Suit).Returns(Suit.Hearts);

            SevenHearts = new Mock<IFrenchSuitedCard>();
            SevenHearts.Setup(x => x.Rank).Returns(Rank.Seven);
            SevenHearts.Setup(x => x.Suit).Returns(Suit.Hearts);

            EightHearts = new Mock<IFrenchSuitedCard>();
            EightHearts.Setup(x => x.Rank).Returns(Rank.Eight);
            EightHearts.Setup(x => x.Suit).Returns(Suit.Hearts);

            NineHearts = new Mock<IFrenchSuitedCard>();
            NineHearts.Setup(x => x.Rank).Returns(Rank.Nine);
            NineHearts.Setup(x => x.Suit).Returns(Suit.Hearts);

            TenHearts = new Mock<IFrenchSuitedCard>();
            TenHearts.Setup(x => x.Rank).Returns(Rank.Ten);
            TenHearts.Setup(x => x.Suit).Returns(Suit.Hearts);

            JackHearts = new Mock<IFrenchSuitedCard>();
            JackHearts.Setup(x => x.Rank).Returns(Rank.Jack);
            JackHearts.Setup(x => x.Suit).Returns(Suit.Hearts);

            QueenHearts = new Mock<IFrenchSuitedCard>();
            QueenHearts.Setup(x => x.Rank).Returns(Rank.Queen);
            QueenHearts.Setup(x => x.Suit).Returns(Suit.Hearts);

            KingHearts = new Mock<IFrenchSuitedCard>();
            KingHearts.Setup(x => x.Rank).Returns(Rank.King);
            KingHearts.Setup(x => x.Suit).Returns(Suit.Hearts);
        }

        private void InitialiseDiamonds()
        {
            AceDiamonds = new Mock<IFrenchSuitedCard>();
            AceDiamonds.Setup(x => x.Rank).Returns(Rank.Ace);
            AceDiamonds.Setup(x => x.Suit).Returns(Suit.Diamonds);

            TwoDiamonds = new Mock<IFrenchSuitedCard>();
            TwoDiamonds.Setup(x => x.Rank).Returns(Rank.Two);
            TwoDiamonds.Setup(x => x.Suit).Returns(Suit.Diamonds);

            ThreeDiamonds = new Mock<IFrenchSuitedCard>();
            ThreeDiamonds.Setup(x => x.Rank).Returns(Rank.Three);
            ThreeDiamonds.Setup(x => x.Suit).Returns(Suit.Diamonds);

            FourDiamonds = new Mock<IFrenchSuitedCard>();
            FourDiamonds.Setup(x => x.Rank).Returns(Rank.Four);
            FourDiamonds.Setup(x => x.Suit).Returns(Suit.Diamonds);

            FiveDiamonds = new Mock<IFrenchSuitedCard>();
            FiveDiamonds.Setup(x => x.Rank).Returns(Rank.Five);
            FiveDiamonds.Setup(x => x.Suit).Returns(Suit.Diamonds);

            SixDiamonds = new Mock<IFrenchSuitedCard>();
            SixDiamonds.Setup(x => x.Rank).Returns(Rank.Six);
            SixDiamonds.Setup(x => x.Suit).Returns(Suit.Diamonds);

            SevenDiamonds = new Mock<IFrenchSuitedCard>();
            SevenDiamonds.Setup(x => x.Rank).Returns(Rank.Seven);
            SevenDiamonds.Setup(x => x.Suit).Returns(Suit.Diamonds);
            SevenDiamonds.Setup(x => x.Name).Returns("7 Diamonds");

            EightDiamonds = new Mock<IFrenchSuitedCard>();
            EightDiamonds.Setup(x => x.Rank).Returns(Rank.Eight);
            EightDiamonds.Setup(x => x.Suit).Returns(Suit.Diamonds);

            NineDiamonds = new Mock<IFrenchSuitedCard>();
            NineDiamonds.Setup(x => x.Rank).Returns(Rank.Nine);
            NineDiamonds.Setup(x => x.Suit).Returns(Suit.Diamonds);

            TenDiamonds = new Mock<IFrenchSuitedCard>();
            TenDiamonds.Setup(x => x.Rank).Returns(Rank.Ten);
            TenDiamonds.Setup(x => x.Suit).Returns(Suit.Diamonds);

            JackDiamonds = new Mock<IFrenchSuitedCard>();
            JackDiamonds.Setup(x => x.Rank).Returns(Rank.Jack);
            JackDiamonds.Setup(x => x.Suit).Returns(Suit.Diamonds);

            QueenDiamonds = new Mock<IFrenchSuitedCard>();
            QueenDiamonds.Setup(x => x.Rank).Returns(Rank.Queen);
            QueenDiamonds.Setup(x => x.Suit).Returns(Suit.Diamonds);

            KingDiamonds = new Mock<IFrenchSuitedCard>();
            KingDiamonds.Setup(x => x.Rank).Returns(Rank.King);
            KingDiamonds.Setup(x => x.Suit).Returns(Suit.Diamonds);
        }

        private void InitialiseSpades()
        {
            AceSpades = new Mock<IFrenchSuitedCard>();
            AceSpades.Setup(x => x.Rank).Returns(Rank.Ace);
            AceSpades.Setup(x => x.Suit).Returns(Suit.Spades);

            TwoSpades = new Mock<IFrenchSuitedCard>();
            TwoSpades.Setup(x => x.Rank).Returns(Rank.Two);
            TwoSpades.Setup(x => x.Suit).Returns(Suit.Spades);

            ThreeSpades = new Mock<IFrenchSuitedCard>();
            ThreeSpades.Setup(x => x.Rank).Returns(Rank.Three);
            ThreeSpades.Setup(x => x.Suit).Returns(Suit.Spades);

            FourSpades = new Mock<IFrenchSuitedCard>();
            FourSpades.Setup(x => x.Rank).Returns(Rank.Four);
            FourSpades.Setup(x => x.Suit).Returns(Suit.Spades);

            FiveSpades = new Mock<IFrenchSuitedCard>();
            FiveSpades.Setup(x => x.Rank).Returns(Rank.Five);
            FiveSpades.Setup(x => x.Suit).Returns(Suit.Spades);

            SixSpades = new Mock<IFrenchSuitedCard>();
            SixSpades.Setup(x => x.Rank).Returns(Rank.Six);
            SixSpades.Setup(x => x.Suit).Returns(Suit.Spades);

            SevenSpades = new Mock<IFrenchSuitedCard>();
            SevenSpades.Setup(x => x.Rank).Returns(Rank.Seven);
            SevenSpades.Setup(x => x.Suit).Returns(Suit.Spades);
            SevenSpades.Setup(x => x.Name).Returns("7 Spades");

            EightSpades = new Mock<IFrenchSuitedCard>();
            EightSpades.Setup(x => x.Rank).Returns(Rank.Eight);
            EightSpades.Setup(x => x.Suit).Returns(Suit.Spades);

            NineSpades = new Mock<IFrenchSuitedCard>();
            NineSpades.Setup(x => x.Rank).Returns(Rank.Nine);
            NineSpades.Setup(x => x.Suit).Returns(Suit.Spades);

            TenSpades = new Mock<IFrenchSuitedCard>();
            TenSpades.Setup(x => x.Rank).Returns(Rank.Ten);
            TenSpades.Setup(x => x.Suit).Returns(Suit.Spades);

            JackSpades = new Mock<IFrenchSuitedCard>();
            JackSpades.Setup(x => x.Rank).Returns(Rank.Jack);
            JackSpades.Setup(x => x.Suit).Returns(Suit.Spades);

            QueenSpades = new Mock<IFrenchSuitedCard>();
            QueenSpades.Setup(x => x.Rank).Returns(Rank.Queen);
            QueenSpades.Setup(x => x.Suit).Returns(Suit.Spades);

            KingSpades = new Mock<IFrenchSuitedCard>();
            KingSpades.Setup(x => x.Rank).Returns(Rank.King);
            KingSpades.Setup(x => x.Suit).Returns(Suit.Spades);
        }
    }
}
