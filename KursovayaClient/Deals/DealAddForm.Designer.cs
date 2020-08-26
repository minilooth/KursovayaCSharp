namespace KursovayaCSharp
{
    partial class DealAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DealAddForm));
            this.ClearButton = new System.Windows.Forms.Button();
            this.AddDealButton = new System.Windows.Forms.Button();
            this.CarIdLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.FormTitle = new System.Windows.Forms.Label();
            this.UsernameComboBox = new System.Windows.Forms.ComboBox();
            this.CarComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ClearButton.FlatAppearance.BorderSize = 0;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearButton.ForeColor = System.Drawing.Color.White;
            this.ClearButton.Location = new System.Drawing.Point(262, 197);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(203, 40);
            this.ClearButton.TabIndex = 81;
            this.ClearButton.Text = "Очистить";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // AddDealButton
            // 
            this.AddDealButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.AddDealButton.FlatAppearance.BorderSize = 0;
            this.AddDealButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddDealButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddDealButton.ForeColor = System.Drawing.Color.White;
            this.AddDealButton.Location = new System.Drawing.Point(39, 197);
            this.AddDealButton.Name = "AddDealButton";
            this.AddDealButton.Size = new System.Drawing.Size(203, 40);
            this.AddDealButton.TabIndex = 80;
            this.AddDealButton.Text = "Добавить";
            this.AddDealButton.UseVisualStyleBackColor = false;
            this.AddDealButton.Click += new System.EventHandler(this.AddDealButton_Click);
            // 
            // CarIdLabel
            // 
            this.CarIdLabel.AutoSize = true;
            this.CarIdLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CarIdLabel.ForeColor = System.Drawing.Color.White;
            this.CarIdLabel.Location = new System.Drawing.Point(35, 146);
            this.CarIdLabel.Name = "CarIdLabel";
            this.CarIdLabel.Size = new System.Drawing.Size(145, 21);
            this.CarIdLabel.TabIndex = 65;
            this.CarIdLabel.Text = "Ид автомобиля:";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsernameLabel.ForeColor = System.Drawing.Color.White;
            this.UsernameLabel.Location = new System.Drawing.Point(35, 105);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(63, 21);
            this.UsernameLabel.TabIndex = 62;
            this.UsernameLabel.Text = "Логин:";
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
            // FormTitle
            // 
            this.FormTitle.AutoSize = true;
            this.FormTitle.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormTitle.ForeColor = System.Drawing.Color.White;
            this.FormTitle.Location = new System.Drawing.Point(109, 30);
            this.FormTitle.Name = "FormTitle";
            this.FormTitle.Size = new System.Drawing.Size(282, 45);
            this.FormTitle.TabIndex = 59;
            this.FormTitle.Text = "Новая сделка";
            // 
            // UsernameComboBox
            // 
            this.UsernameComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.UsernameComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UsernameComboBox.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsernameComboBox.ForeColor = System.Drawing.Color.White;
            this.UsernameComboBox.FormattingEnabled = true;
            this.UsernameComboBox.Location = new System.Drawing.Point(211, 101);
            this.UsernameComboBox.Name = "UsernameComboBox";
            this.UsernameComboBox.Size = new System.Drawing.Size(254, 25);
            this.UsernameComboBox.TabIndex = 84;
            // 
            // CarComboBox
            // 
            this.CarComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.CarComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CarComboBox.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CarComboBox.ForeColor = System.Drawing.Color.White;
            this.CarComboBox.FormattingEnabled = true;
            this.CarComboBox.Location = new System.Drawing.Point(211, 142);
            this.CarComboBox.Name = "CarComboBox";
            this.CarComboBox.Size = new System.Drawing.Size(254, 25);
            this.CarComboBox.TabIndex = 85;
            // 
            // DealAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(500, 272);
            this.Controls.Add(this.CarComboBox);
            this.Controls.Add(this.UsernameComboBox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.AddDealButton);
            this.Controls.Add(this.CarIdLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.FormTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DealAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DealAddForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button AddDealButton;
        private System.Windows.Forms.Label CarIdLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label FormTitle;
        private System.Windows.Forms.ComboBox UsernameComboBox;
        private System.Windows.Forms.ComboBox CarComboBox;
    }
}