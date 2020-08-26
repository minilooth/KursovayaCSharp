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
    public partial class UserEditForm : Form
    {
        public string Username { get; private set; } = null;
        public string Password { get; private set; } = null;
        public string Firstname { get; private set; } = null;
        public string Surname { get; private set; } = null;
        public string Telephone { get; private set; } = null;
        public bool SuperUser { get; private set; } = false;
        public bool BanStatus { get; private set; } = false;

        public UserEditForm()
        {
            InitializeComponent();
        }

        public UserEditForm(User user) : this()
        {
            UsernameTextBox.Text = user.Username;
            PasswordTextBox.Text = user.Password;
            FirstnameTextBox.Text = user.Firstname;
            SurnameTextBox.Text = user.Surname;
            TelephoneTextBox.Text = user.Telephone;
            SuperUserCheckBox.Checked = user.SuperUser;
            BanStatusCheckBox.Checked = user.BanStatus;
        }

        private void SetNewValues()
        {
            Username = UsernameTextBox.Text;
            Password = PasswordTextBox.Text;
            Firstname = FirstnameTextBox.Text;
            Surname = SurnameTextBox.Text;
            Telephone = TelephoneTextBox.Text;
            SuperUser = SuperUserCheckBox.Checked;
            BanStatus = BanStatusCheckBox.Checked;
        }

        private void EditUserButton_Click(object sender, EventArgs e)
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
