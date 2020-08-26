namespace KursovayaCSharp
{
    partial class UserEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserEditForm));
            this.ChangeUserButton = new System.Windows.Forms.Button();
            this.BanStatusCheckBox = new System.Windows.Forms.CheckBox();
            this.BanStatusLabel = new System.Windows.Forms.Label();
            this.SuperUserCheckBox = new System.Windows.Forms.CheckBox();
            this.SuperUserLabel = new System.Windows.Forms.Label();
            this.TelephonePanel = new System.Windows.Forms.Panel();
            this.TelephoneLabel = new System.Windows.Forms.Label();
            this.TelephoneTextBox = new System.Windows.Forms.TextBox();
            this.SurnamePanel = new System.Windows.Forms.Panel();
            this.SurnameLabel = new System.Windows.Forms.Label();
            this.SurnameTextBox = new System.Windows.Forms.TextBox();
            this.FirstnamePanel = new System.Windows.Forms.Panel();
            this.FirstnameLabel = new System.Windows.Forms.Label();
            this.PasswordPanel = new System.Windows.Forms.Panel();
            this.FirstnameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernamePanel = new System.Windows.Forms.Panel();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.FormTitle = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChangeUserButton
            // 
            this.ChangeUserButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ChangeUserButton.FlatAppearance.BorderSize = 0;
            this.ChangeUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeUserButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangeUserButton.ForeColor = System.Drawing.Color.White;
            this.ChangeUserButton.Location = new System.Drawing.Point(150, 447);
            this.ChangeUserButton.Name = "ChangeUserButton";
            this.ChangeUserButton.Size = new System.Drawing.Size(200, 40);
            this.ChangeUserButton.TabIndex = 80;
            this.ChangeUserButton.Text = "Изменить";
            this.ChangeUserButton.UseVisualStyleBackColor = false;
            this.ChangeUserButton.Click += new System.EventHandler(this.EditUserButton_Click);
            // 
            // BanStatusCheckBox
            // 
            this.BanStatusCheckBox.AutoSize = true;
            this.BanStatusCheckBox.BackColor = System.Drawing.Color.White;
            this.BanStatusCheckBox.FlatAppearance.BorderSize = 0;
            this.BanStatusCheckBox.Location = new System.Drawing.Point(211, 400);
            this.BanStatusCheckBox.Name = "BanStatusCheckBox";
            this.BanStatusCheckBox.Size = new System.Drawing.Size(18, 17);
            this.BanStatusCheckBox.TabIndex = 79;
            this.BanStatusCheckBox.UseVisualStyleBackColor = false;
            // 
            // BanStatusLabel
            // 
            this.BanStatusLabel.AutoSize = true;
            this.BanStatusLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BanStatusLabel.ForeColor = System.Drawing.Color.White;
            this.BanStatusLabel.Location = new System.Drawing.Point(35, 396);
            this.BanStatusLabel.Name = "BanStatusLabel";
            this.BanStatusLabel.Size = new System.Drawing.Size(117, 21);
            this.BanStatusLabel.TabIndex = 78;
            this.BanStatusLabel.Text = "Блокирован:";
            // 
            // SuperUserCheckBox
            // 
            this.SuperUserCheckBox.AutoSize = true;
            this.SuperUserCheckBox.BackColor = System.Drawing.Color.White;
            this.SuperUserCheckBox.FlatAppearance.BorderSize = 0;
            this.SuperUserCheckBox.Location = new System.Drawing.Point(211, 359);
            this.SuperUserCheckBox.Name = "SuperUserCheckBox";
            this.SuperUserCheckBox.Size = new System.Drawing.Size(18, 17);
            this.SuperUserCheckBox.TabIndex = 77;
            this.SuperUserCheckBox.UseVisualStyleBackColor = false;
            // 
            // SuperUserLabel
            // 
            this.SuperUserLabel.AutoSize = true;
            this.SuperUserLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SuperUserLabel.ForeColor = System.Drawing.Color.White;
            this.SuperUserLabel.Location = new System.Drawing.Point(35, 355);
            this.SuperUserLabel.Name = "SuperUserLabel";
            this.SuperUserLabel.Size = new System.Drawing.Size(155, 21);
            this.SuperUserLabel.TabIndex = 76;
            this.SuperUserLabel.Text = "Администратор:";
            // 
            // TelephonePanel
            // 
            this.TelephonePanel.BackColor = System.Drawing.Color.White;
            this.TelephonePanel.ForeColor = System.Drawing.Color.White;
            this.TelephonePanel.Location = new System.Drawing.Point(211, 334);
            this.TelephonePanel.Name = "TelephonePanel";
            this.TelephonePanel.Size = new System.Drawing.Size(254, 2);
            this.TelephonePanel.TabIndex = 75;
            // 
            // TelephoneLabel
            // 
            this.TelephoneLabel.AutoSize = true;
            this.TelephoneLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TelephoneLabel.ForeColor = System.Drawing.Color.White;
            this.TelephoneLabel.Location = new System.Drawing.Point(35, 314);
            this.TelephoneLabel.Name = "TelephoneLabel";
            this.TelephoneLabel.Size = new System.Drawing.Size(93, 21);
            this.TelephoneLabel.TabIndex = 74;
            this.TelephoneLabel.Text = "Телефон:";
            // 
            // TelephoneTextBox
            // 
            this.TelephoneTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.TelephoneTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TelephoneTextBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TelephoneTextBox.ForeColor = System.Drawing.Color.White;
            this.TelephoneTextBox.Location = new System.Drawing.Point(211, 314);
            this.TelephoneTextBox.Name = "TelephoneTextBox";
            this.TelephoneTextBox.Size = new System.Drawing.Size(254, 19);
            this.TelephoneTextBox.TabIndex = 73;
            // 
            // SurnamePanel
            // 
            this.SurnamePanel.BackColor = System.Drawing.Color.White;
            this.SurnamePanel.ForeColor = System.Drawing.Color.White;
            this.SurnamePanel.Location = new System.Drawing.Point(211, 292);
            this.SurnamePanel.Name = "SurnamePanel";
            this.SurnamePanel.Size = new System.Drawing.Size(254, 2);
            this.SurnamePanel.TabIndex = 72;
            // 
            // SurnameLabel
            // 
            this.SurnameLabel.AutoSize = true;
            this.SurnameLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SurnameLabel.ForeColor = System.Drawing.Color.White;
            this.SurnameLabel.Location = new System.Drawing.Point(35, 273);
            this.SurnameLabel.Name = "SurnameLabel";
            this.SurnameLabel.Size = new System.Drawing.Size(94, 21);
            this.SurnameLabel.TabIndex = 71;
            this.SurnameLabel.Text = "Фамилия:";
            // 
            // SurnameTextBox
            // 
            this.SurnameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.SurnameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SurnameTextBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SurnameTextBox.ForeColor = System.Drawing.Color.White;
            this.SurnameTextBox.Location = new System.Drawing.Point(211, 272);
            this.SurnameTextBox.Name = "SurnameTextBox";
            this.SurnameTextBox.Size = new System.Drawing.Size(254, 19);
            this.SurnameTextBox.TabIndex = 70;
            // 
            // FirstnamePanel
            // 
            this.FirstnamePanel.BackColor = System.Drawing.Color.White;
            this.FirstnamePanel.ForeColor = System.Drawing.Color.White;
            this.FirstnamePanel.Location = new System.Drawing.Point(211, 251);
            this.FirstnamePanel.Name = "FirstnamePanel";
            this.FirstnamePanel.Size = new System.Drawing.Size(254, 2);
            this.FirstnamePanel.TabIndex = 69;
            // 
            // FirstnameLabel
            // 
            this.FirstnameLabel.AutoSize = true;
            this.FirstnameLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstnameLabel.ForeColor = System.Drawing.Color.White;
            this.FirstnameLabel.Location = new System.Drawing.Point(35, 232);
            this.FirstnameLabel.Name = "FirstnameLabel";
            this.FirstnameLabel.Size = new System.Drawing.Size(51, 21);
            this.FirstnameLabel.TabIndex = 68;
            this.FirstnameLabel.Text = "Имя:";
            // 
            // PasswordPanel
            // 
            this.PasswordPanel.BackColor = System.Drawing.Color.White;
            this.PasswordPanel.ForeColor = System.Drawing.Color.White;
            this.PasswordPanel.Location = new System.Drawing.Point(211, 210);
            this.PasswordPanel.Name = "PasswordPanel";
            this.PasswordPanel.Size = new System.Drawing.Size(254, 2);
            this.PasswordPanel.TabIndex = 66;
            // 
            // FirstnameTextBox
            // 
            this.FirstnameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.FirstnameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FirstnameTextBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstnameTextBox.ForeColor = System.Drawing.Color.White;
            this.FirstnameTextBox.Location = new System.Drawing.Point(211, 232);
            this.FirstnameTextBox.Name = "FirstnameTextBox";
            this.FirstnameTextBox.Size = new System.Drawing.Size(254, 19);
            this.FirstnameTextBox.TabIndex = 67;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordLabel.ForeColor = System.Drawing.Color.White;
            this.PasswordLabel.Location = new System.Drawing.Point(35, 191);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(79, 21);
            this.PasswordLabel.TabIndex = 65;
            this.PasswordLabel.Text = "Пароль:";
            // 
            // UsernamePanel
            // 
            this.UsernamePanel.BackColor = System.Drawing.Color.White;
            this.UsernamePanel.ForeColor = System.Drawing.Color.White;
            this.UsernamePanel.Location = new System.Drawing.Point(211, 169);
            this.UsernamePanel.Name = "UsernamePanel";
            this.UsernamePanel.Size = new System.Drawing.Size(254, 2);
            this.UsernamePanel.TabIndex = 63;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordTextBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordTextBox.ForeColor = System.Drawing.Color.White;
            this.PasswordTextBox.Location = new System.Drawing.Point(211, 190);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(254, 19);
            this.PasswordTextBox.TabIndex = 64;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsernameLabel.ForeColor = System.Drawing.Color.White;
            this.UsernameLabel.Location = new System.Drawing.Point(35, 150);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(63, 21);
            this.UsernameLabel.TabIndex = 62;
            this.UsernameLabel.Text = "Логин:";
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UsernameTextBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsernameTextBox.ForeColor = System.Drawing.Color.White;
            this.UsernameTextBox.Location = new System.Drawing.Point(211, 149);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(254, 19);
            this.UsernameTextBox.TabIndex = 61;
            // 
            // FormTitle
            // 
            this.FormTitle.AutoSize = true;
            this.FormTitle.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormTitle.ForeColor = System.Drawing.Color.White;
            this.FormTitle.Location = new System.Drawing.Point(75, 30);
            this.FormTitle.Name = "FormTitle";
            this.FormTitle.Size = new System.Drawing.Size(350, 90);
            this.FormTitle.TabIndex = 59;
            this.FormTitle.Text = "Редактирование \r\nаккаунта";
            this.FormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExitButton
            // 
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Location = new System.Drawing.Point(468, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(32, 32);
            this.ExitButton.TabIndex = 60;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            // 
            // UserEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(500, 517);
            this.Controls.Add(this.ChangeUserButton);
            this.Controls.Add(this.BanStatusCheckBox);
            this.Controls.Add(this.BanStatusLabel);
            this.Controls.Add(this.SuperUserCheckBox);
            this.Controls.Add(this.SuperUserLabel);
            this.Controls.Add(this.TelephonePanel);
            this.Controls.Add(this.TelephoneLabel);
            this.Controls.Add(this.TelephoneTextBox);
            this.Controls.Add(this.SurnamePanel);
            this.Controls.Add(this.SurnameLabel);
            this.Controls.Add(this.SurnameTextBox);
            this.Controls.Add(this.FirstnamePanel);
            this.Controls.Add(this.FirstnameLabel);
            this.Controls.Add(this.PasswordPanel);
            this.Controls.Add(this.FirstnameTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernamePanel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.FormTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ChangeUserButton;
        private System.Windows.Forms.CheckBox BanStatusCheckBox;
        private System.Windows.Forms.Label BanStatusLabel;
        private System.Windows.Forms.CheckBox SuperUserCheckBox;
        private System.Windows.Forms.Label SuperUserLabel;
        private System.Windows.Forms.Panel TelephonePanel;
        private System.Windows.Forms.Label TelephoneLabel;
        private System.Windows.Forms.TextBox TelephoneTextBox;
        private System.Windows.Forms.Panel SurnamePanel;
        private System.Windows.Forms.Label SurnameLabel;
        private System.Windows.Forms.TextBox SurnameTextBox;
        private System.Windows.Forms.Panel FirstnamePanel;
        private System.Windows.Forms.Label FirstnameLabel;
        private System.Windows.Forms.Panel PasswordPanel;
        private System.Windows.Forms.TextBox FirstnameTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Panel UsernamePanel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label FormTitle;
    }
}