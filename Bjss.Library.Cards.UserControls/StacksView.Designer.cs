
namespace Bjss.Library.Cards.UserControls
{
    partial class StacksView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.stackViewSpades = new Bjss.Library.Cards.UserControls.StackView();
            this.stackViewHearts = new Bjss.Library.Cards.UserControls.StackView();
            this.stackViewDiamonds = new Bjss.Library.Cards.UserControls.StackView();
            this.stackViewClubs = new Bjss.Library.Cards.UserControls.StackView();
            this.SuspendLayout();
            // 
            // stackViewSpades
            // 
            this.stackViewSpades.Location = new System.Drawing.Point(413, 3);
            this.stackViewSpades.Name = "stackViewSpades";
            this.stackViewSpades.Size = new System.Drawing.Size(71, 365);
            this.stackViewSpades.TabIndex = 13;
            // 
            // stackViewHearts
            // 
            this.stackViewHearts.Location = new System.Drawing.Point(269, 3);
            this.stackViewHearts.Name = "stackViewHearts";
            this.stackViewHearts.Size = new System.Drawing.Size(71, 365);
            this.stackViewHearts.TabIndex = 12;
            // 
            // stackViewDiamonds
            // 
            this.stackViewDiamonds.Location = new System.Drawing.Point(135, 3);
            this.stackViewDiamonds.Name = "stackViewDiamonds";
            this.stackViewDiamonds.Size = new System.Drawing.Size(71, 365);
            this.stackViewDiamonds.TabIndex = 11;
            // 
            // stackViewClubs
            // 
            this.stackViewClubs.Location = new System.Drawing.Point(2, 3);
            this.stackViewClubs.Name = "stackViewClubs";
            this.stackViewClubs.Size = new System.Drawing.Size(71, 365);
            this.stackViewClubs.TabIndex = 10;
            // 
            // StacksView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.Controls.Add(this.stackViewSpades);
            this.Controls.Add(this.stackViewHearts);
            this.Controls.Add(this.stackViewDiamonds);
            this.Controls.Add(this.stackViewClubs);
            this.Name = "StacksView";
            this.Size = new System.Drawing.Size(488, 371);
            this.ResumeLayout(false);

        }

        #endregion

        private StackView stackViewSpades;
        private StackView stackViewHearts;
        private StackView stackViewDiamonds;
        private StackView stackViewClubs;
    }
}
