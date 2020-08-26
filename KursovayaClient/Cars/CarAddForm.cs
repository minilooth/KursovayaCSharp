using Autodealers.Enums;
using Autodealers.Models;
using ServerUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursovayaCSharp
{
    public partial class CarAddForm : Form
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int YearOfIssue { get; private set; }
        public BodyType BodyType { get; private set; }
        public float EngineVolume { get; private set; }
        public EngineType EngineType { get; private set; }
        public TransmissionType TransmissionType { get; private set; }
        public WheelDriveType WheelDriveType { get; private set; }
        public decimal Mileage { get; private set; }
        public BodyColor BodyColor { get; private set; }
        public InteriorMaterial InteriorMaterial { get; private set; }
        public InteriorColor InteriorColor { get; private set; }
        public decimal Price { get; private set; }

        public CarAddForm()
        {
            InitializeComponent();
            AddComboBoxesItems();
        }

        private void AddBodyTypes()
        {
            BodyTypeComboBox.Items.AddRange(new object[]
            {
                "Внедорожник 3 дв.",
                "Внедорожник 5 дв.",
                "Кабриолет",
                "Купе",
                "Легковой фургон",
                "Лимузин",
                "Лифтбек",
                "Микроавтобус грузопассажирский",
                "Микроавтобус пассажирский",
                "Минивэн",
                "Пикап",
                "Родстер",
                "Седан",
                "Универсал",
                "Хэтчбек 3 дв.",
                "Хэтчбек 5 дв.",
                "Другой" 
            });
        }

        private void AddEngineTypes()
        {
            EngineTypeComboBox.Items.AddRange(new object[]
            {
                "Бензиновый",
                "Дизельный",
                "Электро" 
            });
        }

        private void AddTransmissionTypes()
        {
            TransmissionTypeComboBox.Items.AddRange(new object[]
            {
                "Автоматическая",
                "Механическая"
            });
        }

        private void AddWheelDriveTypes()
        {
            WheelDriveTypeComboBox.Items.AddRange(new object[]
            {
                "Передний",
                "Задний",
                "Подключаемый полный",
                "Постоянный полный"
            });
        }

        private void AddBodyColors()
        {
            BodyColorComboBox.Items.AddRange(new object[] 
            { 
                "Белый", 
                "Бордовый", 
                "Желтый", 
                "Зеленый", 
                "Коричневый", 
                "Красный", 
                "Оранжевый", 
                "Серебристый", 
                "Серый", 
                "Синий", 
                "Фиолетовый", 
                "Черный", 
                "Другой" 
            });
        }

        private void AddInteriorMaterials()
        {
            InteriorMaterialComboBox.Items.AddRange(new object[]
            {
                "Натуральная кожа", 
                "Искусственная кожа",
                "Ткань", 
                "Велюр", 
                "Алькантара", 
                "Комбинированный"
            });
        }

        private void AddInteriorColors()
        {
            InteriorColorComboBox.Items.AddRange(new object[]
            {
                "Светлый", 
                "Темный", 
                "Комбинированный"
            });
        }

        private void AddComboBoxesItems()
        {
            AddBodyTypes();
            AddTransmissionTypes();
            AddEngineTypes();
            AddWheelDriveTypes();
            AddBodyColors();
            AddInteriorMaterials();
            AddInteriorColors();
        }

        private void AddCarButton_Click(object sender, EventArgs e)
        {
            Brand = BrandTextBox.Text;
            Model = ModelTextBox.Text;
            YearOfIssue = Convert.ToInt32(YearOfIssueUpDown.Value);
            BodyType = (Autodealers.Enums.BodyType)(BodyTypeComboBox.SelectedIndex + 1);
            EngineVolume = Convert.ToSingle(EngineVolumeUpDown.Value);
            EngineType = (Autodealers.Enums.EngineType)(EngineTypeComboBox.SelectedIndex + 1);
            TransmissionType = (Autodealers.Enums.TransmissionType)(TransmissionTypeComboBox.SelectedIndex + 1);
            WheelDriveType = (Autodealers.Enums.WheelDriveType)(WheelDriveTypeComboBox.SelectedIndex + 1);
            Mileage = MileageUpDown.Value;
            BodyColor = (Autodealers.Enums.BodyColor)(BodyColorComboBox.SelectedIndex + 1);
            InteriorColor = (Autodealers.Enums.InteriorColor)(InteriorColorComboBox.SelectedIndex + 1);
            InteriorMaterial = (Autodealers.Enums.InteriorMaterial)(InteriorMaterialComboBox.SelectedIndex + 1);
            Price = PriceUpDown.Value;

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            BrandTextBox.Text = "";
            ModelTextBox.Text = "";
            YearOfIssueUpDown.Value = 2000;
            BodyTypeComboBox.SelectedIndex = -1;
            EngineVolumeUpDown.Value = 2;
            EngineTypeComboBox.SelectedIndex = -1;
            TransmissionTypeComboBox.SelectedIndex = -1;
            WheelDriveTypeComboBox.SelectedIndex = -1;
            MileageUpDown.Value = 0;
            BodyColorComboBox.SelectedIndex = -1;
            InteriorColorComboBox.SelectedIndex = -1;
            InteriorMaterialComboBox.SelectedIndex = -1;
            PriceUpDown.Value = 0;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            ExitButton.Image = Properties.Resources.close_icon_colored;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.Image = Properties.Resources.close_icon;
        }
    }
}
