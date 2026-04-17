namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        enum GameState
        {
            setup,
            playing,
        }

        private Deck deck;
        private List<Player> players = new List<Player>();
        private Dealer dealer = new Dealer();
        private GameState currentState = GameState.setup;

        private const int MinPlayers = 1;
        private const int MaxPlayers = 4;

        // Bottom bar layout constants
        private const int BtnBarMargin = 10;
        private const int BtnBarHeight = 28;
        private const int BtnBarSpacing = 8;

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
            UpdateStateLabel();
        }

        private void EnterPlayingState()
        {
            currentState = GameState.playing;
            panelSetup.Visible = false;
            panelGame.Visible = true;

            deck.Reset();
            deck.Shuffle();
            dealer.ResetForNewRound();
            foreach (var p in players)
                p.ResetForNewRound();

            LayoutGamePanel();
            UpdateCardCount();
            UpdateDealerDisplay();
            labelStatus.Text = "Klaar — klik 'Deal Round' om te beginnen.";
            UpdateStateLabel();
        }

        private void LayoutGamePanel()
        {
            int w = panelGame.ClientSize.Width;
            int h = panelGame.ClientSize.Height - labelGameState.Height;
            int btnBarY = h - BtnBarHeight - BtnBarMargin;
            int playerAreaBottom = btnBarY - BtnBarMargin;

            // Top bar
            labelStatus.Location = new Point(8, 6);
            labelStatus.Size = new Size(w - 150, 26);
            labelCardsLeft.Location = new Point(w - 138, 6);
            labelCardsLeft.Size = new Size(130, 26);

            // Dealer seat — centered horizontally, just below top bar
            int dealerSeatW = 200;
            int dealerSeatH = 140;
            panelDealerSeat.Location = new Point((w - dealerSeatW) / 2, 38);
            panelDealerSeat.Size = new Size(dealerSeatW, dealerSeatH);

            // Player area — between dealer seat and bottom buttons
            int playerAreaTop = 38 + dealerSeatH + 10;
            panelPlayerArea.Location = new Point(10, playerAreaTop);
            panelPlayerArea.Size = new Size(w - 20, playerAreaBottom - playerAreaTop);

            // Bottom buttons — left side
            int bx = BtnBarMargin;
            btnDealRound.Location = new Point(bx, btnBarY);
            bx += btnDealRound.Width + BtnBarSpacing;
            btnNewRound.Location = new Point(bx, btnBarY);
            bx += btnNewRound.Width + BtnBarSpacing;
            btnShuffle.Location = new Point(bx, btnBarY);
            bx += btnShuffle.Width + BtnBarSpacing;
            btnReset.Location = new Point(bx, btnBarY);

            // Back button — right side
            btnBackToSetup.Location = new Point(w - btnBackToSetup.Width - BtnBarMargin, btnBarY);

            // Rebuild player seats to fill the new player area size
            BuildPlayerSeats();
        }

        private void panelGame_Resize(object sender, EventArgs e)
        {
            if (currentState == GameState.playing)
                LayoutGamePanel();
        }


        private void BuildPlayerSeats()
        {
            panelPlayerArea.Controls.Clear();

            int count = players.Count;
            if (count == 0) return;

            int areaW = panelPlayerArea.ClientSize.Width;
            int areaH = panelPlayerArea.ClientSize.Height;

            // Each seat takes an equal share of the width
            int spacing = 10;
            int seatW = (areaW - (count + 1) * spacing) / count;
            int seatH = areaH;

            for (int i = 0; i < count; i++)
            {
                var player = players[i];
                int x = spacing + i * (seatW + spacing);

                var seat = new Panel
                {
                    Location = new Point(x, 0),
                    Size = new Size(seatW, seatH),
                    BackColor = Color.FromArgb(0, 80, 0),
                    BorderStyle = BorderStyle.FixedSingle,
                    Name = "seat_" + player.Name
                };

                var lblName = new Label
                {
                    Text = player.Name,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = Color.Gold,
                    AutoSize = false,
                    Size = new Size(seatW - 10, 22),
                    Location = new Point(5, 5),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                var lblHand = new Label
                {
                    AutoSize = false,
                    Size = new Size(seatW - 10, seatH - 60),
                    Location = new Point(5, 30),
                    ForeColor = Color.White,
                    BackColor = Color.Transparent,
                    TextAlign = ContentAlignment.TopCenter,
                    Name = "hand_" + player.Name,
                    Text = "(leeg)"
                };

                int btnW = Math.Max(50, (seatW - 20) / 2 - 4);
                var btnHit = new Button
                {
                    Text = "Hit",
                    Location = new Point(5, seatH - 32),
                    Size = new Size(btnW, 26),
                    UseVisualStyleBackColor = true,
                    Anchor = AnchorStyles.Bottom | AnchorStyles.Left
                };

                var btnStand = new Button
                {
                    Text = "Stand",
                    Location = new Point(5 + btnW + 6, seatH - 32),
                    Size = new Size(btnW, 26),
                    UseVisualStyleBackColor = true,
                    Anchor = AnchorStyles.Bottom | AnchorStyles.Right
                };

                var capturedPlayer = player;
                var capturedLabel = lblHand;
                var capturedBtnHit = btnHit;
                var capturedBtnStand = btnStand;

                btnHit.Click += (s, e) =>
                {
                    if (capturedPlayer.IsStanding)
                        return;

                    if (deck.CardsLeft == 0)
                        return;

                    capturedPlayer.ReceiveCard(deck.Deal());
                    capturedLabel.Text = FormatHandLabel(capturedPlayer.Hand);
                    UpdateCardCount();
                };

                btnStand.Click += (s, e) =>
                {
                    capturedPlayer.Stand();
                    capturedBtnHit.Enabled = false;
                    capturedBtnStand.Enabled = false;
                    capturedLabel.ForeColor = Color.Gray;
                    labelStatus.Text = $"{capturedPlayer.Name} staat op {capturedPlayer.Hand.CalculateValue()}.";
                };

                seat.Controls.Add(lblName);
                seat.Controls.Add(lblHand);
                seat.Controls.Add(btnHit);
                seat.Controls.Add(btnStand);
                panelPlayerArea.Controls.Add(seat);
            }
        }


        private void btnDealRound_Click(object sender, EventArgs e)
        {
            dealer.ResetForNewRound();
            foreach (var p in players)
                p.ResetForNewRound();

            ResetSeatControls();
            UpdateDealerDisplay();

            for (int round = 0; round < 2; round++)
            {
                foreach (var p in players)
                    DealCardToPlayer(p, FindHandLabel(p.Name));
                DealCardToDealer();
            }

            labelStatus.Text = "Kaarten gedeeld — spelers zijn aan de beurt.";
        }

        private void btnNewRound_Click(object sender, EventArgs e)
        {
            dealer.ResetForNewRound();
            foreach (var p in players)
                p.ResetForNewRound();

            ResetSeatControls();
            UpdateDealerDisplay();
            UpdateCardCount();
            labelStatus.Text = "Nieuwe ronde — klik 'Deal Round' om te beginnen.";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            deck.Reset();
            deck.Shuffle();
            dealer.ResetForNewRound();
            foreach (var p in players)
                p.ResetForNewRound();

            ResetSeatControls();
            UpdateDealerDisplay();
            UpdateCardCount();
            labelStatus.Text = "Reset — deck heeft 52 kaarten, handen gewist.";
        }

        private void btnDealerHit_Click(object sender, EventArgs e)
        {
            DealCardToDealer();
            labelStatus.Text = $"Dealer heeft {dealer.Hand.CalculateValue()}.";
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            deck.Shuffle();
            UpdateCardCount();
            labelStatus.Text = "Deck geschud.";
        }

        private void btnBackToSetup_Click(object sender, EventArgs e)
        {
            EnterSetupState();
        }


        private void DealCardToPlayer(Player player, Label handLabel)
        {
            if (deck.CardsLeft == 0) { labelStatus.Text = "Geen kaarten meer!"; return; }
            player.ReceiveCard(deck.Deal());
            handLabel.Text = FormatHandLabel(player.Hand);
            UpdateCardCount();
        }

        private void DealCardToDealer()
        {
            if (deck.CardsLeft == 0) { labelStatus.Text = "Geen kaarten meer!"; return; }
            dealer.ReceiveCard(deck.Deal());
            UpdateDealerDisplay();
            UpdateCardCount();
        }


        private void UpdateDealerDisplay()
        {
            if (dealer.Hand.CardCount == 0)
            {
                labelDealerHand.Text = "(leeg)";
                return;
            }
            labelDealerHand.Text = FormatHandLabel(dealer.Hand);
        }

        private string FormatHandLabel(Hand hand)
        {
            int value = hand.CalculateValue();
            string cards = hand.ToString()
                               .Replace($" (Value: {value})", "")
                               .Replace(", ", "\n");
            return cards + $"\n({value})";
        }

        private Label FindHandLabel(string playerName)
        {
            foreach (Control seat in panelPlayerArea.Controls)
                foreach (Control c in seat.Controls)
                    if (c.Name == "hand_" + playerName)
                        return (Label)c;
            return new Label();
        }

        private void ResetSeatControls()
        {
            foreach (Control seat in panelPlayerArea.Controls)
            {
                foreach (Control c in seat.Controls)
                {
                    if (c is Button btn)
                        btn.Enabled = true;
                    if (c is Label lbl && lbl.Name.StartsWith("hand_"))
                    {
                        lbl.ForeColor = Color.White;
                        lbl.Text = "(leeg)";
                    }
                }
            }
        }

        private void UpdateCardCount()
        {
            labelCardsLeft.Text = $"Cards left: {deck.CardsLeft}";
        }

        private void UpdateStateLabel()
        {
            labelGameState.Text = $"  State: {currentState.ToString().ToUpper()}";
        }


        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            string name = txtPlayerName.Text.Trim();
            if (string.IsNullOrEmpty(name)) { labelSetupInfo.Text = "Voer een naam in."; return; }
            if (players.Count >= MaxPlayers) { labelSetupInfo.Text = $"Maximaal {MaxPlayers} spelers."; return; }
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
            if (players.Count < MinPlayers) { labelSetupInfo.Text = $"Voeg minimaal {MinPlayers} speler toe."; return; }
            EnterPlayingState();
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
    }
}