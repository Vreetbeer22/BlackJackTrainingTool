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
            // ── Panels ───────────────────────────────────────────────────
            panelSetup = new Panel();
            panelGame = new Panel();

            // ── Setup panel controls ─────────────────────────────────────
            labelSetupTitle = new Label();
            labelPlayerNamePrompt = new Label();
            txtPlayerName = new TextBox();
            btnAddPlayer = new Button();
            listBoxPlayers = new ListBox();
            btnRemovePlayer = new Button();
            btnStartGame = new Button();
            labelSetupInfo = new Label();

            // ── Game panel controls ──────────────────────────────────────
            labelCard = new Label();
            btnDeal = new Button();
            btnShuffle = new Button();
            btnReset = new Button();
            labelCardsLeft = new Label();
            labelStatus = new Label();
            btnBackToSetup = new Button();

            SuspendLayout();

            // ════════════════════════════════════════════════════════════
            // panelSetup
            // ════════════════════════════════════════════════════════════
            panelSetup.Location = new Point(0, 0);
            panelSetup.Size = new Size(711, 448);
            panelSetup.Name = "panelSetup";
            panelSetup.Visible = true;

            // labelSetupTitle
            labelSetupTitle.Text = "♠  Blackjack  ♥";
            labelSetupTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            labelSetupTitle.AutoSize = false;
            labelSetupTitle.Size = new Size(400, 45);
            labelSetupTitle.Location = new Point(155, 30);
            labelSetupTitle.TextAlign = ContentAlignment.MiddleCenter;
            panelSetup.Controls.Add(labelSetupTitle);

            // labelPlayerNamePrompt
            labelPlayerNamePrompt.Text = "Spelernaam:";
            labelPlayerNamePrompt.AutoSize = true;
            labelPlayerNamePrompt.Location = new Point(155, 110);
            panelSetup.Controls.Add(labelPlayerNamePrompt);

            // txtPlayerName
            txtPlayerName.Location = new Point(155, 135);
            txtPlayerName.Size = new Size(200, 27);
            txtPlayerName.Name = "txtPlayerName";
            txtPlayerName.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnAddPlayer_Click(s, e); };
            panelSetup.Controls.Add(txtPlayerName);

            // btnAddPlayer
            btnAddPlayer.Location = new Point(370, 134);
            btnAddPlayer.Size = new Size(110, 29);
            btnAddPlayer.Text = "Toevoegen";
            btnAddPlayer.Name = "btnAddPlayer";
            btnAddPlayer.UseVisualStyleBackColor = true;
            btnAddPlayer.Click += btnAddPlayer_Click;
            panelSetup.Controls.Add(btnAddPlayer);

            // listBoxPlayers
            listBoxPlayers.Location = new Point(155, 180);
            listBoxPlayers.Size = new Size(200, 120);
            listBoxPlayers.Name = "listBoxPlayers";
            panelSetup.Controls.Add(listBoxPlayers);

            // btnRemovePlayer
            btnRemovePlayer.Location = new Point(370, 180);
            btnRemovePlayer.Size = new Size(110, 29);
            btnRemovePlayer.Text = "Verwijderen";
            btnRemovePlayer.Name = "btnRemovePlayer";
            btnRemovePlayer.UseVisualStyleBackColor = true;
            btnRemovePlayer.Click += btnRemovePlayer_Click;
            panelSetup.Controls.Add(btnRemovePlayer);

            // labelSetupInfo
            labelSetupInfo.AutoSize = false;
            labelSetupInfo.Size = new Size(300, 25);
            labelSetupInfo.Location = new Point(155, 315);
            labelSetupInfo.Name = "labelSetupInfo";
            labelSetupInfo.Text = "Spelers: 0/4";
            panelSetup.Controls.Add(labelSetupInfo);

            // btnStartGame
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
            // panelGame
            // ════════════════════════════════════════════════════════════
            panelGame.Location = new Point(0, 0);
            panelGame.Size = new Size(711, 448);
            panelGame.Name = "panelGame";
            panelGame.Visible = false;

            // labelStatus
            labelStatus.AutoSize = false;
            labelStatus.Size = new Size(650, 30);
            labelStatus.Location = new Point(30, 20);
            labelStatus.Name = "labelStatus";
            labelStatus.Text = "";
            panelGame.Controls.Add(labelStatus);

            // labelCard
            labelCard.AutoSize = false;
            labelCard.Size = new Size(300, 30);
            labelCard.Location = new Point(122, 70);
            labelCard.Name = "labelCard";
            labelCard.Text = "";
            panelGame.Controls.Add(labelCard);

            // labelCardsLeft
            labelCardsLeft.AutoSize = false;
            labelCardsLeft.Size = new Size(200, 30);
            labelCardsLeft.Location = new Point(400, 70);
            labelCardsLeft.Name = "labelCardsLeft";
            labelCardsLeft.Text = "Cards left: 52";
            panelGame.Controls.Add(labelCardsLeft);

            // btnDeal
            btnDeal.Location = new Point(47, 150);
            btnDeal.Size = new Size(94, 29);
            btnDeal.Text = "Deal";
            btnDeal.Name = "btnDeal";
            btnDeal.UseVisualStyleBackColor = true;
            btnDeal.Click += btnDeal_Click;
            panelGame.Controls.Add(btnDeal);

            // btnShuffle
            btnShuffle.Location = new Point(182, 150);
            btnShuffle.Size = new Size(94, 29);
            btnShuffle.Text = "Shuffle";
            btnShuffle.Name = "btnShuffle";
            btnShuffle.UseVisualStyleBackColor = true;
            btnShuffle.Click += btnShuffle_Click;
            panelGame.Controls.Add(btnShuffle);

            // btnReset
            btnReset.Location = new Point(331, 150);
            btnReset.Size = new Size(94, 29);
            btnReset.Text = "Reset";
            btnReset.Name = "btnReset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            panelGame.Controls.Add(btnReset);

            // btnBackToSetup
            btnBackToSetup.Location = new Point(47, 380);
            btnBackToSetup.Size = new Size(130, 29);
            btnBackToSetup.Text = "◀ Terug naar setup";
            btnBackToSetup.Name = "btnBackToSetup";
            btnBackToSetup.UseVisualStyleBackColor = true;
            btnBackToSetup.Click += btnBackToSetup_Click;
            panelGame.Controls.Add(btnBackToSetup);

            // labelGameState (statusbalk onderaan)
            labelGameState = new Label();
            labelGameState.AutoSize = false;
            labelGameState.Size = new Size(711, 24);
            labelGameState.Location = new Point(0, 424);
            labelGameState.Name = "labelGameState";
            labelGameState.Text = "State: SETUP";
            labelGameState.TextAlign = ContentAlignment.MiddleLeft;
            labelGameState.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            labelGameState.BackColor = SystemColors.ControlDark;
            labelGameState.ForeColor = Color.White;
            Controls.Add(labelGameState); // voeg toe aan Form, niet aan een panel

            // ════════════════════════════════════════════════════════════
            // Form1
            // ════════════════════════════════════════════════════════════
            ClientSize = new Size(711, 448);
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
        private Label labelCard;
        private Button btnDeal;
        private Button btnShuffle;
        private Button btnReset;
        private Label labelCardsLeft;
        private Label labelStatus;
        private Button btnBackToSetup;
        private Label labelGameState;
    }
}