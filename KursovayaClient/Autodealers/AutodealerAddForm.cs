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
    public partial class AutodealerAddForm : Form
    {
        public string Title { get; private set; }
        public string WorkingHours { get; private set; }
        public string City { get; private set; }
        public string Address { get; private set; }

        public AutodealerAddForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SetValues()
        {
            Title = TitleTextBox.Text;
            WorkingHours = TimeFrom.Value.ToString("HH:mm") + "-" + TimeTo.Value.ToString("HH:mm");
            City = CityTextBox.Text;
            Address = AddressTextBox.Text;
        }

        private void AddAutodealerButton_Click(object sender, EventArgs e)
        {
            SetValues();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ClearValues()
        {
            TitleTextBox.Text = "";
            TimeFrom.Value = DateTime.Now;
            TimeTo.Value = DateTime.Now;
            CityTextBox.Text = "";
            AddressTextBox.Text = "";
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearValues();
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
