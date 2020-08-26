namespace KursovayaCSharp
{
    partial class AutodealerChooseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutodealerChooseForm));
            this.SelectButton = new System.Windows.Forms.Button();
            this.ChooseAutodealerLabel = new System.Windows.Forms.Label();
            this.ChooseAutodealerLabelPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.AutodealersListBox = new System.Windows.Forms.ListBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectButton
            // 
            this.SelectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.SelectButton.FlatAppearance.BorderSize = 0;
            this.SelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectButton.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectButton.ForeColor = System.Drawing.Color.White;
            this.SelectButton.Location = new System.Drawing.Point(50, 423);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(800, 52);
            this.SelectButton.TabIndex = 1;
            this.SelectButton.Text = "Выбрать";
            this.SelectButton.UseVisualStyleBackColor = false;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // ChooseAutodealerLabel
            // 
            this.ChooseAutodealerLabel.AutoSize = true;
            this.ChooseAutodealerLabel.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChooseAutodealerLabel.ForeColor = System.Drawing.Color.White;
            this.ChooseAutodealerLabel.Location = new System.Drawing.Point(42, 9);
            this.ChooseAutodealerLabel.Name = "ChooseAutodealerLabel";
            this.ChooseAutodealerLabel.Size = new System.Drawing.Size(421, 45);
            this.ChooseAutodealerLabel.TabIndex = 2;
            this.ChooseAutodealerLabel.Text = "Выберите автосалон";
            // 
            // ChooseAutodealerLabelPanel
            // 
            this.ChooseAutodealerLabelPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ChooseAutodealerLabelPanel.Location = new System.Drawing.Point(50, 51);
            this.ChooseAutodealerLabelPanel.Name = "ChooseAutodealerLabelPanel";
            this.ChooseAutodealerLabelPanel.Size = new System.Drawing.Size(400, 3);
            this.ChooseAutodealerLabelPanel.TabIndex = 3;
            // 
            // AutodealersListBox
            // 
            this.AutodealersListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AutodealersListBox.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AutodealersListBox.FormattingEnabled = true;
            this.AutodealersListBox.ItemHeight = 27;
            this.AutodealersListBox.Location = new System.Drawing.Point(50, 100);
            this.AutodealersListBox.Name = "AutodealersListBox";
            this.AutodealersListBox.Size = new System.Drawing.Size(800, 297);
            this.AutodealersListBox.TabIndex = 5;
            this.AutodealersListBox.SelectedIndexChanged += new System.EventHandler(this.AutodealersListBox_SelectedIndexChanged);
            // 
            // RefreshButton
            // 
            this.RefreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.RefreshButton.FlatAppearance.BorderSize = 0;
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RefreshButton.ForeColor = System.Drawing.Color.White;
            this.RefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshButton.Image")));
            this.RefreshButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RefreshButton.Location = new System.Drawing.Point(726, 51);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(124, 40);
            this.RefreshButton.TabIndex = 7;
            this.RefreshButton.Text = "Обновить";
            this.RefreshButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RefreshButton.UseVisualStyleBackColor = false;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Location = new System.Drawing.Point(868, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(32, 32);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            // 
            // AutodealerChooseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.AutodealersListBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ChooseAutodealerLabelPanel);
            this.Controls.Add(this.ChooseAutodealerLabel);
            this.Controls.Add(this.SelectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutodealerChooseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutodealerChooseForm";
            this.Load += new System.EventHandler(this.AutodealerChooseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Label ChooseAutodealerLabel;
        private System.Windows.Forms.FlowLayoutPanel ChooseAutodealerLabelPanel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.ListBox AutodealersListBox;
        private System.Windows.Forms.Button RefreshButton;
    }
}