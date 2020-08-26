namespace KursovayaCSharp
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.RegisterStatusLabel = new System.Windows.Forms.Label();
            this.LoginNowLabel = new System.Windows.Forms.Label();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.PasswordFieldPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.UsernameFieldPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.FirstnameFieldPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.FirstnameTextBox = new System.Windows.Forms.TextBox();
            this.MiddlenameFieldPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MiddlenameTextBox = new System.Windows.Forms.TextBox();
            this.TelephoneFieldPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TelephoneTextBox = new System.Windows.Forms.TextBox();
            this.TelephonePictureBox = new System.Windows.Forms.PictureBox();
            this.MiddlenamePictureBox = new System.Windows.Forms.PictureBox();
            this.FirstnamePictureBox = new System.Windows.Forms.PictureBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.PasswordPictureBox = new System.Windows.Forms.PictureBox();
            this.UsernamePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TelephonePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiddlenamePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstnamePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsernamePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // RegisterStatusLabel
            // 
            this.RegisterStatusLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegisterStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.RegisterStatusLabel.Location = new System.Drawing.Point(56, 405);
            this.RegisterStatusLabel.Name = "RegisterStatusLabel";
            this.RegisterStatusLabel.Size = new System.Drawing.Size(288, 53);
            this.RegisterStatusLabel.TabIndex = 0;
            this.RegisterStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginNowLabel
            // 
            this.LoginNowLabel.AutoSize = true;
            this.LoginNowLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginNowLabel.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginNowLabel.ForeColor = System.Drawing.Color.White;
            this.LoginNowLabel.Location = new System.Drawing.Point(63, 472);
            this.LoginNowLabel.Name = "LoginNowLabel";
            this.LoginNowLabel.Size = new System.Drawing.Size(274, 19);
            this.LoginNowLabel.TabIndex = 7;
            this.LoginNowLabel.Text = "Уже имеете аккаунт? Войдите сечас.";
            this.LoginNowLabel.Click += new System.EventHandler(this.LoginNowLabel_Click);
            this.LoginNowLabel.MouseEnter += new System.EventHandler(this.LoginNowLabel_MouseEnter);
            this.LoginNowLabel.MouseLeave += new System.EventHandler(this.LoginNowLabel_MouseLeave);
            // 
            // RegisterButton
            // 
            this.RegisterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.RegisterButton.FlatAppearance.BorderSize = 0;
            this.RegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterButton.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegisterButton.ForeColor = System.Drawing.Color.White;
            this.RegisterButton.Location = new System.Drawing.Point(56, 326);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(288, 58);
            this.RegisterButton.TabIndex = 6;
            this.RegisterButton.Text = "Зарегистироваться";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // PasswordFieldPanel
            // 
            this.PasswordFieldPanel.BackColor = System.Drawing.Color.White;
            this.PasswordFieldPanel.Location = new System.Drawing.Point(94, 117);
            this.PasswordFieldPanel.Name = "PasswordFieldPanel";
            this.PasswordFieldPanel.Size = new System.Drawing.Size(250, 1);
            this.PasswordFieldPanel.TabIndex = 0;
            // 
            // UsernameFieldPanel
            // 
            this.UsernameFieldPanel.BackColor = System.Drawing.Color.White;
            this.UsernameFieldPanel.Location = new System.Drawing.Point(94, 56);
            this.UsernameFieldPanel.Name = "UsernameFieldPanel";
            this.UsernameFieldPanel.Size = new System.Drawing.Size(250, 1);
            this.UsernameFieldPanel.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordTextBox.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordTextBox.ForeColor = System.Drawing.Color.White;
            this.PasswordTextBox.Location = new System.Drawing.Point(94, 90);
            this.PasswordTextBox.MaxLength = 20;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(250, 29);
            this.PasswordTextBox.TabIndex = 2;
            this.PasswordTextBox.Text = "Пароль";
            this.PasswordTextBox.Enter += new System.EventHandler(this.PasswordTextBox_Enter);
            this.PasswordTextBox.Leave += new System.EventHandler(this.PasswordTextBox_Leave);
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UsernameTextBox.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsernameTextBox.ForeColor = System.Drawing.Color.White;
            this.UsernameTextBox.Location = new System.Drawing.Point(94, 28);
            this.UsernameTextBox.MaxLength = 20;
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(250, 29);
            this.UsernameTextBox.TabIndex = 1;
            this.UsernameTextBox.Text = "Логин";
            this.UsernameTextBox.Enter += new System.EventHandler(this.UsernameTextBox_Enter);
            this.UsernameTextBox.Leave += new System.EventHandler(this.UsernameTextBox_Leave);
            // 
            // FirstnameFieldPanel
            // 
            this.FirstnameFieldPanel.BackColor = System.Drawing.Color.White;
            this.FirstnameFieldPanel.Location = new System.Drawing.Point(94, 180);
            this.FirstnameFieldPanel.Name = "FirstnameFieldPanel";
            this.FirstnameFieldPanel.Size = new System.Drawing.Size(250, 1);
            this.FirstnameFieldPanel.TabIndex = 0;
            // 
            // FirstnameTextBox
            // 
            this.FirstnameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.FirstnameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FirstnameTextBox.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstnameTextBox.ForeColor = System.Drawing.Color.White;
            this.FirstnameTextBox.Location = new System.Drawing.Point(94, 152);
            this.FirstnameTextBox.MaxLength = 20;
            this.FirstnameTextBox.Name = "FirstnameTextBox";
            this.FirstnameTextBox.Size = new System.Drawing.Size(250, 29);
            this.FirstnameTextBox.TabIndex = 3;
            this.FirstnameTextBox.Text = "Имя";
            this.FirstnameTextBox.Enter += new System.EventHandler(this.FirstnameTextBox_Enter);
            this.FirstnameTextBox.Leave += new System.EventHandler(this.FirstnameTextBox_Leave);
            // 
            // MiddlenameFieldPanel
            // 
            this.MiddlenameFieldPanel.BackColor = System.Drawing.Color.White;
            this.MiddlenameFieldPanel.Location = new System.Drawing.Point(94, 242);
            this.MiddlenameFieldPanel.Name = "MiddlenameFieldPanel";
            this.MiddlenameFieldPanel.Size = new System.Drawing.Size(250, 1);
            this.MiddlenameFieldPanel.TabIndex = 0;
            // 
            // MiddlenameTextBox
            // 
            this.MiddlenameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.MiddlenameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MiddlenameTextBox.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MiddlenameTextBox.ForeColor = System.Drawing.Color.White;
            this.MiddlenameTextBox.Location = new System.Drawing.Point(94, 214);
            this.MiddlenameTextBox.MaxLength = 20;
            this.MiddlenameTextBox.Name = "MiddlenameTextBox";
            this.MiddlenameTextBox.Size = new System.Drawing.Size(250, 29);
            this.MiddlenameTextBox.TabIndex = 4;
            this.MiddlenameTextBox.Text = "Фамилия";
            this.MiddlenameTextBox.Enter += new System.EventHandler(this.MiddlenameTextBox_Enter);
            this.MiddlenameTextBox.Leave += new System.EventHandler(this.MiddlenameTextBox_Leave);
            // 
            // TelephoneFieldPanel
            // 
            this.TelephoneFieldPanel.BackColor = System.Drawing.Color.White;
            this.TelephoneFieldPanel.Location = new System.Drawing.Point(94, 304);
            this.TelephoneFieldPanel.Name = "TelephoneFieldPanel";
            this.TelephoneFieldPanel.Size = new System.Drawing.Size(250, 1);
            this.TelephoneFieldPanel.TabIndex = 0;
            // 
            // TelephoneTextBox
            // 
            this.TelephoneTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.TelephoneTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TelephoneTextBox.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TelephoneTextBox.ForeColor = System.Drawing.Color.White;
            this.TelephoneTextBox.Location = new System.Drawing.Point(94, 276);
            this.TelephoneTextBox.MaxLength = 20;
            this.TelephoneTextBox.Name = "TelephoneTextBox";
            this.TelephoneTextBox.Size = new System.Drawing.Size(250, 29);
            this.TelephoneTextBox.TabIndex = 5;
            this.TelephoneTextBox.Text = "Телефон";
            this.TelephoneTextBox.Enter += new System.EventHandler(this.TelephoneTextBox_Enter);
            this.TelephoneTextBox.Leave += new System.EventHandler(this.TelephoneTextBox_Leave);
            // 
            // TelephonePictureBox
            // 
            this.TelephonePictureBox.Image = global::KursovayaCSharp.Properties.Resources.phone_icon;
            this.TelephonePictureBox.Location = new System.Drawing.Point(56, 273);
            this.TelephonePictureBox.Name = "TelephonePictureBox";
            this.TelephonePictureBox.Size = new System.Drawing.Size(32, 32);
            this.TelephonePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TelephonePictureBox.TabIndex = 0;
            this.TelephonePictureBox.TabStop = false;
            // 
            // MiddlenamePictureBox
            // 
            this.MiddlenamePictureBox.Image = global::KursovayaCSharp.Properties.Resources.middlename_icon;
            this.MiddlenamePictureBox.Location = new System.Drawing.Point(56, 211);
            this.MiddlenamePictureBox.Name = "MiddlenamePictureBox";
            this.MiddlenamePictureBox.Size = new System.Drawing.Size(32, 32);
            this.MiddlenamePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MiddlenamePictureBox.TabIndex = 0;
            this.MiddlenamePictureBox.TabStop = false;
            // 
            // FirstnamePictureBox
            // 
            this.FirstnamePictureBox.Image = global::KursovayaCSharp.Properties.Resources.firstname_icon;
            this.FirstnamePictureBox.Location = new System.Drawing.Point(56, 149);
            this.FirstnamePictureBox.Name = "FirstnamePictureBox";
            this.FirstnamePictureBox.Size = new System.Drawing.Size(32, 32);
            this.FirstnamePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FirstnamePictureBox.TabIndex = 0;
            this.FirstnamePictureBox.TabStop = false;
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
            this.PasswordPictureBox.Location = new System.Drawing.Point(56, 86);
            this.PasswordPictureBox.Name = "PasswordPictureBox";
            this.PasswordPictureBox.Size = new System.Drawing.Size(32, 32);
            this.PasswordPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PasswordPictureBox.TabIndex = 0;
            this.PasswordPictureBox.TabStop = false;
            // 
            // UsernamePictureBox
            // 
            this.UsernamePictureBox.Image = global::KursovayaCSharp.Properties.Resources.user_icon;
            this.UsernamePictureBox.Location = new System.Drawing.Point(56, 25);
            this.UsernamePictureBox.Name = "UsernamePictureBox";
            this.UsernamePictureBox.Size = new System.Drawing.Size(32, 32);
            this.UsernamePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UsernamePictureBox.TabIndex = 0;
            this.UsernamePictureBox.TabStop = false;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.TelephoneFieldPanel);
            this.Controls.Add(this.TelephonePictureBox);
            this.Controls.Add(this.MiddlenameFieldPanel);
            this.Controls.Add(this.TelephoneTextBox);
            this.Controls.Add(this.MiddlenamePictureBox);
            this.Controls.Add(this.FirstnameFieldPanel);
            this.Controls.Add(this.MiddlenameTextBox);
            this.Controls.Add(this.FirstnamePictureBox);
            this.Controls.Add(this.RegisterStatusLabel);
            this.Controls.Add(this.FirstnameTextBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.LoginNowLabel);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.PasswordFieldPanel);
            this.Controls.Add(this.PasswordPictureBox);
            this.Controls.Add(this.UsernameFieldPanel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UsernamePictureBox);
            this.Controls.Add(this.UsernameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            ((System.ComponentModel.ISupportInitialize)(this.TelephonePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiddlenamePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstnamePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsernamePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label RegisterStatusLabel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label LoginNowLabel;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.FlowLayoutPanel PasswordFieldPanel;
        private System.Windows.Forms.PictureBox PasswordPictureBox;
        private System.Windows.Forms.FlowLayoutPanel UsernameFieldPanel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.PictureBox UsernamePictureBox;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.FlowLayoutPanel FirstnameFieldPanel;
        private System.Windows.Forms.PictureBox FirstnamePictureBox;
        private System.Windows.Forms.TextBox FirstnameTextBox;
        private System.Windows.Forms.FlowLayoutPanel MiddlenameFieldPanel;
        private System.Windows.Forms.PictureBox MiddlenamePictureBox;
        private System.Windows.Forms.TextBox MiddlenameTextBox;
        private System.Windows.Forms.FlowLayoutPanel TelephoneFieldPanel;
        private System.Windows.Forms.PictureBox TelephonePictureBox;
        private System.Windows.Forms.TextBox TelephoneTextBox;
    }
}