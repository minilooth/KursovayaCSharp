using Autodealers.Enums;
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
    public partial class CarFilteringForm : Form
    {
        public string BrandFilter { get; set; } = null;
        public string ModelFilter { get; set; } = null;
        public int YearOfIssueMinFilter { get; set; } = 1975;
        public int YearOfIssueMaxFilter { get; set; } = 2020;
        public BodyType BodyTypeFilter { get; set; } = 0;
        public float EngineVolumeMinFilter { get; set; } = 0.8f;
        public float EngineVolumeMaxFilter { get; set; } = 10.0f;
        public EngineType EngineTypeFilter { get; set; } = 0;
        public TransmissionType TransmissionTypeFilter { get; set; } = 0;
        public WheelDriveType WheelDriveTypeFilter { get; set; } = 0;
        public decimal MileageMinFilter { get; set; } = 0M;
        public decimal MileageMaxFilter { get; set; } = 1000000M;
        public BodyColor BodyColorFilter { get; set; } = 0;
        public InteriorMaterial InteriorMaterialFilter { get; set; } = 0;
        public InteriorColor InteriorColorFilter { get; set; } = 0;
        public decimal PriceMinFilter { get; set; } = 0;
        public decimal PriceMaxFilter { get; set; } = 1000000M;

        public CarFilteringForm()
        {
            InitializeComponent();
            AddComboBoxesItems();
        }

        private void AddCarButton_Click(object sender, EventArgs e)
        {
            SetFilter();

            DialogResult = DialogResult.OK;
            this.Close();
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

        private void SetFilter()
        {
            BrandFilter = BrandTextBox.Text;
            ModelFilter = ModelTextBox.Text;
            YearOfIssueMinFilter = Convert.ToInt32(YearOfIssueMinUpDown.Value);
            YearOfIssueMaxFilter = Convert.ToInt32(YearOfIssueMaxUpDown.Value);
            BodyTypeFilter = (BodyType)(BodyTypeComboBox.SelectedIndex + 1);
            EngineVolumeMinFilter = Convert.ToSingle(EngineVolumeMinUpDown.Value);
            EngineVolumeMaxFilter = Convert.ToSingle(EngineVolumeMaxUpDown.Value);
            EngineTypeFilter = (EngineType)(EngineTypeComboBox.SelectedIndex + 1);
            TransmissionTypeFilter = (TransmissionType)(TransmissionTypeComboBox.SelectedIndex + 1);
            WheelDriveTypeFilter = (WheelDriveType)(WheelDriveTypeComboBox.SelectedIndex + 1);
            MileageMinFilter = MileageMinUpDown.Value;
            MileageMaxFilter = MileageMaxUpDown.Value;
            BodyColorFilter = (BodyColor)(BodyColorComboBox.SelectedIndex + 1);
            InteriorColorFilter = (InteriorColor)(InteriorColorComboBox.SelectedIndex + 1);
            InteriorMaterialFilter = (InteriorMaterial)(InteriorMaterialComboBox.SelectedIndex + 1);
            PriceMinFilter = PriceMinUpDown.Value;
            PriceMaxFilter = PriceMaxUpDown.Value;
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
