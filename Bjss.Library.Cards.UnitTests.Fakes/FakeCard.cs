using System.Drawing;

namespace Bjss.Library.Cards.UnitTests.Fakes
{
    public class FakeCard : IFakeCard
    {
        public string Name
        {
            get { return string.Format("Fake{0}", Number); }
        }
        public Image FaceImage { get; }
        public int Number { get; }

        public FakeCard(int number)
        {
            Number = number;
        }

        public FakeCard(int number, Image image)
        {
            Number = number;
            FaceImage = image;
        }
    }
}
