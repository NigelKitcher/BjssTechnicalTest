using Bjss.Library.Cards.Contracts;
using System;
using System.Collections.Generic;

namespace Bjss.Library.Cards.UnitTests.Fakes
{
    public class FakeShuffleStrategy : IShuffleStrategy<IFakeCard>
    {
        public event EventHandler ShuffleProgress;
        public event EventHandler ShuffleCompleted;

        public Stack<IFakeCard> Shuffle(ICollection<IFakeCard> cards)
        {
            return new Stack<IFakeCard>();
        }
    }
}
