using System.Drawing;
using Bjss.Library.Cards.Contracts;

namespace Bjss.Library.Cards.UnitTests.Fakes
{
    public class FakeInvalidCard : ICard
    {
        public string Name
        {
            get { return @"FakeInvalid{Number}"; }
        }
        public Image FaceImage { get; }
        public int Number { get; }

        public FakeInvalidCard(int number, Image image)
        {
            Number = number;
            FaceImage = image;
        }
    }
}
