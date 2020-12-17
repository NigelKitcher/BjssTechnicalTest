using Bjss.Library.Cards.Contracts;
using Bjss.Library.Cards.FrenchSuited;
using System.Linq;
using System.Windows.Forms;

namespace Bjss.Library.Cards.UserControls
{
    public partial class StacksView : UserControl, IStacksView
    {
        private StackModel _clubsStackModel;
        private StackModel _diamondsStackModel;
        private StackModel _heartsStackModel;
        private StackModel _spadesStackModel;

        private IStackPresenter _clubsStackPresenter;
        private IStackPresenter _diamondsStackPresenter;
        private IStackPresenter _heartsStackPresenter;
        private IStackPresenter _spadesStackPresenter;

        public StacksView()
        {
            InitializeComponent();
        }

        public void LoadPack(IPack<IFrenchSuitedCard> packOfCards)
        {
            var cards = packOfCards.GetCards();
            _clubsStackModel = new StackModel(cards.Where(x => x.Suit == Suit.Clubs));
            _diamondsStackModel = new StackModel(cards.Where(x => x.Suit == Suit.Diamonds));
            _heartsStackModel = new StackModel(cards.Where(x => x.Suit == Suit.Hearts));
            _spadesStackModel = new StackModel(cards.Where(x => x.Suit == Suit.Spades));

            _clubsStackPresenter = new StackPresenter(_clubsStackModel, stackViewClubs);
            _diamondsStackPresenter = new StackPresenter(_diamondsStackModel, stackViewDiamonds);
            _heartsStackPresenter = new StackPresenter(_heartsStackModel, stackViewHearts);
            _spadesStackPresenter = new StackPresenter(_spadesStackModel, stackViewSpades);
        }

        public void DisplayCard(IFrenchSuitedCard card)
        {
            if (card.Suit == Suit.Clubs) _clubsStackPresenter.ShowCard(card);
            if (card.Suit == Suit.Hearts) _heartsStackPresenter.ShowCard(card);
            if (card.Suit == Suit.Diamonds) _diamondsStackPresenter.ShowCard(card);
            if (card.Suit == Suit.Spades) _spadesStackPresenter.ShowCard(card);
        }

        public void RemoveAllCardsFromDisplay()
        {
            _clubsStackPresenter.HideCards();
            _heartsStackPresenter.HideCards();
            _diamondsStackPresenter.HideCards();
            _spadesStackPresenter.HideCards();
        }
    }
}
