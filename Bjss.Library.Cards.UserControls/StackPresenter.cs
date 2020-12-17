using Bjss.Library.Cards.Contracts;
using System.Linq;

namespace Bjss.Library.Cards.UserControls
{

    /// <summary>
    /// Presenter for showing a stack of cards
    /// </summary>
    /// <seealso cref="Bjss.Library.Cards.UserControls.IStackPresenter" />
    /// <remarks>
    /// Implementation hides cards by moving left out of display area as setting the Visible property changes the Z-Order which we want to maintain
    /// </remarks>
    public class StackPresenter : IStackPresenter
    {
        private readonly StackModel _model;
        private readonly IStackView _view;

        public StackPresenter(StackModel model, IStackView view)
        {
            _model = model;
            _view = view;

            _view.InitialiseCards(_model.Cards);
        }

        public void HideCards()
        {
            foreach (var card in _view.Cards)
            {
                card.Left = -card.Width; 
            }
        }

        public void ShowCard(ICard card)
        {
            _view.Cards.FirstOrDefault(x => ((ICard)(x.Tag))?.Number == card.Number).Left = 0;
        }
    }
}
