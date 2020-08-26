namespace KursovayaCSharp
{
    partial class EditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            this.ExitButton = new System.Windows.Forms.Button();
            this.TextBoxPanel = new System.Windows.Forms.Panel();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.ChangeLabel = new System.Windows.Forms.Label();
            this.WhatChangeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Location = new System.Drawing.Point(347, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(32, 32);
            this.ExitButton.TabIndex = 83;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            // 
            // TextBoxPanel
            // 
            this.TextBoxPanel.BackColor = System.Drawing.Color.White;
            this.TextBoxPanel.ForeColor = System.Drawing.Color.White;
            this.TextBoxPanel.Location = new System.Drawing.Point(12, 159);
            this.TextBoxPanel.Name = "TextBoxPanel";
            this.TextBoxPanel.Size = new System.Drawing.Size(200, 2);
            this.TextBoxPanel.TabIndex = 87;
            // 
            // TextBox
            // 
            this.TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBox.ForeColor = System.Drawing.Color.White;
            this.TextBox.Location = new System.Drawing.Point(12, 139);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(200, 19);
            this.TextBox.TabIndex = 86;
            // 
            // OkButton
            // 
            this.OkButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.OkButton.FlatAppearance.BorderSize = 0;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OkButton.ForeColor = System.Drawing.Color.White;
            this.OkButton.Location = new System.Drawing.Point(228, 139);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(139, 23);
            this.OkButton.TabIndex = 88;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // ChangeLabel
            // 
            this.ChangeLabel.AutoSize = true;
            this.ChangeLabel.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangeLabel.ForeColor = System.Drawing.Color.White;
            this.ChangeLabel.Location = new System.Drawing.Point(94, 30);
            this.ChangeLabel.Name = "ChangeLabel";
            this.ChangeLabel.Size = new System.Drawing.Size(207, 40);
            this.ChangeLabel.TabIndex = 89;
            this.ChangeLabel.Text = "Изменение";
            // 
            // WhatChangeLabel
            // 
            this.WhatChangeLabel.AutoSize = true;
            this.WhatChangeLabel.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WhatChangeLabel.ForeColor = System.Drawing.Color.White;
            this.WhatChangeLabel.Location = new System.Drawing.Point(94, 70);
            this.WhatChangeLabel.Name = "WhatChangeLabel";
            this.WhatChangeLabel.Size = new System.Drawing.Size(207, 40);
            this.WhatChangeLabel.TabIndex = 90;
            this.WhatChangeLabel.Text = "Изменение";
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(379, 191);
            this.Controls.Add(this.WhatChangeLabel);
            this.Controls.Add(this.ChangeLabel);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.TextBoxPanel);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.ExitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Panel TextBoxPanel;
        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label ChangeLabel;
        private System.Windows.Forms.Label WhatChangeLabel;
    }
}