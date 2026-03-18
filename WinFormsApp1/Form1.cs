namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Deck deck;

        public Form1()
        {
            InitializeComponent();
            deck = new Deck();
            deck.Shuffle();
            UpdateCardCount();
        }

        private void UpdateCardCount()
        {
            label2.Text = $"Cards left: {deck.CardsLeft}";
            label2.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (deck.CardsLeft > 0)
            {
                Card card = deck.Deal();
                label1.Text = card.ToString();
            }
            else
            {
                label1.Text = "No cards left!";
            }
            UpdateCardCount();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deck.Shuffle();
            UpdateCardCount();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deck.Reset();
            UpdateCardCount();
        }
    }
}