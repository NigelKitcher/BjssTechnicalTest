namespace Bjss.Library.Cards.Contracts
{
    public interface IShuffleable<T> where T : ICard
    {
        void Shuffle(IShuffleStrategy<T> shuffleStrategy);
    }
}
