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
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label2 = new Label();
            SuspendLayout();

            // label1
            label1.AutoSize = false;
            label1.Size = new Size(200, 30);
            label1.Location = new Point(122, 38);
            label1.Name = "label1";
            label1.TabIndex = 0;
            label1.Text = "";

            // button1
            button1.Location = new Point(47, 115);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "deal";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;

            // button2
            button2.Location = new Point(182, 115);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "shuffle";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;

            // button3
            button3.Location = new Point(331, 115);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 3;
            button3.Text = "reset";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;

            // label2
            label2.AutoSize = false;
            label2.Size = new Size(200, 30);
            label2.Location = new Point(311, 38);
            label2.Name = "label2";
            label2.TabIndex = 4;
            label2.Text = "Cards left: 52";

            // Form1
            ClientSize = new Size(711, 448);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            ResumeLayout(false);
        }

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label2;
    }
}