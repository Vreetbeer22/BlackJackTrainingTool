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
            panelSetup = new Panel();
            panelGame = new Panel();

            // Setup controls
            labelSetupTitle = new Label();
            labelPlayerNamePrompt = new Label();
            txtPlayerName = new TextBox();
            btnAddPlayer = new Button();
            listBoxPlayers = new ListBox();
            btnRemovePlayer = new Button();
            btnStartGame = new Button();
            labelSetupInfo = new Label();

            // Game controls
            labelStatus = new Label();
            labelCardsLeft = new Label();
            panelDealerSeat = new Panel();
            labelDealerName = new Label();
            labelDealerHand = new Label();
            btnDealerHit = new Button();
            panelPlayerArea = new Panel();
            btnDealRound = new Button();
            btnNewRound = new Button();
            btnShuffle = new Button();
            btnReset = new Button();
            btnBackToSetup = new Button();

            SuspendLayout();

            // ════════════════════════════════════════════════════════════
            // panelSetup — fills the whole form
            // ════════════════════════════════════════════════════════════
            panelSetup.Location = new Point(0, 0);
            panelSetup.Dock = DockStyle.Fill;
            panelSetup.Name = "panelSetup";
            panelSetup.Visible = true;

            labelSetupTitle.Text = "♠  Blackjack  ♥";
            labelSetupTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            labelSetupTitle.TextAlign = ContentAlignment.MiddleCenter;
            labelSetupTitle.AutoSize = false;
            labelSetupTitle.Dock = DockStyle.Top;
            labelSetupTitle.Height = 60;
            labelSetupTitle.TextAlign = ContentAlignment.MiddleCenter;
            panelSetup.Controls.Add(labelSetupTitle);

            labelPlayerNamePrompt.Text = "Spelernaam:";
            labelPlayerNamePrompt.AutoSize = true;
            labelPlayerNamePrompt.Location = new Point(155, 110);
            panelSetup.Controls.Add(labelPlayerNamePrompt);

            txtPlayerName.Location = new Point(155, 135);
            txtPlayerName.Size = new Size(200, 27);
            txtPlayerName.Name = "txtPlayerName";
            txtPlayerName.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnAddPlayer_Click(s, e); };
            panelSetup.Controls.Add(txtPlayerName);

            btnAddPlayer.Location = new Point(370, 134);
            btnAddPlayer.Size = new Size(110, 29);
            btnAddPlayer.Text = "Toevoegen";
            btnAddPlayer.Name = "btnAddPlayer";
            btnAddPlayer.UseVisualStyleBackColor = true;
            btnAddPlayer.Click += btnAddPlayer_Click;
            panelSetup.Controls.Add(btnAddPlayer);

            listBoxPlayers.Location = new Point(155, 180);
            listBoxPlayers.Size = new Size(200, 120);
            listBoxPlayers.Name = "listBoxPlayers";
            panelSetup.Controls.Add(listBoxPlayers);

            btnRemovePlayer.Location = new Point(370, 180);
            btnRemovePlayer.Size = new Size(110, 29);
            btnRemovePlayer.Text = "Verwijderen";
            btnRemovePlayer.Name = "btnRemovePlayer";
            btnRemovePlayer.UseVisualStyleBackColor = true;
            btnRemovePlayer.Click += btnRemovePlayer_Click;
            panelSetup.Controls.Add(btnRemovePlayer);

            labelSetupInfo.AutoSize = false;
            labelSetupInfo.Size = new Size(300, 25);
            labelSetupInfo.Location = new Point(155, 315);
            labelSetupInfo.Name = "labelSetupInfo";
            labelSetupInfo.Text = "Spelers: 0/4";
            panelSetup.Controls.Add(labelSetupInfo);

            btnStartGame.Location = new Point(155, 355);
            btnStartGame.Size = new Size(150, 35);
            btnStartGame.Text = "Start spel ▶";
            btnStartGame.Name = "btnStartGame";
            btnStartGame.Enabled = false;
            btnStartGame.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnStartGame.UseVisualStyleBackColor = true;
            btnStartGame.Click += btnStartGame_Click;
            panelSetup.Controls.Add(btnStartGame);

            // ════════════════════════════════════════════════════════════
            // panelGame — fills the whole form, uses layout rows
            // ════════════════════════════════════════════════════════════
            panelGame.Location = new Point(0, 0);
            panelGame.Dock = DockStyle.Fill;
            panelGame.Name = "panelGame";
            panelGame.Visible = false;
            panelGame.BackColor = Color.FromArgb(0, 100, 0);
            panelGame.Resize += panelGame_Resize;

            // ── Top bar: status + cards left ────────────────────────────
            labelStatus.AutoSize = false;
            labelStatus.Size = new Size(500, 26);
            labelStatus.Location = new Point(8, 6);
            labelStatus.Name = "labelStatus";
            labelStatus.Text = "";
            labelStatus.ForeColor = Color.White;
            labelStatus.BackColor = Color.Transparent;
            labelStatus.TextAlign = ContentAlignment.MiddleLeft;
            labelStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelGame.Controls.Add(labelStatus);

            labelCardsLeft.AutoSize = false;
            labelCardsLeft.Size = new Size(130, 26);
            labelCardsLeft.Location = new Point(570, 6);
            labelCardsLeft.Name = "labelCardsLeft";
            labelCardsLeft.Text = "Cards left: 52";
            labelCardsLeft.ForeColor = Color.White;
            labelCardsLeft.BackColor = Color.Transparent;
            labelCardsLeft.TextAlign = ContentAlignment.MiddleRight;
            labelCardsLeft.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelGame.Controls.Add(labelCardsLeft);

            // ── Dealer seat ──────────────────────────────────────────────
            panelDealerSeat.Location = new Point(256, 40);
            panelDealerSeat.Size = new Size(200, 140);
            panelDealerSeat.Name = "panelDealerSeat";
            panelDealerSeat.BackColor = Color.FromArgb(0, 80, 0);
            panelDealerSeat.BorderStyle = BorderStyle.FixedSingle;
            panelDealerSeat.Anchor = AnchorStyles.Top;

            labelDealerName.Text = "DEALER";
            labelDealerName.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            labelDealerName.ForeColor = Color.Gold;
            labelDealerName.AutoSize = false;
            labelDealerName.Size = new Size(190, 20);
            labelDealerName.Location = new Point(5, 5);
            labelDealerName.TextAlign = ContentAlignment.MiddleCenter;
            panelDealerSeat.Controls.Add(labelDealerName);

            labelDealerHand.AutoSize = false;
            labelDealerHand.Size = new Size(190, 80);
            labelDealerHand.Location = new Point(5, 28);
            labelDealerHand.Name = "labelDealerHand";
            labelDealerHand.Text = "(leeg)";
            labelDealerHand.ForeColor = Color.White;
            labelDealerHand.BackColor = Color.Transparent;
            labelDealerHand.TextAlign = ContentAlignment.TopCenter;
            panelDealerSeat.Controls.Add(labelDealerHand);

            btnDealerHit.Text = "Hit";
            btnDealerHit.Location = new Point(60, 108);
            btnDealerHit.Size = new Size(75, 26);
            btnDealerHit.Name = "btnDealerHit";
            btnDealerHit.UseVisualStyleBackColor = true;
            btnDealerHit.Click += btnDealerHit_Click;
            panelDealerSeat.Controls.Add(btnDealerHit);

            panelGame.Controls.Add(panelDealerSeat);

            // ── Player area — anchored to all 4 sides so it stretches ────
            panelPlayerArea.Name = "panelPlayerArea";
            panelPlayerArea.BackColor = Color.Transparent;
            panelPlayerArea.Anchor = AnchorStyles.Top | AnchorStyles.Bottom
                                   | AnchorStyles.Left | AnchorStyles.Right;
            panelGame.Controls.Add(panelPlayerArea);

            // ── Bottom button bar ────────────────────────────────────────
            btnDealRound.Size = new Size(120, 28);
            btnDealRound.Text = "Deel Ronde ▶";
            btnDealRound.Name = "btnDealRound";
            btnDealRound.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnDealRound.UseVisualStyleBackColor = true;
            btnDealRound.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDealRound.Click += btnDealRound_Click;
            panelGame.Controls.Add(btnDealRound);

            btnNewRound.Size = new Size(110, 28);
            btnNewRound.Text = "Nieuwe Ronde";
            btnNewRound.Name = "btnNewRound";
            btnNewRound.UseVisualStyleBackColor = true;
            btnNewRound.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNewRound.Click += btnNewRound_Click;
            panelGame.Controls.Add(btnNewRound);

            btnShuffle.Size = new Size(90, 28);
            btnShuffle.Text = "Shuffle";
            btnShuffle.Name = "btnShuffle";
            btnShuffle.UseVisualStyleBackColor = true;
            btnShuffle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnShuffle.Click += btnShuffle_Click;
            panelGame.Controls.Add(btnShuffle);

            btnReset.Size = new Size(90, 28);
            btnReset.Text = "Reset";
            btnReset.Name = "btnReset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnReset.Click += btnReset_Click;
            panelGame.Controls.Add(btnReset);

            btnBackToSetup.Size = new Size(130, 28);
            btnBackToSetup.Text = "◀ Terug naar setup";
            btnBackToSetup.Name = "btnBackToSetup";
            btnBackToSetup.UseVisualStyleBackColor = true;
            btnBackToSetup.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBackToSetup.Click += btnBackToSetup_Click;
            panelGame.Controls.Add(btnBackToSetup);

            // ── State label — docked to bottom of Form ───────────────────
            labelGameState = new Label();
            labelGameState.Dock = DockStyle.Bottom;
            labelGameState.Height = 24;
            labelGameState.Name = "labelGameState";
            labelGameState.Text = "State: SETUP";
            labelGameState.TextAlign = ContentAlignment.MiddleLeft;
            labelGameState.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            labelGameState.BackColor = SystemColors.ControlDark;
            labelGameState.ForeColor = Color.White;
            Controls.Add(labelGameState);

            // ════════════════════════════════════════════════════════════
            // Form1
            // ════════════════════════════════════════════════════════════
            ClientSize = new Size(711, 500);
            MinimumSize = new Size(711, 500);
            Controls.Add(panelSetup);
            Controls.Add(panelGame);
            Name = "Form1";
            Text = "Blackjack";
            ResumeLayout(false);
        }

        // ── Setup panel ──────────────────────────────────────────────────
        private Panel panelSetup;
        private Label labelSetupTitle;
        private Label labelPlayerNamePrompt;
        private TextBox txtPlayerName;
        private Button btnAddPlayer;
        private ListBox listBoxPlayers;
        private Button btnRemovePlayer;
        private Button btnStartGame;
        private Label labelSetupInfo;

        // ── Game panel ───────────────────────────────────────────────────
        private Panel panelGame;
        private Label labelStatus;
        private Label labelCardsLeft;
        private Panel panelDealerSeat;
        private Label labelDealerName;
        private Label labelDealerHand;
        private Button btnDealerHit;
        private Panel panelPlayerArea;
        private Button btnDealRound;
        private Button btnNewRound;
        private Button btnShuffle;
        private Button btnReset;
        private Button btnBackToSetup;
        private Label labelGameState;
    }
}