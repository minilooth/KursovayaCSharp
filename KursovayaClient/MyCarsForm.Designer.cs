namespace KursovayaCSharp
{
    partial class MyCarsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyCarsForm));
            this.CarsPanel = new System.Windows.Forms.Panel();
            this.CarsTable = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YearOfIssue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BodyType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EngineVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EngineType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransmissionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WheelDriveType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mileage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BodyColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InteriorMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InteriorColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExitButton = new System.Windows.Forms.Button();
            this.MyCarsLabel = new System.Windows.Forms.Label();
            this.CarsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CarsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // CarsPanel
            // 
            this.CarsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.CarsPanel.Controls.Add(this.MyCarsLabel);
            this.CarsPanel.Controls.Add(this.ExitButton);
            this.CarsPanel.Controls.Add(this.CarsTable);
            this.CarsPanel.Location = new System.Drawing.Point(0, 0);
            this.CarsPanel.Name = "CarsPanel";
            this.CarsPanel.Size = new System.Drawing.Size(1622, 788);
            this.CarsPanel.TabIndex = 20;
            // 
            // CarsTable
            // 
            this.CarsTable.AllowUserToAddRows = false;
            this.CarsTable.AllowUserToDeleteRows = false;
            this.CarsTable.AllowUserToResizeRows = false;
            this.CarsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CarsTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CarsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CarsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Brand,
            this.Model,
            this.YearOfIssue,
            this.BodyType,
            this.EngineVolume,
            this.EngineType,
            this.TransmissionType,
            this.WheelDriveType,
            this.Mileage,
            this.BodyColor,
            this.InteriorMaterial,
            this.InteriorColor});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CarsTable.DefaultCellStyle = dataGridViewCellStyle1;
            this.CarsTable.Location = new System.Drawing.Point(0, 100);
            this.CarsTable.MultiSelect = false;
            this.CarsTable.Name = "CarsTable";
            this.CarsTable.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CarsTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.CarsTable.RowHeadersVisible = false;
            this.CarsTable.RowHeadersWidth = 51;
            this.CarsTable.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CarsTable.RowTemplate.Height = 24;
            this.CarsTable.Size = new System.Drawing.Size(1622, 688);
            this.CarsTable.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id.FillWeight = 35F;
            this.Id.HeaderText = "Ид";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Brand
            // 
            this.Brand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Brand.FillWeight = 70F;
            this.Brand.HeaderText = "Марка";
            this.Brand.MinimumWidth = 6;
            this.Brand.Name = "Brand";
            this.Brand.ReadOnly = true;
            this.Brand.Width = 79;
            // 
            // Model
            // 
            this.Model.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Model.HeaderText = "Модель";
            this.Model.MinimumWidth = 6;
            this.Model.Name = "Model";
            this.Model.ReadOnly = true;
            // 
            // YearOfIssue
            // 
            this.YearOfIssue.HeaderText = "Год выпуска";
            this.YearOfIssue.MinimumWidth = 6;
            this.YearOfIssue.Name = "YearOfIssue";
            this.YearOfIssue.ReadOnly = true;
            // 
            // BodyType
            // 
            this.BodyType.HeaderText = "Тип кузова";
            this.BodyType.MinimumWidth = 6;
            this.BodyType.Name = "BodyType";
            this.BodyType.ReadOnly = true;
            // 
            // EngineVolume
            // 
            this.EngineVolume.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EngineVolume.FillWeight = 70F;
            this.EngineVolume.HeaderText = "Объем двигателя";
            this.EngineVolume.MinimumWidth = 6;
            this.EngineVolume.Name = "EngineVolume";
            this.EngineVolume.ReadOnly = true;
            // 
            // EngineType
            // 
            this.EngineType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.EngineType.HeaderText = "Тип двигателя";
            this.EngineType.MinimumWidth = 6;
            this.EngineType.Name = "EngineType";
            this.EngineType.ReadOnly = true;
            this.EngineType.Width = 122;
            // 
            // TransmissionType
            // 
            this.TransmissionType.HeaderText = "Тип КПП";
            this.TransmissionType.MinimumWidth = 6;
            this.TransmissionType.Name = "TransmissionType";
            this.TransmissionType.ReadOnly = true;
            // 
            // WheelDriveType
            // 
            this.WheelDriveType.HeaderText = "Тип привода";
            this.WheelDriveType.MinimumWidth = 6;
            this.WheelDriveType.Name = "WheelDriveType";
            this.WheelDriveType.ReadOnly = true;
            // 
            // Mileage
            // 
            this.Mileage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Mileage.HeaderText = "Пробег";
            this.Mileage.MinimumWidth = 6;
            this.Mileage.Name = "Mileage";
            this.Mileage.ReadOnly = true;
            this.Mileage.Width = 84;
            // 
            // BodyColor
            // 
            this.BodyColor.FillWeight = 70F;
            this.BodyColor.HeaderText = "Цвет кузова";
            this.BodyColor.MinimumWidth = 6;
            this.BodyColor.Name = "BodyColor";
            this.BodyColor.ReadOnly = true;
            // 
            // InteriorMaterial
            // 
            this.InteriorMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InteriorMaterial.FillWeight = 70F;
            this.InteriorMaterial.HeaderText = "Материал салона";
            this.InteriorMaterial.MinimumWidth = 6;
            this.InteriorMaterial.Name = "InteriorMaterial";
            this.InteriorMaterial.ReadOnly = true;
            // 
            // InteriorColor
            // 
            this.InteriorColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InteriorColor.FillWeight = 70F;
            this.InteriorColor.HeaderText = "Цвет салона";
            this.InteriorColor.MinimumWidth = 6;
            this.InteriorColor.Name = "InteriorColor";
            this.InteriorColor.ReadOnly = true;
            // 
            // ExitButton
            // 
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Location = new System.Drawing.Point(1590, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(32, 32);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            // 
            // MyCarsLabel
            // 
            this.MyCarsLabel.AutoSize = true;
            this.MyCarsLabel.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MyCarsLabel.ForeColor = System.Drawing.Color.White;
            this.MyCarsLabel.Location = new System.Drawing.Point(627, 26);
            this.MyCarsLabel.Name = "MyCarsLabel";
            this.MyCarsLabel.Size = new System.Drawing.Size(368, 49);
            this.MyCarsLabel.TabIndex = 7;
            this.MyCarsLabel.Text = "Мои автомобили";
            // 
            // MyCarsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1622, 788);
            this.Controls.Add(this.CarsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MyCarsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyCarsForm";
            this.CarsPanel.ResumeLayout(false);
            this.CarsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CarsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CarsPanel;
        private System.Windows.Forms.DataGridView CarsTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn YearOfIssue;
        private System.Windows.Forms.DataGridViewTextBoxColumn BodyType;
        private System.Windows.Forms.DataGridViewTextBoxColumn EngineVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn EngineType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransmissionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn WheelDriveType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mileage;
        private System.Windows.Forms.DataGridViewTextBoxColumn BodyColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn InteriorMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn InteriorColor;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label MyCarsLabel;
    }
}