
using Bjss.Library.Cards.UserControls;

namespace Bjss.Sevens.Client
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnNewGame = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnKnock = new System.Windows.Forms.Button();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPeek = new System.Windows.Forms.Button();
            this.cardStacks = new Bjss.Library.Cards.UserControls.StacksView();
            this.handView3 = new Bjss.Library.Cards.UserControls.HandView();
            this.handView2 = new Bjss.Library.Cards.UserControls.HandView();
            this.handView1 = new Bjss.Library.Cards.UserControls.HandView();
            this.SuspendLayout();
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(556, 12);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(223, 23);
            this.btnNewGame.TabIndex = 5;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.BtnNewGame_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(556, 39);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(223, 338);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // btnKnock
            // 
            this.btnKnock.Enabled = false;
            this.btnKnock.Location = new System.Drawing.Point(677, 395);
            this.btnKnock.Name = "btnKnock";
            this.btnKnock.Size = new System.Drawing.Size(102, 52);
            this.btnKnock.TabIndex = 18;
            this.btnKnock.Text = "Knock";
            this.btnKnock.UseVisualStyleBackColor = true;
            this.btnKnock.Click += new System.EventHandler(this.btnKnock_Click);
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2.Location = new System.Drawing.Point(12, 522);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(183, 20);
            this.lblPlayer2.TabIndex = 19;
            this.lblPlayer2.Text = "WOPR (Unskilled Player)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 675);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "HAL-9000 (Advanced Player)";
            // 
            // btnPeek
            // 
            this.btnPeek.Location = new System.Drawing.Point(677, 453);
            this.btnPeek.Name = "btnPeek";
            this.btnPeek.Size = new System.Drawing.Size(102, 52);
            this.btnPeek.TabIndex = 21;
            this.btnPeek.Text = "Hide cards";
            this.btnPeek.UseVisualStyleBackColor = true;
            this.btnPeek.Click += new System.EventHandler(this.btnPeek_Click);
            // 
            // cardStacks
            // 
            this.cardStacks.BackColor = System.Drawing.Color.Green;
            this.cardStacks.Location = new System.Drawing.Point(12, 12);
            this.cardStacks.Name = "cardStacks";
            this.cardStacks.Size = new System.Drawing.Size(488, 371);
            this.cardStacks.TabIndex = 24;
            // 
            // handView3
            // 
            this.handView3.BackColor = System.Drawing.Color.Transparent;
            this.handView3.Location = new System.Drawing.Point(12, 698);
            this.handView3.Name = "handView3";
            this.handView3.ReadOnly = false;
            this.handView3.Size = new System.Drawing.Size(647, 127);
            this.handView3.TabIndex = 15;
            // 
            // handView2
            // 
            this.handView2.BackColor = System.Drawing.Color.Transparent;
            this.handView2.Location = new System.Drawing.Point(12, 545);
            this.handView2.Name = "handView2";
            this.handView2.ReadOnly = false;
            this.handView2.Size = new System.Drawing.Size(647, 127);
            this.handView2.TabIndex = 13;
            // 
            // handView1
            // 
            this.handView1.BackColor = System.Drawing.Color.Transparent;
            this.handView1.Location = new System.Drawing.Point(12, 395);
            this.handView1.Name = "handView1";
            this.handView1.ReadOnly = false;
            this.handView1.Size = new System.Drawing.Size(647, 120);
            this.handView1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(800, 835);
            this.Controls.Add(this.cardStacks);
            this.Controls.Add(this.btnPeek);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.btnKnock);
            this.Controls.Add(this.handView3);
            this.Controls.Add(this.handView2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.handView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Sevens";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Library.Cards.UserControls.HandView handView1;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private HandView handView2;
        private HandView handView3;
        private System.Windows.Forms.Button btnKnock;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPeek;
        private StacksView cardStacks;
    }
}

