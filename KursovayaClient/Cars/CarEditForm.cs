using Autodealers.Enums;
using Autodealers.Models;
using System;
using System.Windows.Forms;

namespace KursovayaCSharp
{
    public partial class CarEditForm : Form
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
        public decimal Price { get; set; }

        public CarEditForm()
        {
            InitializeComponent();
        }

        public CarEditForm(Car car) : this()
        {
            AddComboBoxesItems();

            SetCarValues(car);
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

        private void SetCarValues(Car car)
        {
            BrandTextBox.Text = car.Brand;
            ModelTextBox.Text = car.Model;
            YearOfIssueUpDown.Value = car.YearOfIssue;
            BodyTypeComboBox.SelectedIndex = (int)car.BodyType - 1;
            EngineVolumeUpDown.Value = Convert.ToDecimal(car.EngineVolume);
            EngineTypeComboBox.SelectedIndex = (int)car.EngineType - 1;
            TransmissionTypeComboBox.SelectedIndex = (int)car.TransmissionType - 1;
            WheelDriveTypeComboBox.SelectedIndex = (int)car.WheelDriveType - 1;
            MileageUpDown.Value = car.Mileage;
            BodyColorComboBox.SelectedIndex = (int)car.BodyColor - 1;
            InteriorColorComboBox.SelectedIndex = (int)car.InteriorColor - 1;
            InteriorMaterialComboBox.SelectedIndex = (int)car.InteriorMaterial - 1;
            PriceUpDown.Value = car.Price;
        }

        private void SetCarNewValues()
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
        }

        private void ChangeCarButton_Click(object sender, EventArgs e)
        {
            SetCarNewValues();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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
