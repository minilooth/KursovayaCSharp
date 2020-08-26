namespace KursovayaCSharp
{
    partial class AutodealerEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutodealerEditForm));
            this.TimeTo = new System.Windows.Forms.DateTimePicker();
            this.TimeFrom = new System.Windows.Forms.DateTimePicker();
            this.AddAutodealerButton = new System.Windows.Forms.Button();
            this.AddressPanel = new System.Windows.Forms.Panel();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.CityPanel = new System.Windows.Forms.Panel();
            this.CityLabel = new System.Windows.Forms.Label();
            this.CityTextBox = new System.Windows.Forms.TextBox();
            this.WorkingHoursLabel = new System.Windows.Forms.Label();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.FormTitle = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TimeTo
            // 
            this.TimeTo.CustomFormat = "HH:mm";
            this.TimeTo.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimeTo.Location = new System.Drawing.Point(365, 191);
            this.TimeTo.Name = "TimeTo";
            this.TimeTo.ShowUpDown = true;
            this.TimeTo.Size = new System.Drawing.Size(100, 23);
            this.TimeTo.TabIndex = 101;
            // 
            // TimeFrom
            // 
            this.TimeFrom.CalendarForeColor = System.Drawing.Color.White;
            this.TimeFrom.CalendarMonthBackground = System.Drawing.Color.White;
            this.TimeFrom.CalendarTitleBackColor = System.Drawing.Color.White;
            this.TimeFrom.CalendarTitleForeColor = System.Drawing.Color.AliceBlue;
            this.TimeFrom.CustomFormat = "HH:mm";
            this.TimeFrom.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimeFrom.Location = new System.Drawing.Point(211, 190);
            this.TimeFrom.Name = "TimeFrom";
            this.TimeFrom.ShowUpDown = true;
            this.TimeFrom.Size = new System.Drawing.Size(100, 23);
            this.TimeFrom.TabIndex = 100;
            // 
            // AddAutodealerButton
            // 
            this.AddAutodealerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.AddAutodealerButton.FlatAppearance.BorderSize = 0;
            this.AddAutodealerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddAutodealerButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddAutodealerButton.ForeColor = System.Drawing.Color.White;
            this.AddAutodealerButton.Location = new System.Drawing.Point(150, 324);
            this.AddAutodealerButton.Name = "AddAutodealerButton";
            this.AddAutodealerButton.Size = new System.Drawing.Size(200, 40);
            this.AddAutodealerButton.TabIndex = 98;
            this.AddAutodealerButton.Text = "Изменить";
            this.AddAutodealerButton.UseVisualStyleBackColor = false;
            this.AddAutodealerButton.Click += new System.EventHandler(this.AddAutodealerButton_Click);
            // 
            // AddressPanel
            // 
            this.AddressPanel.BackColor = System.Drawing.Color.White;
            this.AddressPanel.ForeColor = System.Drawing.Color.White;
            this.AddressPanel.Location = new System.Drawing.Point(211, 292);
            this.AddressPanel.Name = "AddressPanel";
            this.AddressPanel.Size = new System.Drawing.Size(254, 2);
            this.AddressPanel.TabIndex = 97;
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddressLabel.ForeColor = System.Drawing.Color.White;
            this.AddressLabel.Location = new System.Drawing.Point(35, 273);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(72, 21);
            this.AddressLabel.TabIndex = 96;
            this.AddressLabel.Text = "Адрес:";
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.AddressTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AddressTextBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddressTextBox.ForeColor = System.Drawing.Color.White;
            this.AddressTextBox.Location = new System.Drawing.Point(211, 272);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(254, 19);
            this.AddressTextBox.TabIndex = 95;
            // 
            // CityPanel
            // 
            this.CityPanel.BackColor = System.Drawing.Color.White;
            this.CityPanel.ForeColor = System.Drawing.Color.White;
            this.CityPanel.Location = new System.Drawing.Point(211, 251);
            this.CityPanel.Name = "CityPanel";
            this.CityPanel.Size = new System.Drawing.Size(254, 2);
            this.CityPanel.TabIndex = 94;
            // 
            // CityLabel
            // 
            this.CityLabel.AutoSize = true;
            this.CityLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CityLabel.ForeColor = System.Drawing.Color.White;
            this.CityLabel.Location = new System.Drawing.Point(35, 232);
            this.CityLabel.Name = "CityLabel";
            this.CityLabel.Size = new System.Drawing.Size(67, 21);
            this.CityLabel.TabIndex = 93;
            this.CityLabel.Text = "Город:";
            // 
            // CityTextBox
            // 
            this.CityTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.CityTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CityTextBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CityTextBox.ForeColor = System.Drawing.Color.White;
            this.CityTextBox.Location = new System.Drawing.Point(211, 232);
            this.CityTextBox.Name = "CityTextBox";
            this.CityTextBox.Size = new System.Drawing.Size(254, 19);
            this.CityTextBox.TabIndex = 92;
            // 
            // WorkingHoursLabel
            // 
            this.WorkingHoursLabel.AutoSize = true;
            this.WorkingHoursLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WorkingHoursLabel.ForeColor = System.Drawing.Color.White;
            this.WorkingHoursLabel.Location = new System.Drawing.Point(35, 191);
            this.WorkingHoursLabel.Name = "WorkingHoursLabel";
            this.WorkingHoursLabel.Size = new System.Drawing.Size(140, 21);
            this.WorkingHoursLabel.TabIndex = 91;
            this.WorkingHoursLabel.Text = "Время работы:";
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.White;
            this.TitlePanel.ForeColor = System.Drawing.Color.White;
            this.TitlePanel.Location = new System.Drawing.Point(211, 169);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(254, 2);
            this.TitlePanel.TabIndex = 90;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TitleLabel.ForeColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(35, 150);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(97, 21);
            this.TitleLabel.TabIndex = 89;
            this.TitleLabel.Text = "Название:";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.TitleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TitleTextBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TitleTextBox.ForeColor = System.Drawing.Color.White;
            this.TitleTextBox.Location = new System.Drawing.Point(211, 149);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(254, 19);
            this.TitleTextBox.TabIndex = 88;
            // 
            // FormTitle
            // 
            this.FormTitle.AutoSize = true;
            this.FormTitle.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormTitle.ForeColor = System.Drawing.Color.White;
            this.FormTitle.Location = new System.Drawing.Point(81, 30);
            this.FormTitle.Name = "FormTitle";
            this.FormTitle.Size = new System.Drawing.Size(339, 90);
            this.FormTitle.TabIndex = 86;
            this.FormTitle.Text = "Редактирование\r\nавтосалона";
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
            this.ExitButton.TabIndex = 87;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            // 
            // AutodealerEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(500, 394);
            this.Controls.Add(this.TimeTo);
            this.Controls.Add(this.TimeFrom);
            this.Controls.Add(this.AddAutodealerButton);
            this.Controls.Add(this.AddressPanel);
            this.Controls.Add(this.AddressLabel);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.CityPanel);
            this.Controls.Add(this.CityLabel);
            this.Controls.Add(this.CityTextBox);
            this.Controls.Add(this.WorkingHoursLabel);
            this.Controls.Add(this.TitlePanel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.FormTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutodealerEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutodealerEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker TimeTo;
        private System.Windows.Forms.DateTimePicker TimeFrom;
        private System.Windows.Forms.Button AddAutodealerButton;
        private System.Windows.Forms.Panel AddressPanel;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Panel CityPanel;
        private System.Windows.Forms.Label CityLabel;
        private System.Windows.Forms.TextBox CityTextBox;
        private System.Windows.Forms.Label WorkingHoursLabel;
        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label FormTitle;
    }
}