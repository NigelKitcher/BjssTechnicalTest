using Bjss.Library.Cards.Contracts;
using System;
using System.Windows.Forms;

namespace Bjss.Library.Cards.UserControls
{
    public class HandPresenter : IHandPresenter
    {
        public HandModel Model { get; }
        private readonly IHandView _view;

        public bool Enabled
        {
            get => !_view.ReadOnly;
            set => _view.ReadOnly = !value;
        }

        public HandPresenter(HandModel model, IHandView view)
        {
            Model = model;
            _view = view;

            _view.CardClick += View_CardClick;
        }

        private void View_CardClick(object sender, EventArgs e)
        {
            if (_view.ReadOnly) return;
            var card = ((PictureBox) sender).Tag;
            CardClick?.Invoke(this, new CardClickEventArgs((ICard) card));
        }

        public void DisplayHand()
        {
            _view.DisplayHand(Model.Cards);
        }

        public event EventHandler<CardClickEventArgs> CardClick;
    }
}
