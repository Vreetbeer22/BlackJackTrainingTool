namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        enum GameState
        {
            setup,
            start,
        }

        private Deck deck;
        private List<Player> players = new List<Player>();
        private GameState currentState = GameState.setup;

        private const int MinPlayers = 1;
        private const int MaxPlayers = 4;

        public Form1()
        {
            InitializeComponent();
            deck = new Deck();
            deck.Shuffle();
            EnterSetupState();
        }

        private void EnterSetupState()
        {
            currentState = GameState.setup;

            panelSetup.Visible = true;
            panelGame.Visible = false;

            players.Clear();
            RefreshPlayerList();
            UpdateSetupButtons();
        }

        private void EnterStartState()
        {
            currentState = GameState.start;

            panelSetup.Visible = false;
            panelGame.Visible = true;

            deck.Reset();
            deck.Shuffle();
            UpdateCardCount();

            labelStatus.Text = $"Spelers: {string.Join(", ", players.ConvertAll(p => p.Name))} | Klaar om te spelen!";
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            string name = txtPlayerName.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                labelSetupInfo.Text = "Voer een naam in.";
                return;
            }

            if (players.Count >= MaxPlayers)
            {
                labelSetupInfo.Text = $"Maximaal {MaxPlayers} spelers toegestaan.";
                return;
            }

            players.Add(new Player(name));
            txtPlayerName.Text = "";
            txtPlayerName.Focus();
            RefreshPlayerList();
            UpdateSetupButtons();
        }

        private void btnRemovePlayer_Click(object sender, EventArgs e)
        {
            if (listBoxPlayers.SelectedIndex >= 0)
            {
                players.RemoveAt(listBoxPlayers.SelectedIndex);
                RefreshPlayerList();
                UpdateSetupButtons();
            }
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            if (players.Count < MinPlayers)
            {
                labelSetupInfo.Text = $"Voeg minimaal {MinPlayers} speler toe.";
                return;
            }
            EnterStartState();
        }

        private void RefreshPlayerList()
        {
            listBoxPlayers.Items.Clear();
            foreach (var p in players)
                listBoxPlayers.Items.Add(p.Name);
        }

        private void UpdateSetupButtons()
        {
            btnStartGame.Enabled = players.Count >= MinPlayers;
            btnAddPlayer.Enabled = players.Count < MaxPlayers;
            labelSetupInfo.Text = $"Spelers: {players.Count}/{MaxPlayers}";
        }

        private void UpdateCardCount()
        {
            labelCardsLeft.Text = $"Cards left: {deck.CardsLeft}";
            labelCardsLeft.Refresh();
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            if (deck.CardsLeft > 0)
            {
                Card card = deck.Deal();
                labelCard.Text = card.ToString();
            }
            else
            {
                labelCard.Text = "No cards left!";
            }
            UpdateCardCount();
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            deck.Shuffle();
            UpdateCardCount();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            deck.Reset();
            UpdateCardCount();
        }

        private void btnBackToSetup_Click(object sender, EventArgs e)
        {
            EnterSetupState();
        }
    }
}