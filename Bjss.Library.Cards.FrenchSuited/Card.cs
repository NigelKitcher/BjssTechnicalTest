using System.Drawing;

namespace Bjss.Library.Cards.FrenchSuited
{
    internal class Card : IFrenchSuitedCard
    {
        /// <summary>
        /// Gets the card's rank
        /// </summary>
        public Rank Rank { get; }

        /// <summary>
        /// Gets the card's suit
        /// </summary>
        public Suit Suit { get; }

        public string Name => $"{Rank} of {Suit}";

        public Image FaceImage { get; }

        public int Number { get; }

        public Card(int number, Image faceImage)
        {
            Number = number;
            Rank = (Rank)(number % 13) + 1;
            Suit = (Suit)(number / 13);
            FaceImage = faceImage;
        }

        public int CompareTo(IFrenchSuitedCard other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Number.CompareTo(other.Number);
        }
    }
}
