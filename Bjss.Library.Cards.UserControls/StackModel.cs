using Bjss.Library.Cards.Contracts;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Bjss.Library.Cards.UserControls
{
    public class StackModel
    {
        public IEnumerable<ICard> Cards { get; }

        public StackModel(IEnumerable<ICard> cards)
        {
            Cards = cards;
            Debug.WriteLine("Cards:" + cards.Count());
        }
    }
}
