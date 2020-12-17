using Bjss.Library.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Resources;

namespace Bjss.Library.Cards.FrenchSuited
{
    public class Pack : IPack<IFrenchSuitedCard>
    {
        public string Name
        {
            get { return "French Playing Cards"; }
        }

        public Type CardType
        {
            get { return typeof(Card); }
        }

        public int NumberInPack
        {
            get { return 52; }
        }

        public ICollection<IFrenchSuitedCard> GetCards()
        {
            var deck = new List<IFrenchSuitedCard>();

            for (int number = 0; number < NumberInPack; number ++)
            {
                deck.Add(new Card(number, GetCardFaceImage(number)));   
            }
 
            return deck;
        }

        private Image GetCardFaceImage(int number)
        {
            int suit = number / 13;
            var imageName = string.Format("cards_{0:D2}_{1}", number + 1, ((Suit)suit).ToString().ToLower());
            var asm = Assembly.GetExecutingAssembly();
            var resourceName = asm.GetName().Name + ".CardResources";
            var rm = new ResourceManager(resourceName, asm);
            return (Bitmap)rm.GetObject(imageName);
        }

        public Image GetCardBackImage()
        {
            return CardResources.cards_59_backs;
        }
    }
}
