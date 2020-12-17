using Bjss.Sevens.Domain.Contracts;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bjss.Sevens.Domain
{
    /// <summary>
    /// TODO: Move logic from MainForm into this GameManager
    /// </summary>
    public class GameManager
    {
        private readonly Queue<IPlayer> _players = new Queue<IPlayer>();

        private readonly ISevensGameService _gameService;

        public GameManager(IEnumerable<IPlayer> players, ISevensGameService gameService)
        {
            foreach (var player in players)
            {
                player.CardPlayed += PlayerOnCardPlayed;
                _players.Enqueue(player);
            }

            _gameService = gameService;
        }

        private IPlayer GetPlayerHoldingOpeningCard()
        {
            var player = _players.Dequeue();
            while (!player.Hand.IsHoldingOpeningCard())
            {
                _players.Enqueue(player);
                player = _players.Dequeue();
            }

            return player;
        }

        private void PlayerOnCardPlayed(object sender, CardPlayedEventArgs e)
        {
            _gameService.AcceptCard(e.Card);
            _players.Enqueue(e.Player);
        }

        public void NextMove()
        {
            var player = _players.Dequeue();
            MakeMove(player);
        }

        private void MakeMove(IPlayer player)
        {
            try
            {
                player.TakeTurn();
            }
            catch (KnockException)
            {
                MessageBox.Show($@"({player.Name} knocked.");
                throw;
            }

            _players.Enqueue(player);
        }

        public void StartGame()
        {
            var player = GetPlayerHoldingOpeningCard();
            MakeMove(player);
        }

    }
}
