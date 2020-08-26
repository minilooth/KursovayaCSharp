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
    public partial class DealEditForm : Form
    {
        public string Username { get; private set; }
        public int CarId { get; private set; }

        public DealEditForm()
        {
            InitializeComponent();
        }

        public DealEditForm(Deal deal) : this()
        {
            UsernameTextBox.Text = deal.User.Username;
            CarIdUpDown.Value = deal.CarId;
        }

        private void SetNewValues()
        {
            Username = UsernameTextBox.Text;
            CarId = Convert.ToInt32(CarIdUpDown.Value);
        }

        private void AddDealButton_Click(object sender, EventArgs e)
        {
            SetNewValues();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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
