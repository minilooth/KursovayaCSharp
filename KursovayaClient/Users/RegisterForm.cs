using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerUtilities;

namespace KursovayaCSharp
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Connection.Client.Close();
            Application.Exit();
        }

        private void UsernameTextBox_Enter(object sender, EventArgs e)
        {
            UsernameTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            UsernamePictureBox.Image = Properties.Resources.user_icon_colored;
            UsernameFieldPanel.BackColor = Color.FromArgb(78, 184, 206);

            RegisterStatusLabel.Text = "";

            if (UsernameTextBox.Text == "Логин")
            {
                UsernameTextBox.Clear();
            }
        }

        private void UsernameTextBox_Leave(object sender, EventArgs e)
        {
            UsernameTextBox.ForeColor = Color.White;
            UsernamePictureBox.Image = Properties.Resources.user_icon;
            UsernameFieldPanel.BackColor = Color.White;

            if (UsernameTextBox.Text == "")
            {
                UsernameTextBox.Text = "Логин";
            }
        }

        private void PasswordTextBox_Enter(object sender, EventArgs e)
        {
            PasswordTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            PasswordPictureBox.Image = Properties.Resources.password_icon_colored;
            PasswordFieldPanel.BackColor = Color.FromArgb(78, 184, 206);

            RegisterStatusLabel.Text = "";

            if (PasswordTextBox.Text == "Пароль")
            {
                PasswordTextBox.Clear();
                PasswordTextBox.PasswordChar = '•';
            }
        }

        private void PasswordTextBox_Leave(object sender, EventArgs e)
        {
            PasswordTextBox.ForeColor = Color.White;
            PasswordPictureBox.Image = Properties.Resources.password_icon;
            PasswordFieldPanel.BackColor = Color.White;

            if (PasswordTextBox.Text == "")
            {
                PasswordTextBox.PasswordChar = '\0';
                PasswordTextBox.Text = "Пароль";
            }
        }

        private void FirstnameTextBox_Enter(object sender, EventArgs e)
        {
            FirstnameTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            FirstnamePictureBox.Image = Properties.Resources.firstname_icon_colored;
            FirstnameFieldPanel.BackColor = Color.FromArgb(78, 184, 206);

            RegisterStatusLabel.Text = "";

            if (FirstnameTextBox.Text == "Имя")
            {
                FirstnameTextBox.Clear();
            }
        }

        private void FirstnameTextBox_Leave(object sender, EventArgs e)
        {
            FirstnameTextBox.ForeColor = Color.White;
            FirstnamePictureBox.Image = Properties.Resources.firstname_icon;
            FirstnameFieldPanel.BackColor = Color.White;

            if (FirstnameTextBox.Text == "")
            {
                FirstnameTextBox.Text = "Имя";
            }
        }

        private void MiddlenameTextBox_Enter(object sender, EventArgs e)
        {
            MiddlenameTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            MiddlenamePictureBox.Image = Properties.Resources.middlename_icon_colored;
            MiddlenameFieldPanel.BackColor = Color.FromArgb(78, 184, 206);

            RegisterStatusLabel.Text = "";

            if (MiddlenameTextBox.Text == "Фамилия")
            {
                MiddlenameTextBox.Clear();
            }
        }

        private void MiddlenameTextBox_Leave(object sender, EventArgs e)
        {
            MiddlenameTextBox.ForeColor = Color.White;
            MiddlenamePictureBox.Image = Properties.Resources.middlename_icon;
            MiddlenameFieldPanel.BackColor = Color.White;

            if (MiddlenameTextBox.Text == "")
            {
                MiddlenameTextBox.Text = "Фамилия";
            }
        }

        private void TelephoneTextBox_Enter(object sender, EventArgs e)
        {
            TelephoneTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            TelephonePictureBox.Image = Properties.Resources.phone_icon_colored;
            TelephoneFieldPanel.BackColor = Color.FromArgb(78, 184, 206);

            RegisterStatusLabel.Text = "";

            if (TelephoneTextBox.Text == "Телефон")
            {
                TelephoneTextBox.Clear();
            }
        }

        private void TelephoneTextBox_Leave(object sender, EventArgs e)
        {
            TelephoneTextBox.ForeColor = Color.White;
            TelephonePictureBox.Image = Properties.Resources.phone_icon;
            TelephoneFieldPanel.BackColor = Color.White;

            if (TelephoneTextBox.Text == "")
            {
                TelephoneTextBox.Text = "Телефон";
            }
        }

        private void LoginNowLabel_MouseEnter(object sender, EventArgs e)
        {
            LoginNowLabel.Font = new Font("Century Gothic", 8, FontStyle.Underline);
            LoginNowLabel.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void LoginNowLabel_MouseLeave(object sender, EventArgs e)
        {
            LoginNowLabel.Font = new Font("Century Gothic", 8, FontStyle.Regular);
            LoginNowLabel.ForeColor = Color.White;
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            ExitButton.Image = Properties.Resources.close_icon_colored;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.Image = Properties.Resources.close_icon;
        }

        private void LoginNowLabel_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.Owner = this;
            loginForm.StartPosition = FormStartPosition.CenterScreen;

            this.Hide();
            loginForm.Show();
        }

        #region RegisterButton

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (Connection.NetworkStream.CanWrite)
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.Register);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, UsernameTextBox.Text);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, PasswordTextBox.Text);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, FirstnameTextBox.Text);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MiddlenameTextBox.Text);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, TelephoneTextBox.Text);
            }

            if (Connection.NetworkStream.CanRead)
            {
                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Success)
                { 
                    MessageBox.Show(message, "Успешная регистрация!", MessageBoxButtons.OK);
                }
                else
                {
                    RegisterStatusLabel.Text = $"Ошибка регистрации: {message}";
                }
            }
        }

        #endregion
    }
}
