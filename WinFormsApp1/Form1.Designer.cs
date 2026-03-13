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
            button1 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(26, 34);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new EventHandler(button1_Click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 123);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 1;
            label1.Text = "";
            // 
            // Form1
            // 
            ClientSize = new Size(282, 253);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            ResumeLayout(false);
            PerformLayout();

        }

        private Button button1;
        private Label label1;
    }
}
