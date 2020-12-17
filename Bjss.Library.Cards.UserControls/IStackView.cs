using System.Collections.Generic;
using System.Windows.Forms;
using Bjss.Library.Cards.Contracts;

namespace Bjss.Library.Cards.UserControls
{
    public interface IStackView
    {
        /// <summary>
        /// Initialises the cards.
        /// </summary>
        /// <param name="cards">The cards.</param>
        void InitialiseCards(IEnumerable<ICard> cards);

        /// <summary>
        /// Gets the cards.
        /// </summary>
        /// <value>
        /// The cards.
        /// </value>
        IEnumerable<PictureBox> Cards { get; }
    }
}
