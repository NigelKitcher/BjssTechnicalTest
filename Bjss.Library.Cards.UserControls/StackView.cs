using Bjss.Library.Cards.Contracts;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Bjss.Library.Cards.UserControls
{
    public partial class StackView : UserControl, IStackView
    {
        public StackView()
        {
            InitializeComponent();
        }

        public void InitialiseCards(IEnumerable<ICard> cards)
        {
            Debug.WriteLine("InitialiseCards:" + cards.Count());
            int row = 0;
            foreach (var card in cards.Reverse())
            {
                var panel = new PictureBox
                {
                    Image = card.FaceImage,
                    Height = card.FaceImage.Height,
                    Width = card.FaceImage.Width,
                    Tag = card,
                    Margin = Padding.Empty,
                    BorderStyle = BorderStyle.FixedSingle,
                    //Location = new Point(0, row++ * 20)
                    Location = new Point(-card.FaceImage.Width, row++ * 20)

                };
                this.Controls.Add(panel);
                panel.BringToFront();
            }
        }

        public IEnumerable<PictureBox> Cards
        {
            get
            {
                var cards = new List<PictureBox>();
                foreach (Control control in this.Controls)
                {
                    if (control is PictureBox box)
                    {
                        cards.Add(box);
                    }
                }

                return cards;
            }
        }
    }
}
