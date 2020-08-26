using System;
using System.Drawing;
using System.Windows.Forms;
using ServerUtilities;

namespace KursovayaCSharp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // ExitButton Events
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Connection.Client.Close();
            Application.Exit();
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            ExitButton.Image = Properties.Resources.close_icon_colored;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.Image = Properties.Resources.close_icon;
        }

        // UsernameTextBox Events
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

        private void UsernameTextBox_Enter(object sender, EventArgs e)
        {
            UsernameTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            UsernamePictureBox.Image = Properties.Resources.user_icon_colored;
            UsernameFieldPanel.BackColor = Color.FromArgb(78, 184, 206);

            LoginStatusLabel.Text = "";

            if (UsernameTextBox.Text == "Логин")
            {
                UsernameTextBox.Clear();
            }
        }

        // PasswordTextBox Events
        private void PasswordTextBox_Enter(object sender, EventArgs e)
        {
            PasswordTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            PasswordPictureBox.Image = Properties.Resources.password_icon_colored;
            PasswordFieldPanel.BackColor = Color.FromArgb(78, 184, 206);

            LoginStatusLabel.Text = "";

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

        private void RegisterNowLabel_MouseEnter(object sender, EventArgs e)
        {
            RegisterNowLabel.Font = new Font("Century Gothic", 8, FontStyle.Underline);
            RegisterNowLabel.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void RegisterNowLabel_MouseLeave(object sender, EventArgs e)
        {
            RegisterNowLabel.Font = new Font("Century Gothic", 8, FontStyle.Regular);
            RegisterNowLabel.ForeColor = Color.White;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (Connection.NetworkStream.CanWrite && Connection.Client.Connected)
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.Authorize);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, UsernameTextBox.Text);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, PasswordTextBox.Text);
            }

            if (Connection.NetworkStream.CanRead && Connection.Client.Connected)
            {
                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Success)
                {
                    var AutodelaerChooseForm = new AutodealerChooseForm()
                    {
                        Owner = this,
                        StartPosition = FormStartPosition.CenterScreen
                    };

                    this.Hide();
                    AutodelaerChooseForm.Show();
                }
                else
                {
                    var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                    LoginStatusLabel.Text = $"Ошибка входа: {message}";
                }
            }
        }

        private void RegisterNowLabel_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm
            {
                Owner = this,
                StartPosition = FormStartPosition.CenterScreen
            };

            this.Hide();
            registerForm.Show();
        }
    }
}
