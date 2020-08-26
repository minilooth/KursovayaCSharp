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
    public partial class UserAddForm : Form
    {
        public string Username { get; private set; } = null;
        public string Password { get; private set; } = null;
        public string Firstname { get; private set; } = null;
        public string Surname { get; private set; } = null;
        public string Telephone { get; private set; } = null;
        public bool SuperUser { get; private set; } = false;
        public bool BanStatus { get; private set; } = false;

        public UserAddForm()
        {
            InitializeComponent();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            UsernameTextBox.Text = "";
            PasswordTextBox.Text = "";
            FirstnameTextBox.Text = "";
            SurnameTextBox.Text = "";
            TelephoneTextBox.Text = "";
            SuperUserCheckBox.Checked = false;
            BanStatusCheckBox.Checked = false;
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            Username = UsernameTextBox.Text;
            Password = PasswordTextBox.Text;
            Firstname = FirstnameTextBox.Text;
            Surname = SurnameTextBox.Text;
            Telephone = TelephoneTextBox.Text;
            SuperUser = SuperUserCheckBox.Checked;
            BanStatus = BanStatusCheckBox.Checked;

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
