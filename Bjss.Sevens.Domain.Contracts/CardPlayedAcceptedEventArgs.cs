using Bjss.Library.Cards.FrenchSuited;

namespace Bjss.Sevens.Domain.Contracts
{
    /// <summary>
    /// EventArgs raised when a card that has been played is accepted
    /// </summary>
    public class CardPlayedAcceptedEventArgs
    {
        public IFrenchSuitedCard Card { get; }

        public CardPlayedAcceptedEventArgs(IFrenchSuitedCard card)
        {
            Card = card;
        }
    }
}
