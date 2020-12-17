using System;
using System.Collections.Generic;
using System.Drawing;
using Bjss.Library.Cards.Contracts;

namespace Bjss.Library.Cards.UnitTests.Fakes
{
    public class FakePack : IPack<IFakeCard>
    {
        public string Name { get; } = "Fake Pack";
        public int NumberInPack { get; } = 4;

        public Type CardType => typeof(FakeCard);

        public ICollection<IFakeCard> GetCards()
        {
            var cards = new List<IFakeCard>
            {
                new FakeCard(1, null),
                new FakeCard(2, null),
                new FakeCard(3, null),
                new FakeCard(4, null)
            };
            return cards;
        }

        public Image GetCardBackImage()
        {
            return null;
        }
    }
}
