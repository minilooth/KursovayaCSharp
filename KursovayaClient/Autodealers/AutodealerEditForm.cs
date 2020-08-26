using Autodealers.Models;
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
    public partial class AutodealerEditForm : Form
    {
        public string Title { get; private set; }
        public string WorkingHours { get; private set; }
        public string City { get; private set; }
        public string Address { get; private set; }

        public AutodealerEditForm()
        {
            InitializeComponent();
        }

        public AutodealerEditForm(Autodealer autodealer) : this()
        {
            SetValues(autodealer);
        }

        private void SetValues(Autodealer autodealer)
        {
            TitleTextBox.Text = autodealer.Title;
            string[] times = autodealer.WorkingHours.Split('-');
            TimeFrom.Value = DateTime.Parse(times[0]);
            TimeTo.Value = DateTime.Parse(times[1]);
            CityTextBox.Text = autodealer.City;
            AddressTextBox.Text = autodealer.Address;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void UpdateValues()
        {
            Title = TitleTextBox.Text;
            WorkingHours = TimeFrom.Value.ToString("HH:mm") + "-" + TimeTo.Value.ToString("HH:mm");
            City = CityTextBox.Text;
            Address = AddressTextBox.Text;
        }

        private void AddAutodealerButton_Click(object sender, EventArgs e)
        {
            UpdateValues();

            DialogResult = DialogResult.OK;
            Close();
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
