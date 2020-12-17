using System;

namespace Bjss.Library.Cards.UserControls
{
    public interface IHandPresenter
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IHandPresenter"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        bool Enabled { get; set; }

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        HandModel Model { get; }

        /// <summary>
        /// Displays the hand.
        /// </summary>
        void DisplayHand();

        /// <summary>
        /// Occurs when [card click].
        /// </summary>
        event EventHandler<CardClickEventArgs> CardClick;
    }
}
