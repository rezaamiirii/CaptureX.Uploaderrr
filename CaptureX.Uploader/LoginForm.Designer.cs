namespace CaptureX.Uploader
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            UsernameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            LoginButton = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Location = new Point(78, 41);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.PlaceholderText = "User name";
            UsernameTextBox.Size = new Size(158, 27);
            UsernameTextBox.TabIndex = 2;
            UsernameTextBox.Text = "admin";
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(78, 72);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PlaceholderText = "Password";
            PasswordTextBox.Size = new Size(158, 27);
            PasswordTextBox.TabIndex = 3;
            PasswordTextBox.Text = "admin";
            PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(78, 105);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(158, 29);
            LoginButton.TabIndex = 4;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(UsernameTextBox);
            panel1.Controls.Add(LoginButton);
            panel1.Controls.Add(PasswordTextBox);
            panel1.Location = new Point(74, 37);
            panel1.Name = "panel1";
            panel1.Size = new Size(315, 203);
            panel1.TabIndex = 5;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(479, 282);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label UsernameLabel;
        private Label PasswordLabel;
        private TextBox UsernameTextBox;
        private TextBox PasswordTextBox;
        private Button LoginButton;
        private Panel panel1;
    }
}