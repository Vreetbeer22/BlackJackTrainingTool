namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Deck deck = new Deck();

        public Form1()
        {
            InitializeComponent();
            deck.Shuffle();
            UpdateDeckCount();
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            if (deck.Remaining == 0)
            {
                MessageBox.Show("The deck is empty! You need to shuffle");
                return;
            }

            Card card = deck.Deal();
            lblCard.Text = card.Display;

            if (card.Suit == "♥" || card.Suit == "♦")
                lblCard.ForeColor = Color.Red;
            else
                lblCard.ForeColor = Color.Black;

            UpdateDeckCount();
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            deck = new Deck();
            deck.Shuffle();
            lblCard.Text = "?";
            lblCard.ForeColor = Color.Black;
            UpdateDeckCount();
        }

        private void UpdateDeckCount()
        {
            lblDeckCount.Text = "Cards left: " + deck.Remaining;
        }
    }
}
