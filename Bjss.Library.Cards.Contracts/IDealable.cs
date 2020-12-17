namespace Bjss.Library.Cards.Contracts
{
    public interface IDealable<T> where T : ICard
    {
        /// <summary>
        /// Deals a card
        /// </summary>
        /// <exception cref="OutOfCardsException">Thrown when attempting to deal a card and there are none in the deck</exception>
        /// <returns>Card dealt</returns>
        T Deal();
    }
}
