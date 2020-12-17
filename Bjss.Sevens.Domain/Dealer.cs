using Bjss.Library.Cards.Contracts;
using Bjss.Library.Cards.FrenchSuited;
using Bjss.Sevens.Domain.Contracts;
using System.Collections.Generic;

namespace Bjss.Sevens.Domain
{
    public class Dealer : IDealer
    {
        public IEnumerable<IPlayer> Players { get; }

        public IDeck<IFrenchSuitedCard> Deck { get; }

        public Dealer(IEnumerable<IPlayer> players, IDeck<IFrenchSuitedCard> deck)
        {
            Players = players;
            Deck = deck;
        }

        public void Deal()
        {
            var players = new Queue<IPlayer>();
            foreach (var player in Players)
            {
                players.Enqueue(player);
            }

            while (Deck.CardCount != 0)
            {
                var player = players.Dequeue();
                player.Hand.Cards.Add(Deck.Deal());
                players.Enqueue(player);
            }
        }
    }
}
