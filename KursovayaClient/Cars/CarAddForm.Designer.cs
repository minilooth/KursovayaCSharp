namespace KursovayaCSharp
{
    partial class CarAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarAddForm));
            this.BrandTextBox = new System.Windows.Forms.TextBox();
            this.BrandLabel = new System.Windows.Forms.Label();
            this.ModelLabel = new System.Windows.Forms.Label();
            this.ModelTextBox = new System.Windows.Forms.TextBox();
            this.YearOfIssueLabel = new System.Windows.Forms.Label();
            this.YearOfIssueUpDown = new System.Windows.Forms.NumericUpDown();
            this.BodyTypeLabel = new System.Windows.Forms.Label();
            this.BodyTypeComboBox = new System.Windows.Forms.ComboBox();
            this.EngineVolumeLabel = new System.Windows.Forms.Label();
            this.EngineTypeComboBox = new System.Windows.Forms.ComboBox();
            this.EngineTypeLabel = new System.Windows.Forms.Label();
            this.EngineVolumeUpDown = new System.Windows.Forms.NumericUpDown();
            this.TransmissionTypeComboBox = new System.Windows.Forms.ComboBox();
            this.TransmissionTypeLabel = new System.Windows.Forms.Label();
            this.WheelDriveTypeComboBox = new System.Windows.Forms.ComboBox();
            this.WheelDriveTypeLabel = new System.Windows.Forms.Label();
            this.MileageUpDown = new System.Windows.Forms.NumericUpDown();
            this.MileageLabel = new System.Windows.Forms.Label();
            this.BodyColorComboBox = new System.Windows.Forms.ComboBox();
            this.BodyColorLabel = new System.Windows.Forms.Label();
            this.InteriorColorComboBox = new System.Windows.Forms.ComboBox();
            this.InteriorColorLabel = new System.Windows.Forms.Label();
            this.InteriorMaterialComboBox = new System.Windows.Forms.ComboBox();
            this.InteriorMaterialLabel = new System.Windows.Forms.Label();
            this.PriceUpDown = new System.Windows.Forms.NumericUpDown();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.AddCarButton = new System.Windows.Forms.Button();
            this.FormTitle = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.YearOfIssuePanel = new System.Windows.Forms.Panel();
            this.BrandPanel = new System.Windows.Forms.Panel();
            this.ModelPanel = new System.Windows.Forms.Panel();
            this.EngineVolumePanel = new System.Windows.Forms.Panel();
            this.MileagePanel = new System.Windows.Forms.Panel();
            this.PricePanel = new System.Windows.Forms.Panel();
            this.ExitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.YearOfIssueUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EngineVolumeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MileageUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // BrandTextBox
            // 
            this.BrandTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.BrandTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BrandTextBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BrandTextBox.ForeColor = System.Drawing.Color.White;
            this.BrandTextBox.Location = new System.Drawing.Point(204, 115);
            this.BrandTextBox.Name = "BrandTextBox";
            this.BrandTextBox.Size = new System.Drawing.Size(254, 19);
            this.BrandTextBox.TabIndex = 0;
            // 
            // BrandLabel
            // 
            this.BrandLabel.AutoSize = true;
            this.BrandLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BrandLabel.ForeColor = System.Drawing.Color.White;
            this.BrandLabel.Location = new System.Drawing.Point(27, 116);
            this.BrandLabel.Name = "BrandLabel";
            this.BrandLabel.Size = new System.Drawing.Size(77, 21);
            this.BrandLabel.TabIndex = 1;
            this.BrandLabel.Text = "Марка:";
            // 
            // ModelLabel
            // 
            this.ModelLabel.AutoSize = true;
            this.ModelLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ModelLabel.ForeColor = System.Drawing.Color.White;
            this.ModelLabel.Location = new System.Drawing.Point(27, 159);
            this.ModelLabel.Name = "ModelLabel";
            this.ModelLabel.Size = new System.Drawing.Size(81, 21);
            this.ModelLabel.TabIndex = 3;
            this.ModelLabel.Text = "Модель:";
            // 
            // ModelTextBox
            // 
            this.ModelTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.ModelTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ModelTextBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ModelTextBox.ForeColor = System.Drawing.Color.White;
            this.ModelTextBox.Location = new System.Drawing.Point(204, 158);
            this.ModelTextBox.Name = "ModelTextBox";
            this.ModelTextBox.Size = new System.Drawing.Size(254, 19);
            this.ModelTextBox.TabIndex = 2;
            // 
            // YearOfIssueLabel
            // 
            this.YearOfIssueLabel.AutoSize = true;
            this.YearOfIssueLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YearOfIssueLabel.ForeColor = System.Drawing.Color.White;
            this.YearOfIssueLabel.Location = new System.Drawing.Point(27, 202);
            this.YearOfIssueLabel.Name = "YearOfIssueLabel";
            this.YearOfIssueLabel.Size = new System.Drawing.Size(118, 21);
            this.YearOfIssueLabel.TabIndex = 5;
            this.YearOfIssueLabel.Text = "Год выпуска:";
            // 
            // YearOfIssueUpDown
            // 
            this.YearOfIssueUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.YearOfIssueUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.YearOfIssueUpDown.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YearOfIssueUpDown.ForeColor = System.Drawing.Color.White;
            this.YearOfIssueUpDown.Location = new System.Drawing.Point(204, 201);
            this.YearOfIssueUpDown.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.YearOfIssueUpDown.Minimum = new decimal(new int[] {
            1975,
            0,
            0,
            0});
            this.YearOfIssueUpDown.Name = "YearOfIssueUpDown";
            this.YearOfIssueUpDown.Size = new System.Drawing.Size(254, 22);
            this.YearOfIssueUpDown.TabIndex = 6;
            this.YearOfIssueUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // BodyTypeLabel
            // 
            this.BodyTypeLabel.AutoSize = true;
            this.BodyTypeLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BodyTypeLabel.ForeColor = System.Drawing.Color.White;
            this.BodyTypeLabel.Location = new System.Drawing.Point(27, 247);
            this.BodyTypeLabel.Name = "BodyTypeLabel";
            this.BodyTypeLabel.Size = new System.Drawing.Size(103, 21);
            this.BodyTypeLabel.TabIndex = 8;
            this.BodyTypeLabel.Text = "Тип кузова:";
            // 
            // BodyTypeComboBox
            // 
            this.BodyTypeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.BodyTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BodyTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BodyTypeComboBox.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BodyTypeComboBox.ForeColor = System.Drawing.Color.White;
            this.BodyTypeComboBox.FormattingEnabled = true;
            this.BodyTypeComboBox.Location = new System.Drawing.Point(204, 244);
            this.BodyTypeComboBox.Name = "BodyTypeComboBox";
            this.BodyTypeComboBox.Size = new System.Drawing.Size(254, 25);
            this.BodyTypeComboBox.TabIndex = 9;
            // 
            // EngineVolumeLabel
            // 
            this.EngineVolumeLabel.AutoSize = true;
            this.EngineVolumeLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EngineVolumeLabel.ForeColor = System.Drawing.Color.White;
            this.EngineVolumeLabel.Location = new System.Drawing.Point(27, 290);
            this.EngineVolumeLabel.Name = "EngineVolumeLabel";
            this.EngineVolumeLabel.Size = new System.Drawing.Size(162, 21);
            this.EngineVolumeLabel.TabIndex = 11;
            this.EngineVolumeLabel.Text = "Объем двигателя:";
            // 
            // EngineTypeComboBox
            // 
            this.EngineTypeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.EngineTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EngineTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EngineTypeComboBox.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EngineTypeComboBox.ForeColor = System.Drawing.Color.White;
            this.EngineTypeComboBox.FormattingEnabled = true;
            this.EngineTypeComboBox.Location = new System.Drawing.Point(204, 332);
            this.EngineTypeComboBox.Name = "EngineTypeComboBox";
            this.EngineTypeComboBox.Size = new System.Drawing.Size(254, 25);
            this.EngineTypeComboBox.TabIndex = 13;
            // 
            // EngineTypeLabel
            // 
            this.EngineTypeLabel.AutoSize = true;
            this.EngineTypeLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EngineTypeLabel.ForeColor = System.Drawing.Color.White;
            this.EngineTypeLabel.Location = new System.Drawing.Point(27, 335);
            this.EngineTypeLabel.Name = "EngineTypeLabel";
            this.EngineTypeLabel.Size = new System.Drawing.Size(129, 21);
            this.EngineTypeLabel.TabIndex = 12;
            this.EngineTypeLabel.Text = "Тип двигателя:";
            // 
            // EngineVolumeUpDown
            // 
            this.EngineVolumeUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.EngineVolumeUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EngineVolumeUpDown.DecimalPlaces = 1;
            this.EngineVolumeUpDown.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EngineVolumeUpDown.ForeColor = System.Drawing.Color.White;
            this.EngineVolumeUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.EngineVolumeUpDown.Location = new System.Drawing.Point(204, 289);
            this.EngineVolumeUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.EngineVolumeUpDown.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.EngineVolumeUpDown.Name = "EngineVolumeUpDown";
            this.EngineVolumeUpDown.Size = new System.Drawing.Size(254, 22);
            this.EngineVolumeUpDown.TabIndex = 14;
            this.EngineVolumeUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            65536});
            // 
            // TransmissionTypeComboBox
            // 
            this.TransmissionTypeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.TransmissionTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TransmissionTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TransmissionTypeComboBox.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TransmissionTypeComboBox.ForeColor = System.Drawing.Color.White;
            this.TransmissionTypeComboBox.FormattingEnabled = true;
            this.TransmissionTypeComboBox.Location = new System.Drawing.Point(204, 377);
            this.TransmissionTypeComboBox.Name = "TransmissionTypeComboBox";
            this.TransmissionTypeComboBox.Size = new System.Drawing.Size(254, 25);
            this.TransmissionTypeComboBox.TabIndex = 16;
            // 
            // TransmissionTypeLabel
            // 
            this.TransmissionTypeLabel.AutoSize = true;
            this.TransmissionTypeLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TransmissionTypeLabel.ForeColor = System.Drawing.Color.White;
            this.TransmissionTypeLabel.Location = new System.Drawing.Point(27, 380);
            this.TransmissionTypeLabel.Name = "TransmissionTypeLabel";
            this.TransmissionTypeLabel.Size = new System.Drawing.Size(82, 21);
            this.TransmissionTypeLabel.TabIndex = 15;
            this.TransmissionTypeLabel.Text = "Тип КПП:";
            // 
            // WheelDriveTypeComboBox
            // 
            this.WheelDriveTypeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.WheelDriveTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WheelDriveTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WheelDriveTypeComboBox.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WheelDriveTypeComboBox.ForeColor = System.Drawing.Color.White;
            this.WheelDriveTypeComboBox.FormattingEnabled = true;
            this.WheelDriveTypeComboBox.Location = new System.Drawing.Point(204, 422);
            this.WheelDriveTypeComboBox.Name = "WheelDriveTypeComboBox";
            this.WheelDriveTypeComboBox.Size = new System.Drawing.Size(254, 25);
            this.WheelDriveTypeComboBox.TabIndex = 18;
            // 
            // WheelDriveTypeLabel
            // 
            this.WheelDriveTypeLabel.AutoSize = true;
            this.WheelDriveTypeLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WheelDriveTypeLabel.ForeColor = System.Drawing.Color.White;
            this.WheelDriveTypeLabel.Location = new System.Drawing.Point(27, 425);
            this.WheelDriveTypeLabel.Name = "WheelDriveTypeLabel";
            this.WheelDriveTypeLabel.Size = new System.Drawing.Size(121, 21);
            this.WheelDriveTypeLabel.TabIndex = 17;
            this.WheelDriveTypeLabel.Text = "Тип привода:";
            // 
            // MileageUpDown
            // 
            this.MileageUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.MileageUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MileageUpDown.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MileageUpDown.ForeColor = System.Drawing.Color.White;
            this.MileageUpDown.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MileageUpDown.Location = new System.Drawing.Point(204, 467);
            this.MileageUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.MileageUpDown.Name = "MileageUpDown";
            this.MileageUpDown.Size = new System.Drawing.Size(254, 22);
            this.MileageUpDown.TabIndex = 20;
            // 
            // MileageLabel
            // 
            this.MileageLabel.AutoSize = true;
            this.MileageLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MileageLabel.ForeColor = System.Drawing.Color.White;
            this.MileageLabel.Location = new System.Drawing.Point(27, 468);
            this.MileageLabel.Name = "MileageLabel";
            this.MileageLabel.Size = new System.Drawing.Size(78, 21);
            this.MileageLabel.TabIndex = 19;
            this.MileageLabel.Text = "Пробег:";
            // 
            // BodyColorComboBox
            // 
            this.BodyColorComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.BodyColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BodyColorComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BodyColorComboBox.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BodyColorComboBox.ForeColor = System.Drawing.Color.White;
            this.BodyColorComboBox.FormattingEnabled = true;
            this.BodyColorComboBox.Location = new System.Drawing.Point(204, 510);
            this.BodyColorComboBox.Name = "BodyColorComboBox";
            this.BodyColorComboBox.Size = new System.Drawing.Size(254, 25);
            this.BodyColorComboBox.TabIndex = 22;
            // 
            // BodyColorLabel
            // 
            this.BodyColorLabel.AutoSize = true;
            this.BodyColorLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BodyColorLabel.ForeColor = System.Drawing.Color.White;
            this.BodyColorLabel.Location = new System.Drawing.Point(27, 513);
            this.BodyColorLabel.Name = "BodyColorLabel";
            this.BodyColorLabel.Size = new System.Drawing.Size(113, 21);
            this.BodyColorLabel.TabIndex = 21;
            this.BodyColorLabel.Text = "Цвет кузова:";
            // 
            // InteriorColorComboBox
            // 
            this.InteriorColorComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.InteriorColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InteriorColorComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InteriorColorComboBox.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InteriorColorComboBox.ForeColor = System.Drawing.Color.White;
            this.InteriorColorComboBox.FormattingEnabled = true;
            this.InteriorColorComboBox.Location = new System.Drawing.Point(204, 555);
            this.InteriorColorComboBox.Name = "InteriorColorComboBox";
            this.InteriorColorComboBox.Size = new System.Drawing.Size(254, 25);
            this.InteriorColorComboBox.TabIndex = 24;
            // 
            // InteriorColorLabel
            // 
            this.InteriorColorLabel.AutoSize = true;
            this.InteriorColorLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InteriorColorLabel.ForeColor = System.Drawing.Color.White;
            this.InteriorColorLabel.Location = new System.Drawing.Point(27, 558);
            this.InteriorColorLabel.Name = "InteriorColorLabel";
            this.InteriorColorLabel.Size = new System.Drawing.Size(123, 21);
            this.InteriorColorLabel.TabIndex = 23;
            this.InteriorColorLabel.Text = "Цвет салона:";
            // 
            // InteriorMaterialComboBox
            // 
            this.InteriorMaterialComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.InteriorMaterialComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InteriorMaterialComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InteriorMaterialComboBox.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InteriorMaterialComboBox.ForeColor = System.Drawing.Color.White;
            this.InteriorMaterialComboBox.FormattingEnabled = true;
            this.InteriorMaterialComboBox.Location = new System.Drawing.Point(204, 600);
            this.InteriorMaterialComboBox.Name = "InteriorMaterialComboBox";
            this.InteriorMaterialComboBox.Size = new System.Drawing.Size(254, 25);
            this.InteriorMaterialComboBox.TabIndex = 26;
            // 
            // InteriorMaterialLabel
            // 
            this.InteriorMaterialLabel.AutoSize = true;
            this.InteriorMaterialLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InteriorMaterialLabel.ForeColor = System.Drawing.Color.White;
            this.InteriorMaterialLabel.Location = new System.Drawing.Point(27, 603);
            this.InteriorMaterialLabel.Name = "InteriorMaterialLabel";
            this.InteriorMaterialLabel.Size = new System.Drawing.Size(175, 21);
            this.InteriorMaterialLabel.TabIndex = 25;
            this.InteriorMaterialLabel.Text = "Материал салона:";
            // 
            // PriceUpDown
            // 
            this.PriceUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.PriceUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PriceUpDown.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PriceUpDown.ForeColor = System.Drawing.Color.White;
            this.PriceUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.PriceUpDown.Location = new System.Drawing.Point(204, 645);
            this.PriceUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.PriceUpDown.Name = "PriceUpDown";
            this.PriceUpDown.Size = new System.Drawing.Size(254, 22);
            this.PriceUpDown.TabIndex = 28;
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PriceLabel.ForeColor = System.Drawing.Color.White;
            this.PriceLabel.Location = new System.Drawing.Point(27, 646);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(144, 21);
            this.PriceLabel.TabIndex = 27;
            this.PriceLabel.Text = "Рыночная цена:";
            // 
            // AddCarButton
            // 
            this.AddCarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.AddCarButton.FlatAppearance.BorderSize = 0;
            this.AddCarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddCarButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddCarButton.ForeColor = System.Drawing.Color.White;
            this.AddCarButton.Location = new System.Drawing.Point(29, 690);
            this.AddCarButton.Name = "AddCarButton";
            this.AddCarButton.Size = new System.Drawing.Size(203, 40);
            this.AddCarButton.TabIndex = 29;
            this.AddCarButton.Text = "Добавить";
            this.AddCarButton.UseVisualStyleBackColor = false;
            this.AddCarButton.Click += new System.EventHandler(this.AddCarButton_Click);
            // 
            // FormTitle
            // 
            this.FormTitle.AutoSize = true;
            this.FormTitle.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormTitle.ForeColor = System.Drawing.Color.White;
            this.FormTitle.Location = new System.Drawing.Point(62, 32);
            this.FormTitle.Name = "FormTitle";
            this.FormTitle.Size = new System.Drawing.Size(377, 45);
            this.FormTitle.TabIndex = 30;
            this.FormTitle.Text = "Новый автомобиль";
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ClearButton.FlatAppearance.BorderSize = 0;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearButton.ForeColor = System.Drawing.Color.White;
            this.ClearButton.Location = new System.Drawing.Point(255, 690);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(203, 40);
            this.ClearButton.TabIndex = 34;
            this.ClearButton.Text = "Очистить";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // YearOfIssuePanel
            // 
            this.YearOfIssuePanel.BackColor = System.Drawing.Color.White;
            this.YearOfIssuePanel.ForeColor = System.Drawing.Color.White;
            this.YearOfIssuePanel.Location = new System.Drawing.Point(204, 221);
            this.YearOfIssuePanel.Name = "YearOfIssuePanel";
            this.YearOfIssuePanel.Size = new System.Drawing.Size(254, 2);
            this.YearOfIssuePanel.TabIndex = 36;
            // 
            // BrandPanel
            // 
            this.BrandPanel.BackColor = System.Drawing.Color.White;
            this.BrandPanel.ForeColor = System.Drawing.Color.White;
            this.BrandPanel.Location = new System.Drawing.Point(204, 135);
            this.BrandPanel.Name = "BrandPanel";
            this.BrandPanel.Size = new System.Drawing.Size(254, 2);
            this.BrandPanel.TabIndex = 37;
            // 
            // ModelPanel
            // 
            this.ModelPanel.BackColor = System.Drawing.Color.White;
            this.ModelPanel.ForeColor = System.Drawing.Color.White;
            this.ModelPanel.Location = new System.Drawing.Point(204, 178);
            this.ModelPanel.Name = "ModelPanel";
            this.ModelPanel.Size = new System.Drawing.Size(254, 2);
            this.ModelPanel.TabIndex = 38;
            // 
            // EngineVolumePanel
            // 
            this.EngineVolumePanel.BackColor = System.Drawing.Color.White;
            this.EngineVolumePanel.ForeColor = System.Drawing.Color.White;
            this.EngineVolumePanel.Location = new System.Drawing.Point(204, 309);
            this.EngineVolumePanel.Name = "EngineVolumePanel";
            this.EngineVolumePanel.Size = new System.Drawing.Size(254, 2);
            this.EngineVolumePanel.TabIndex = 38;
            // 
            // MileagePanel
            // 
            this.MileagePanel.BackColor = System.Drawing.Color.White;
            this.MileagePanel.ForeColor = System.Drawing.Color.White;
            this.MileagePanel.Location = new System.Drawing.Point(204, 487);
            this.MileagePanel.Name = "MileagePanel";
            this.MileagePanel.Size = new System.Drawing.Size(254, 2);
            this.MileagePanel.TabIndex = 39;
            // 
            // PricePanel
            // 
            this.PricePanel.BackColor = System.Drawing.Color.White;
            this.PricePanel.ForeColor = System.Drawing.Color.White;
            this.PricePanel.Location = new System.Drawing.Point(204, 665);
            this.PricePanel.Name = "PricePanel";
            this.PricePanel.Size = new System.Drawing.Size(254, 2);
            this.PricePanel.TabIndex = 39;
            // 
            // ExitButton
            // 
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Location = new System.Drawing.Point(468, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(32, 32);
            this.ExitButton.TabIndex = 35;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            // 
            // CarAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(500, 760);
            this.Controls.Add(this.PricePanel);
            this.Controls.Add(this.MileagePanel);
            this.Controls.Add(this.EngineVolumePanel);
            this.Controls.Add(this.ModelPanel);
            this.Controls.Add(this.BrandPanel);
            this.Controls.Add(this.YearOfIssuePanel);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.FormTitle);
            this.Controls.Add(this.AddCarButton);
            this.Controls.Add(this.PriceUpDown);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.InteriorMaterialComboBox);
            this.Controls.Add(this.InteriorMaterialLabel);
            this.Controls.Add(this.InteriorColorComboBox);
            this.Controls.Add(this.InteriorColorLabel);
            this.Controls.Add(this.BodyColorComboBox);
            this.Controls.Add(this.BodyColorLabel);
            this.Controls.Add(this.MileageUpDown);
            this.Controls.Add(this.MileageLabel);
            this.Controls.Add(this.WheelDriveTypeComboBox);
            this.Controls.Add(this.WheelDriveTypeLabel);
            this.Controls.Add(this.TransmissionTypeComboBox);
            this.Controls.Add(this.TransmissionTypeLabel);
            this.Controls.Add(this.EngineVolumeUpDown);
            this.Controls.Add(this.EngineTypeComboBox);
            this.Controls.Add(this.EngineTypeLabel);
            this.Controls.Add(this.EngineVolumeLabel);
            this.Controls.Add(this.BodyTypeComboBox);
            this.Controls.Add(this.BodyTypeLabel);
            this.Controls.Add(this.YearOfIssueUpDown);
            this.Controls.Add(this.YearOfIssueLabel);
            this.Controls.Add(this.ModelLabel);
            this.Controls.Add(this.ModelTextBox);
            this.Controls.Add(this.BrandLabel);
            this.Controls.Add(this.BrandTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CarAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CarAddPanel";
            ((System.ComponentModel.ISupportInitialize)(this.YearOfIssueUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EngineVolumeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MileageUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox BrandTextBox;
        private System.Windows.Forms.Label BrandLabel;
        private System.Windows.Forms.Label ModelLabel;
        private System.Windows.Forms.TextBox ModelTextBox;
        private System.Windows.Forms.Label YearOfIssueLabel;
        private System.Windows.Forms.NumericUpDown YearOfIssueUpDown;
        private System.Windows.Forms.Label BodyTypeLabel;
        private System.Windows.Forms.ComboBox BodyTypeComboBox;
        private System.Windows.Forms.Label EngineVolumeLabel;
        private System.Windows.Forms.ComboBox EngineTypeComboBox;
        private System.Windows.Forms.Label EngineTypeLabel;
        private System.Windows.Forms.NumericUpDown EngineVolumeUpDown;
        private System.Windows.Forms.ComboBox TransmissionTypeComboBox;
        private System.Windows.Forms.Label TransmissionTypeLabel;
        private System.Windows.Forms.ComboBox WheelDriveTypeComboBox;
        private System.Windows.Forms.Label WheelDriveTypeLabel;
        private System.Windows.Forms.NumericUpDown MileageUpDown;
        private System.Windows.Forms.Label MileageLabel;
        private System.Windows.Forms.ComboBox BodyColorComboBox;
        private System.Windows.Forms.Label BodyColorLabel;
        private System.Windows.Forms.ComboBox InteriorColorComboBox;
        private System.Windows.Forms.Label InteriorColorLabel;
        private System.Windows.Forms.ComboBox InteriorMaterialComboBox;
        private System.Windows.Forms.Label InteriorMaterialLabel;
        private System.Windows.Forms.NumericUpDown PriceUpDown;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Button AddCarButton;
        private System.Windows.Forms.Label FormTitle;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Panel YearOfIssuePanel;
        private System.Windows.Forms.Panel BrandPanel;
        private System.Windows.Forms.Panel ModelPanel;
        private System.Windows.Forms.Panel EngineVolumePanel;
        private System.Windows.Forms.Panel MileagePanel;
        private System.Windows.Forms.Panel PricePanel;
    }
}