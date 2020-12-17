using Bjss.Library;
using Bjss.Library.Cards.Contracts;
using Bjss.Library.Cards.Domain;
using Bjss.Library.Cards.FrenchSuited;
using Bjss.Library.Cards.PileShuffle;
using Bjss.Library.Cards.UserControls;
using Bjss.Sevens.Domain;
using Bjss.Sevens.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Bjss.Sevens.Client
{
    public partial class MainForm : Form
    {
        private IDeck<IFrenchSuitedCard> _deck;
        private readonly IPack<IFrenchSuitedCard> _packOfCards = new Bjss.Library.Cards.FrenchSuited.Pack();

        private readonly ISevensGameService _gameService;
        private readonly IRandomGenerator _randomGenerator = new RandomGenerator();

        private IPlayer _player1;
        private IPlayer _player2;
        private IPlayer _player3;

        private readonly Queue<IPlayer> _players = new Queue<IPlayer>();

        private IHandPresenter _player1HandPresenter;
        private IHandPresenter _player2HandPresenter;
        private IHandPresenter _player3HandPresenter;

        public MainForm()
        {
            InitializeComponent();

            this.btnPeek.Text = "Peek at cards";
            this.Height = 560;

            this.handView2.ReadOnly = true;
            this.handView3.ReadOnly = true;

            SetupCardDeck();
            this.cardStacks.LoadPack(_packOfCards);

            _gameService = new SevensGameService();
            _gameService.CardPlayed += GameServiceOnCardPlayed;

            SetupPlayers();
            CreatePresenters();
        }

        private void GameServiceOnCardPlayed(object sender, CardPlayedAcceptedEventArgs e)
        {
            this.cardStacks.DisplayCard(e.Card);

            _player1HandPresenter.DisplayHand();
            _player2HandPresenter.DisplayHand();
            _player3HandPresenter.DisplayHand();
        }

        private void SetupPlayers()
        {
            var advancedGamePlayStrategy = new AdvancedGamePlayStrategy();
            var basicGamePlayStrategy = new BasicGamePlayStrategy();

            _player1 = new Player("Nigel", Color.Green, _gameService);
            _player2 = new Player("WOPR", Color.Brown, basicGamePlayStrategy, _gameService);
            _player3 = new Player("HAL-9000", Color.Blue, advancedGamePlayStrategy, _gameService);
        }

        private void SetupCardDeck()
        {
            _deck = new Deck<IFrenchSuitedCard>(_packOfCards);
            var shuffleStrategy = new PileShuffleStrategy<IFrenchSuitedCard>(_randomGenerator);
            _deck.OpenDeck();
            _deck.Shuffle(shuffleStrategy);
        }

        private void RemoveAnyPlayedCards()
        {
            this.cardStacks.RemoveAllCardsFromDisplay();
        }

        private void DealCards()
        {
            _player1.ReturnAnyCards();
            _player2.ReturnAnyCards();
            _player3.ReturnAnyCards();

            var players = new List<IPlayer> {_player1, _player2, _player3};
            var dealer = new Dealer(players, _deck);
            dealer.Deal();

            _player1.SortHand();
            _player2.SortHand();
            _player3.SortHand();
        }

        private void CreatePresenters()
        {
            _player1HandPresenter = new HandPresenter(new HandModel(_player1.Hand.Cards), this.handView1);
            _player1HandPresenter.CardClick += HandPresenter_CardClick;
            _player1HandPresenter.Enabled = true;
            _player2HandPresenter = new HandPresenter(new HandModel(_player2.Hand.Cards), this.handView2);
            _player3HandPresenter = new HandPresenter(new HandModel(_player3.Hand.Cards), this.handView3);

        }

        private void DisplayHands()
        {
            _player1HandPresenter.DisplayHand();
            _player2HandPresenter.DisplayHand();
            _player3HandPresenter.DisplayHand();
        }

        private void ClearGameProgressLog()
        {
            this.richTextBox1.Text = "";
        }

        private void InitialiseGameService()
        {
            _gameService.NewGame();
        }

        private void SetPlayerOrder()
        {
            _players.Clear();
            _players.Enqueue(_player1);
            _players.Enqueue(_player2);
            _players.Enqueue(_player3);
        }

        private void EnableKnockButton()
        {
            this.btnKnock.Enabled = true;
        }

        private void DisableKnockButton()
        {
            this.btnKnock.Enabled = false;
        }

        private void DeclareWinner(IPlayer player)
        {
            this.richTextBox1.AppendText($"Game over: WINNER: {player.Name.ToUpper()} \n", Color.DarkOrange);
        }

        private void DisableManualPlayerControls()
        {
            this._player1HandPresenter.Enabled = false;
            DisableKnockButton();
        }

        private void NewGame()
        {
            InitialiseGameService();
            ClearGameProgressLog();
            RemoveAnyPlayedCards();
            SetupCardDeck();
            DealCards();
            DisplayHands();
            SetPlayerOrder();
            EnableKnockButton();
            MakeFirstMove();
        }

        private void EndGame(IPlayer player)
        {
            DeclareWinner(player);
            DisableManualPlayerControls();
            PlayGameComplete();
        }

        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private bool IsWinningMove(IPlayer player)
        {
            return (player.Hand.Cards.Count == 0);
        }

        private void MakeMove(IPlayer player, IFrenchSuitedCard card)
        {
            try
            {
                _gameService.AcceptCard(card);
                player.Hand.RemoveCard(card);
                DisplayHands();
                this.richTextBox1.AppendText($"{player.Name} played: {card.Name}\n", player.Colour);

                if (IsWinningMove(player))
                {
                    EndGame(player);
                    return;
                }

                _players.Enqueue(_activePlayer);
                _activePlayer = _players.Dequeue();


                if (_activePlayer.GamePlayStrategy == null)
                {
                    _player1HandPresenter.Enabled = true;
                }
                else
                {
                    var c = _activePlayer.GamePlayStrategy.GetMove(_gameService.PlayedCards, _activePlayer.Hand.Cards);
                    MakeMove(_activePlayer, c);
                }

            }
            catch (KnockException)
            {
                PlayKnock();
                this.richTextBox1.AppendText($"{_activePlayer.Name} Knocked\n", _activePlayer.Colour);
                NextPlayer();
            }
        }

        private void NextPlayer()
        {
            try
            {
                _players.Enqueue(_activePlayer);
                _activePlayer = _players.Dequeue();

                if (_activePlayer.GamePlayStrategy != null)
                {
                    var c = _activePlayer.GamePlayStrategy.GetMove(_gameService.PlayedCards, _activePlayer.Hand.Cards);
                    MakeMove(_activePlayer, c);
                }

            }
            catch (KnockException)
            {
                HandleKnock();
            }
        }

        private void HandleKnock()
        {
            PlayKnock();
            this.richTextBox1.AppendText($"{_activePlayer.Name} Knocked\n", _activePlayer.Colour);
            NextPlayer();
        }

        private void HandPresenter_CardClick(object sender, CardClickEventArgs e)
        {
            var isValidMove = false;
            try
            {
                if (_activePlayer != _player1) return;

                _gameService.AcceptCard((IFrenchSuitedCard) e.Card);
                _activePlayer.Hand.RemoveCard((IFrenchSuitedCard) e.Card);
                _player1HandPresenter.DisplayHand();
                this.richTextBox1.AppendText($"{_activePlayer.Name} played: {e.Card.Name}\n", _activePlayer.Colour);

                if (IsWinningMove(_activePlayer))
                {
                    if (IsWinningMove(_activePlayer))
                    {
                        EndGame(_activePlayer);
                        return;
                    }
                }

                isValidMove = true;
            }
            catch (InvalidMoveException exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (isValidMove) NextPlayer();
        }

        private IPlayer _activePlayer;


        private void btnKnock_Click(object sender, EventArgs e)
        {
            if (_activePlayer?.GamePlayStrategy != null) return;
            HandleKnock();
        }

        private void MakeFirstMove()
        {
            _activePlayer = _players.Dequeue();
            while (!_activePlayer.Hand.IsHoldingOpeningCard())
            {
                _players.Enqueue(_activePlayer);
                _activePlayer = _players.Dequeue();
            }

            _activePlayer.Hand.GetOpeningCard();
            MakeMove(_activePlayer, _activePlayer.Hand.GetOpeningCard());
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void PlayKnock()
        {
            PlaySound("Bjss.Sevens.Client.Resources.KLAK.wav");
            PlaySound("Bjss.Sevens.Client.Resources.KLAK.wav");
        }

        private void PlayGameComplete()
        {
            PlaySound("Bjss.Sevens.Client.Resources.Tada.wav");
        }

        private void PlaySound(string sound)
        {
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream s = a.GetManifestResourceStream(sound);
            using (SoundPlayer player = new SoundPlayer(s))
            {
                player.PlaySync();
            }
        }

        private void btnPeek_Click(object sender, EventArgs e)
        {
            if (this.Height == 560)
            {
                this.btnPeek.Text = "Hide cards";
                this.Height = 874;
            }
            else
            {
                this.btnPeek.Text = "Peek at cards";
                this.Height = 560;
            }
        }

    }
}
