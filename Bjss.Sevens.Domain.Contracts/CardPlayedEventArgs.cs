using Bjss.Library.Cards.FrenchSuited;
using System;

namespace Bjss.Sevens.Domain.Contracts
{
    public class CardPlayedEventArgs : EventArgs
    {
        public IPlayer Player { get; }
        public IFrenchSuitedCard Card { get; }

        public CardPlayedEventArgs(IPlayer player, IFrenchSuitedCard card)
        {
            Player = player;
            Card = card;
        }
    }
}
