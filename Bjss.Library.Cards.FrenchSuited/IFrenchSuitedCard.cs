using System;
using Bjss.Library.Cards.Contracts;

namespace Bjss.Library.Cards.FrenchSuited
{
    public interface IFrenchSuitedCard : ICard, IComparable<IFrenchSuitedCard>
    {
        /// <summary>
        /// Gets the card's rank
        /// </summary>
        Rank Rank { get; }

        /// <summary>
        /// Gets the card's suit
        /// </summary>
        Suit Suit { get; }
    }
}
