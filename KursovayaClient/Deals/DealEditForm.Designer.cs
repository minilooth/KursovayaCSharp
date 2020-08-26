namespace KursovayaCSharp
{
    partial class DealEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DealEditForm));
            this.CarIdPanel = new System.Windows.Forms.Panel();
            this.CarIdUpDown = new System.Windows.Forms.NumericUpDown();
            this.AddDealButton = new System.Windows.Forms.Button();
            this.CarIdLabel = new System.Windows.Forms.Label();
            this.UsernamePanel = new System.Windows.Forms.Panel();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.FormTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CarIdUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // CarIdPanel
            // 
            this.CarIdPanel.BackColor = System.Drawing.Color.White;
            this.CarIdPanel.ForeColor = System.Drawing.Color.White;
            this.CarIdPanel.Location = new System.Drawing.Point(211, 215);
            this.CarIdPanel.Name = "CarIdPanel";
            this.CarIdPanel.Size = new System.Drawing.Size(254, 2);
            this.CarIdPanel.TabIndex = 93;
            // 
            // CarIdUpDown
            // 
            this.CarIdUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.CarIdUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CarIdUpDown.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CarIdUpDown.ForeColor = System.Drawing.Color.White;
            this.CarIdUpDown.Location = new System.Drawing.Point(211, 195);
            this.CarIdUpDown.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.CarIdUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CarIdUpDown.Name = "CarIdUpDown";
            this.CarIdUpDown.Size = new System.Drawing.Size(254, 22);
            this.CarIdUpDown.TabIndex = 92;
            this.CarIdUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AddDealButton
            // 
            this.AddDealButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.AddDealButton.FlatAppearance.BorderSize = 0;
            this.AddDealButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddDealButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddDealButton.ForeColor = System.Drawing.Color.White;
            this.AddDealButton.Location = new System.Drawing.Point(150, 247);
            this.AddDealButton.Name = "AddDealButton";
            this.AddDealButton.Size = new System.Drawing.Size(200, 40);
            this.AddDealButton.TabIndex = 90;
            this.AddDealButton.Text = "Изменить";
            this.AddDealButton.UseVisualStyleBackColor = false;
            this.AddDealButton.Click += new System.EventHandler(this.AddDealButton_Click);
            // 
            // CarIdLabel
            // 
            this.CarIdLabel.AutoSize = true;
            this.CarIdLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CarIdLabel.ForeColor = System.Drawing.Color.White;
            this.CarIdLabel.Location = new System.Drawing.Point(35, 196);
            this.CarIdLabel.Name = "CarIdLabel";
            this.CarIdLabel.Size = new System.Drawing.Size(145, 21);
            this.CarIdLabel.TabIndex = 89;
            this.CarIdLabel.Text = "Ид автомобиля:";
            // 
            // UsernamePanel
            // 
            this.UsernamePanel.BackColor = System.Drawing.Color.White;
            this.UsernamePanel.ForeColor = System.Drawing.Color.White;
            this.UsernamePanel.Location = new System.Drawing.Point(211, 174);
            this.UsernamePanel.Name = "UsernamePanel";
            this.UsernamePanel.Size = new System.Drawing.Size(254, 2);
            this.UsernamePanel.TabIndex = 88;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsernameLabel.ForeColor = System.Drawing.Color.White;
            this.UsernameLabel.Location = new System.Drawing.Point(35, 155);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(63, 21);
            this.UsernameLabel.TabIndex = 87;
            this.UsernameLabel.Text = "Логин:";
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UsernameTextBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsernameTextBox.ForeColor = System.Drawing.Color.White;
            this.UsernameTextBox.Location = new System.Drawing.Point(211, 154);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(254, 19);
            this.UsernameTextBox.TabIndex = 86;
            // 
            // ExitButton
            // 
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Location = new System.Drawing.Point(468, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(32, 32);
            this.ExitButton.TabIndex = 85;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            // 
            // FormTitle
            // 
            this.FormTitle.AutoSize = true;
            this.FormTitle.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormTitle.ForeColor = System.Drawing.Color.White;
            this.FormTitle.Location = new System.Drawing.Point(75, 30);
            this.FormTitle.Name = "FormTitle";
            this.FormTitle.Size = new System.Drawing.Size(350, 90);
            this.FormTitle.TabIndex = 84;
            this.FormTitle.Text = "Редактирование \r\nсделки";
            this.FormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DealEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(500, 317);
            this.Controls.Add(this.CarIdPanel);
            this.Controls.Add(this.CarIdUpDown);
            this.Controls.Add(this.AddDealButton);
            this.Controls.Add(this.CarIdLabel);
            this.Controls.Add(this.UsernamePanel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.FormTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DealEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DealEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.CarIdUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel CarIdPanel;
        private System.Windows.Forms.NumericUpDown CarIdUpDown;
        private System.Windows.Forms.Button AddDealButton;
        private System.Windows.Forms.Label CarIdLabel;
        private System.Windows.Forms.Panel UsernamePanel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label FormTitle;
    }
}