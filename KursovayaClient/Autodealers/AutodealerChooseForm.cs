using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodealers.Models;
using ServerUtilities;

namespace KursovayaCSharp
{
    public partial class AutodealerChooseForm : Form
    {
        private List<Autodealer> _Autodealers = null;
        private User _CurrentUser = null;
        private bool _Selected = false;

        public AutodealerChooseForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();

            this.Hide();
            loginForm.Show();
        }

        private void AutodealerChooseForm_Load(object sender, EventArgs e)
        {
            RefreshAutodealersList();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            SelectAutodealer();

            if (_Selected)
            {
                this.Hide();

                GetCurrentUser();

                if (_CurrentUser.SuperUser)
                {
                    var AdminMainForm = new AdminMainForm();

                    AdminMainForm.Show();
                }
                else
                {
                    var UserMainForm = new UserMainForm();

                    UserMainForm.Show();
                }
            }
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
                    MessageBox.Show("Ошибка!", message, MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!", ex.Message, MessageBoxButtons.OK);
                Environment.Exit(0);
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshAutodealersList();
        }

        private void AutodealersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectButton.Enabled = AutodealersListBox.SelectedItems.Count == 0 ? false : true;
        }

        private void SelectAutodealer()
        {
            try
            {
                if (Connection.NetworkStream.CanWrite)
                {
                    Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                    Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.SetCurrentAutodealer);
                    Connection.BinaryFormatter.Serialize(Connection.NetworkStream, _Autodealers[AutodealersListBox.SelectedIndex].AutodealerId);
                }

                if (Connection.NetworkStream.CanRead)
                {
                    var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                    if (messageType == MessageType.Error)
                    {
                        var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                        _Selected = false;
                        MessageBox.Show("Ошибка!", message, MessageBoxButtons.OK);
                    }
                    else
                    {
                        _Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!", ex.Message, MessageBoxButtons.OK);
                Environment.Exit(0);
            }
        }

        private void RefreshAutodealersList()
        {
            try
            {
                if (Connection.NetworkStream.CanWrite)
                {
                    Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                    Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.GetAutodealers);
                }

                if (Connection.NetworkStream.CanRead)
                {
                    var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                    switch (messageType)
                    {
                        case MessageType.Success:
                            _Autodealers = (List<Autodealer>)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                            break;
                        case MessageType.Error:
                            var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                            MessageBox.Show("Ошибка!", message, MessageBoxButtons.OK);
                            return;
                    }
                }

                if (_Autodealers != null)
                {
                    AutodealersListBox.Items.Clear();

                    foreach (var item in _Autodealers)
                    {
                        AutodealersListBox.Items.Add(item);
                    }

                    AutodealersListBox.ClearSelected();
                    SelectButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!", ex.Message, MessageBoxButtons.OK);
                Environment.Exit(0);
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
