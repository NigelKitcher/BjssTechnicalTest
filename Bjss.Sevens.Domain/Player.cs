using Bjss.Library.Cards.FrenchSuited;
using Bjss.Sevens.Domain.Contracts;
using System;
using System.Drawing;

namespace Bjss.Sevens.Domain
{
    public class Player : IPlayer
    {
        public string Name { get; }
        public Color Colour { get; }
        public IHand Hand { get; } 
        public IGamePlayStrategy GamePlayStrategy { get; }
        public ISevensGameService GameService { get; }

        public event EventHandler<CardPlayedEventArgs> CardPlayed;

        public Player(string name, Color colour, ISevensGameService gameService)
        {
            Name = name;
            Colour = colour;
            Hand = new Hand();
            GamePlayStrategy = null;
            GameService = gameService;
        }

        public Player(string name, Color colour, IGamePlayStrategy gamePlayStrategy, ISevensGameService gameService)
        {
            Name = name;
            Colour = colour;
            Hand = new Hand();
            GamePlayStrategy = gamePlayStrategy;
            GameService = gameService;
        }

        public void TakeTurn()
        {
            if (GamePlayStrategy == null) return;
            var card = GamePlayStrategy.GetMove(GameService.PlayedCards, Hand.Cards);
            CardPlayed?.Invoke(this, new CardPlayedEventArgs(this, card));
        }

        public void PlayCard(IFrenchSuitedCard card)
        {
            var handler = CardPlayed;
            handler?.Invoke(this, new CardPlayedEventArgs(this, card));
        }

        public void SortHand()
        {
            Hand.Cards.Sort();
        }

        public void ReturnAnyCards()
        {
            Hand.Cards.Clear();
        }
    }
}
