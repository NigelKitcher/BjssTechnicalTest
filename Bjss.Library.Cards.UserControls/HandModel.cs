using Bjss.Library.Cards.FrenchSuited;
using System.Collections.Generic;

namespace Bjss.Library.Cards.UserControls
{
    public class HandModel
    {
        public IList<IFrenchSuitedCard> Cards { get; }

        public HandModel(IList<IFrenchSuitedCard> cards)
        {
            Cards = cards;
        }
    }
}
