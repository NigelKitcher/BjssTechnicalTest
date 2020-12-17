using Bjss.Library.Cards.FrenchSuited;

namespace Bjss.Sevens.Domain
{
    public sealed class GameRules
    {
        /// <summary>
        /// The suit that is used when opening the game
        /// </summary>
        public const Suit OpeningSuit = Suit.Diamonds;

        /// <summary>
        /// Rank of card that is used for opening all stacks
        /// </summary>
        public const Rank FirstRank = Rank.Seven;
    }
}
