using Bjss.Library.Cards.FrenchSuited;
using System.Collections.Generic;

namespace Bjss.Sevens.Domain.Contracts
{
    /// <summary>
    /// Interface for providing a strategy for game play
    /// </summary>
    public interface IGamePlayStrategy
    {
        /// <summary>
        /// Gets the move.
        /// </summary>
        /// <returns>
        /// </returns>
        /// <exception cref="KnockException"></exception>
        IFrenchSuitedCard GetMove(IEnumerable<IFrenchSuitedCard> playedCards, List<IFrenchSuitedCard> hand);
    }
}
