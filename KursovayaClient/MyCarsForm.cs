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
    public partial class MyCarsForm : Form
    {
        private List<Car> _Cars = null;

        public MyCarsForm()
        {
            InitializeComponent();
            GetCurrentUserCars();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            ExitButton.Image = Properties.Resources.close_icon_colored;
        }
        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.Image = Properties.Resources.close_icon;
        }

        private void GetCurrentUserCars()
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.GetCurrentUserCars);

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

                if (_Cars != null)
                {
                    AddRowsInCarsTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK);
                Environment.Exit(0);
            }
        }
        private void AddRowsInCarsTable()
        {
            CarsTable.Rows.Clear();

            foreach (var item in _Cars)
            {
                CarsTable.Rows.Add(new object[]{
                            item.CarId,
                            item.Brand,
                            item.Model,
                            item.YearOfIssue,
                            Utilities.GetDescription(item.BodyType),
                            item.EngineVolume + " л",
                            Utilities.GetDescription(item.EngineType),
                            Utilities.GetDescription(item.TransmissionType),
                            Utilities.GetDescription(item.WheelDriveType),
                            item.Mileage + " км",
                            Utilities.GetDescription(item.BodyColor),
                            Utilities.GetDescription(item.InteriorMaterial),
                            Utilities.GetDescription(item.InteriorColor),
                        });
            }

            CarsTable.ClearSelection();
        }

    }
}
