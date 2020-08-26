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
    public partial class DealAddForm : Form
    {
        private List<User> _Users = null;
        private List<Car> _Cars = null;

        public string Username { get; private set; }
        public int CarId { get; private set; }

        public DealAddForm()
        {
            InitializeComponent();
            AddUsersInComboBox();
            AddCarsInComboBox();
        }

        private void AddUsersInComboBox()
        {
            RefreshUsersList();

            foreach(var u in _Users)
            {
                UsernameComboBox.Items.Add(u.Username);
            }
        }

        private void AddCarsInComboBox()
        {
            RefreshCarsList();

            foreach (var c in _Cars)
            {
                CarComboBox.Items.Add(c);
            }
        }

        private void RefreshUsersList()
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.GetUsersNotSuperUsers);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Success)
                {
                    _Users = (List<User>)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
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

        private void RefreshCarsList()
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.GetCars);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Success)
                {
                    _Cars = (List<Car>)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
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
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SetValues()
        {
            Username = (string)UsernameComboBox.SelectedItem;
            CarId = ((Car)CarComboBox.SelectedItem).CarId;
        }

        private void AddDealButton_Click(object sender, EventArgs e)
        {
            SetValues();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ClearValues()
        {
            UsernameComboBox.SelectedIndex = -1;
            CarComboBox.SelectedIndex = -1;
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
