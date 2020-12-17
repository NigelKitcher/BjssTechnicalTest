using Bjss.Library.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bjss.Library.Cards.UserControls
{
    public partial class HandView: UserControl, IHandView
    {
        public HandView()
        {
            InitializeComponent();
        }

        public bool ReadOnly { get; set; }

        public void DisplayHand(IEnumerable<ICard> cards)
        {
            this.SuspendDrawing();
            this.Controls.Clear();

            int column = 0;
            foreach (var card in cards)
            {
                var panel = new PictureBox
                {
                    Image = card.FaceImage,
                    Height = card.FaceImage.Height,
                    Width = card.FaceImage.Width,
                    Margin = new Padding(0, 20, 0, 0),
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new Point(column++ * 20, 20),
                    Tag = card
                };

                panel.MouseClick += pictureBox1_MouseClick;
                panel.MouseEnter += pictureBox1_MouseEnter;
                panel.MouseLeave += pictureBox1_MouseLeave;

                this.Controls.Add(panel);
                panel.BringToFront();
            }
            this.ResumeDrawing();
        }

        public event EventHandler<EventArgs> CardClick;

        private void pictureBox1_MouseLeave(object sender, System.EventArgs e)
        {
            if (ReadOnly) return;
            var pb = sender as PictureBox;
            pb.Location = new Point(pb.Location.X, 20);
        }

        private void pictureBox1_MouseEnter(object sender, System.EventArgs e)
        {
            if (ReadOnly) return;
            var pb = sender as PictureBox;
            pb.Location = new Point(pb.Location.X, 0);
        }

        private void pictureBox1_MouseClick(object sender, EventArgs e)
        {
            if (ReadOnly) return;
            CardClick?.Invoke(sender, e);
        }
    }
}
