using System;
using Bjss.Library.Cards.Contracts;
using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;

namespace Bjss.Library.Cards.UserControls
{
    public interface IHandView
    {
        bool ReadOnly { get; set; }
        void DisplayHand(IEnumerable<ICard> cards);
        event EventHandler<EventArgs> CardClick;
    }
}
