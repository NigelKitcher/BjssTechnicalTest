using Bjss.Library.Cards.Contracts;
using System;

namespace Bjss.Library.Cards.UserControls
{
    public class CardClickEventArgs : EventArgs
    {
        public ICard Card { get; }

        public CardClickEventArgs(ICard card)
        {
            Card = card;
        }
    }
}
