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
    public partial class MyAccountForm : Form
    {
        private User _CurrentUser = null;
        private int _CountOfCarsBought = 0;
        private decimal _TotalBoughts = 0.0M;
        private decimal _AverageCheck = 0.0M;
        private decimal _MaxCheck = 0.0M;
        private decimal _MinCheck = 0.0M;

        public MyAccountForm()
        {
            InitializeComponent();
            UpdateUserInformation();
        }

        public MyAccountForm(User user) : this()
        {
            _CurrentUser = user ?? throw new ArgumentNullException(nameof(user), "Текущий пользователь равен null.");
        }

        private void ChangeUsername_Click(object sender, EventArgs e)
        {
            bool isEdited = false;
            bool isClosed = false;

            using (var EditForm = new EditForm("логина", _CurrentUser.Username))
            {
                while(!isEdited && !isClosed)
                {
                    EditForm.ShowDialog();
                    if (EditForm.DialogResult == DialogResult.OK)
                    {
                        isEdited = EditCurrentUserUsername(EditForm.EditedText);

                        if (isEdited)
                        {
                            UpdateUserInformation();
                        }
                    }
                    if (EditForm.DialogResult == DialogResult.Cancel)
                    {
                        isClosed = true;
                    }
                }
            }
        }

        private void GetCurrentUserStatistics()
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.GetCurrentUserStatistics);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Success)
                {
                    _CountOfCarsBought = (int)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                    _TotalBoughts = (decimal)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                    _AverageCheck = (decimal)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                    _MaxCheck = (decimal)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                    _MinCheck = (decimal)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                }
                else
                {
                    var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                    MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK);
            }
        }

        private bool EditCurrentUserUsername(string username)
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.EditCurrentUserUsername);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, username);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Error)
                {
                    var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                    MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK);
                return false;
            }
        }

        private bool EditCurrentUserPassword(string password)
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.EditCurrentUserPassword);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, password);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Error)
                {
                    var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                    MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK);
                return false;
            }
        }

        private bool EditCurrentUserFirstname(string firstname)
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.EditCurrentUserFirstname);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, firstname);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Error)
                {
                    var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                    MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK);
                return false;
            }
        }

        private bool EditCurrentUserSurname(string surname)
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.EditCurrentUserSurname);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, surname);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Error)
                {
                    var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                    MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK);
                return false;
            }
        }

        private bool EditCurrentUserTelephone(string telephone)
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.EditCurrentUserTelephone);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, telephone);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Error)
                {
                    var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                    MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK);
                return false;
            }
        }

        private void UpdateUserInformation()
        {
            GetCurrentUser();
            GetCurrentUserStatistics();

            UsernameTextBox.Text = _CurrentUser.Username;
            PasswordTextBox.Text = new string('•', _CurrentUser.Password.Length);
            FirstnameTextBox.Text = _CurrentUser.Firstname;
            SurnameTextBox.Text = _CurrentUser.Surname;
            TelephoneTextBox.Text = _CurrentUser.Telephone;
            CountOfCarsBoughtValueLabel.Text = _CountOfCarsBought.ToString();
            TotalBoughtsValueLabel.Text = _TotalBoughts.ToString("0.00");
            AverageCheckValueLabel.Text = _AverageCheck.ToString("0.00");
            MaxCheckValueLabel.Text = _MaxCheck.ToString("0.00");
            MinCheckValueLabel.Text = _MinCheck.ToString("0.00");
            RegisterDateValueLabel.Text = _CurrentUser.DateOfRegistration.ToString();
        }

        private void GetCurrentUser()
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.GetCurrentUser);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Success)
                {
                    _CurrentUser = (User)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                }
                else
                {
                    var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                    MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK);
                Environment.Exit(0);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangePassword_Click(object sender, EventArgs e)
        {
            bool isEdited = false;
            bool isClosed = false;

            using (var EditForm = new EditForm("пароля"))
            {
                while (!isEdited && !isClosed)
                {
                    EditForm.ShowDialog();
                    if (EditForm.DialogResult == DialogResult.OK)
                    {
                        isEdited = EditCurrentUserPassword(EditForm.EditedText);

                        if (isEdited)
                        {
                            UpdateUserInformation();
                        }
                    }
                    if (EditForm.DialogResult == DialogResult.Cancel)
                    {
                        isClosed = true;
                    }
                }
            }
        }

        private void ChangeFirstname_Click(object sender, EventArgs e)
        {
            bool isEdited = false;
            bool isClosed = false;

            using (var EditForm = new EditForm("имени", _CurrentUser.Firstname))
            {
                while (!isEdited && !isClosed)
                {
                    EditForm.ShowDialog();
                    if (EditForm.DialogResult == DialogResult.OK)
                    {
                        isEdited = EditCurrentUserFirstname(EditForm.EditedText);

                        if (isEdited)
                        {
                            UpdateUserInformation();
                        }
                    }
                    if (EditForm.DialogResult == DialogResult.Cancel)
                    {
                        isClosed = true;
                    }
                }
            }
        }

        private void ChangeSurname_Click(object sender, EventArgs e)
        {
            bool isEdited = false;
            bool isClosed = false;

            using (var EditForm = new EditForm("фамилии", _CurrentUser.Surname))
            {
                while (!isEdited && !isClosed)
                {
                    EditForm.ShowDialog();
                    if (EditForm.DialogResult == DialogResult.OK)
                    {
                        isEdited = EditCurrentUserSurname(EditForm.EditedText);

                        if (isEdited)
                        {
                            UpdateUserInformation();
                        }
                    }
                    if (EditForm.DialogResult == DialogResult.Cancel)
                    {
                        isClosed = true;
                    }
                }
            }
        }

        private void ChangeTelephone_Click(object sender, EventArgs e)
        {
            bool isEdited = false;
            bool isClosed = false;

            using (var EditForm = new EditForm("телефона", _CurrentUser.Telephone))
            {
                while (!isEdited && !isClosed)
                {
                    EditForm.ShowDialog();
                    if (EditForm.DialogResult == DialogResult.OK)
                    {
                        isEdited = EditCurrentUserTelephone(EditForm.EditedText);

                        if (isEdited)
                        {
                            UpdateUserInformation();
                        }
                    }
                    if (EditForm.DialogResult == DialogResult.Cancel)
                    {
                        isClosed = true;
                    }
                }
            }
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
