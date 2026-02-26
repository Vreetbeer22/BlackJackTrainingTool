namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnDeal = new Button();
            btnShuffle = new Button();
            lblCard = new Label();
            lblDeckCount = new Label();

            //btnDeal
            btnDeal.Location = new Point(50, 200);
            btnDeal.Size = new Size(100, 34);
            btnDeal.Text = "Deal new card";
            btnDeal.Click += btnDeal_Click;

            //btnShuffle
            btnShuffle.Location = new Point(170, 200);
            btnShuffle.Size = new Size(100, 34);
            btnShuffle.Text = "Shuffle";
            btnShuffle.Click += btnShuffle_Click;

            //lblCard
            lblCard.Location = new Point(50, 80);
            lblCard.Size = new Size(120, 80);
            lblCard.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            lblCard.BorderStyle = BorderStyle.FixedSingle;
            lblCard.TextAlign = ContentAlignment.MiddleCenter;
            lblCard.Text = "?";

            //lblDeckCount
            lblDeckCount.Location = new Point(50, 170);
            lblDeckCount.AutoSize = true;
            lblDeckCount.Font = new Font("Segoe UI", 10);
            lblDeckCount.Text = "Cards left: 52";

            //Form1
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 300);
            Controls.Add(btnDeal);
            Controls.Add(btnShuffle);
            Controls.Add(lblCard);
            Controls.Add(lblDeckCount);
            Name = "Form1";
            Text = "BlackJack Trainer";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnDeal;
        private Button btnShuffle;
        private Label lblCard;
        private Label lblDeckCount;
    }
}
