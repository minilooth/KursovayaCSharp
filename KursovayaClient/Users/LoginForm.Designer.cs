namespace KursovayaCSharp
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
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.UsernameFieldPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.PasswordFieldPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.RegisterNowLabel = new System.Windows.Forms.Label();
            this.LoginStatusLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.PasswordPictureBox = new System.Windows.Forms.PictureBox();
            this.UsernamePictureBox = new System.Windows.Forms.PictureBox();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsernamePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UsernameTextBox.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsernameTextBox.ForeColor = System.Drawing.Color.White;
            this.UsernameTextBox.Location = new System.Drawing.Point(94, 201);
            this.UsernameTextBox.MaxLength = 20;
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(250, 29);
            this.UsernameTextBox.TabIndex = 1;
            this.UsernameTextBox.Text = "Логин";
            this.UsernameTextBox.Enter += new System.EventHandler(this.UsernameTextBox_Enter);
            this.UsernameTextBox.Leave += new System.EventHandler(this.UsernameTextBox_Leave);
            // 
            // UsernameFieldPanel
            // 
            this.UsernameFieldPanel.BackColor = System.Drawing.Color.White;
            this.UsernameFieldPanel.Location = new System.Drawing.Point(94, 229);
            this.UsernameFieldPanel.Name = "UsernameFieldPanel";
            this.UsernameFieldPanel.Size = new System.Drawing.Size(250, 1);
            this.UsernameFieldPanel.TabIndex = 0;
            // 
            // PasswordFieldPanel
            // 
            this.PasswordFieldPanel.BackColor = System.Drawing.Color.White;
            this.PasswordFieldPanel.Location = new System.Drawing.Point(94, 292);
            this.PasswordFieldPanel.Name = "PasswordFieldPanel";
            this.PasswordFieldPanel.Size = new System.Drawing.Size(250, 1);
            this.PasswordFieldPanel.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordTextBox.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordTextBox.ForeColor = System.Drawing.Color.White;
            this.PasswordTextBox.Location = new System.Drawing.Point(94, 264);
            this.PasswordTextBox.MaxLength = 20;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(250, 29);
            this.PasswordTextBox.TabIndex = 2;
            this.PasswordTextBox.Text = "Пароль";
            this.PasswordTextBox.Enter += new System.EventHandler(this.PasswordTextBox_Enter);
            this.PasswordTextBox.Leave += new System.EventHandler(this.PasswordTextBox_Leave);
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.LoginButton.FlatAppearance.BorderSize = 0;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginButton.ForeColor = System.Drawing.Color.White;
            this.LoginButton.Location = new System.Drawing.Point(56, 326);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(288, 58);
            this.LoginButton.TabIndex = 3;
            this.LoginButton.Text = "Войти";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // RegisterNowLabel
            // 
            this.RegisterNowLabel.AutoSize = true;
            this.RegisterNowLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegisterNowLabel.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegisterNowLabel.ForeColor = System.Drawing.Color.White;
            this.RegisterNowLabel.Location = new System.Drawing.Point(28, 472);
            this.RegisterNowLabel.Name = "RegisterNowLabel";
            this.RegisterNowLabel.Size = new System.Drawing.Size(344, 19);
            this.RegisterNowLabel.TabIndex = 3;
            this.RegisterNowLabel.Text = "Еще нет аккаунта? Зарегистироваться сейчас.";
            this.RegisterNowLabel.Click += new System.EventHandler(this.RegisterNowLabel_Click);
            this.RegisterNowLabel.MouseEnter += new System.EventHandler(this.RegisterNowLabel_MouseEnter);
            this.RegisterNowLabel.MouseLeave += new System.EventHandler(this.RegisterNowLabel_MouseLeave);
            // 
            // LoginStatusLabel
            // 
            this.LoginStatusLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.LoginStatusLabel.Location = new System.Drawing.Point(56, 405);
            this.LoginStatusLabel.Name = "LoginStatusLabel";
            this.LoginStatusLabel.Size = new System.Drawing.Size(288, 53);
            this.LoginStatusLabel.TabIndex = 0;
            this.LoginStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExitButton
            // 
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Location = new System.Drawing.Point(368, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(32, 32);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            // 
            // PasswordPictureBox
            // 
            this.PasswordPictureBox.Image = global::KursovayaCSharp.Properties.Resources.password_icon;
            this.PasswordPictureBox.Location = new System.Drawing.Point(56, 261);
            this.PasswordPictureBox.Name = "PasswordPictureBox";
            this.PasswordPictureBox.Size = new System.Drawing.Size(32, 32);
            this.PasswordPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PasswordPictureBox.TabIndex = 0;
            this.PasswordPictureBox.TabStop = false;
            // 
            // UsernamePictureBox
            // 
            this.UsernamePictureBox.Image = global::KursovayaCSharp.Properties.Resources.user_icon;
            this.UsernamePictureBox.Location = new System.Drawing.Point(56, 198);
            this.UsernamePictureBox.Name = "UsernamePictureBox";
            this.UsernamePictureBox.Size = new System.Drawing.Size(32, 32);
            this.UsernamePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UsernamePictureBox.TabIndex = 0;
            this.UsernamePictureBox.TabStop = false;
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.Image = global::KursovayaCSharp.Properties.Resources.logo;
            this.LogoPictureBox.Location = new System.Drawing.Point(60, 12);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(284, 158);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoPictureBox.TabIndex = 5;
            this.LogoPictureBox.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.LogoPictureBox);
            this.Controls.Add(this.LoginStatusLabel);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.RegisterNowLabel);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordFieldPanel);
            this.Controls.Add(this.PasswordPictureBox);
            this.Controls.Add(this.UsernameFieldPanel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UsernamePictureBox);
            this.Controls.Add(this.UsernameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PasswordPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsernamePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.PictureBox UsernamePictureBox;
        private System.Windows.Forms.FlowLayoutPanel UsernameFieldPanel;
        private System.Windows.Forms.FlowLayoutPanel PasswordFieldPanel;
        private System.Windows.Forms.PictureBox PasswordPictureBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label RegisterNowLabel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label LoginStatusLabel;
        private System.Windows.Forms.PictureBox LogoPictureBox;
    }
}

