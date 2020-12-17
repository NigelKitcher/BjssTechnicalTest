using System;
using System.Drawing;

namespace Bjss.Library.Cards.Contracts
{
    public interface ICard
    {
        /// <summary>
        /// Gets the name of the card
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the image of the card
        /// </summary>
        Image FaceImage { get; }

        /// <summary>
        /// Gets the card number
        /// </summary>
        int Number { get; }
    }
}
