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
    public partial class UserMainForm : Form
    {
        #region Members

        private List<Car> _Cars = null;
        private Autodealer _CurrentAutodealer = null;
        private bool _IsCarsFilteringEnabled = false;

        #endregion

        #region Constructors

        public UserMainForm()
        {
            InitializeComponent();

            RefreshCarsList();
            UpdateCurrentAutodealerLabel();
        }

        #endregion

        #region Refresh Cars List

        private void CarsRefreshButton_Click(object sender, EventArgs e)
        {
            RefreshCarsList();
        }
        private void RefreshCarsList()
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.GetNotSoldCars);

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
                            item.Price + " $",
                            "Купить"
                        });
            }

            CarsTable.ClearSelection();
        }

        #endregion

        #region ExitButton

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

        #endregion

        #region ChangeAutodealerButton

        private void ChangeAutodealerButton_Click(object sender, EventArgs e)
        {
            var AutodealerChooseForm = new AutodealerChooseForm();

            this.Hide();
            AutodealerChooseForm.Show();
        }

        #endregion

        #region AutodealerLabel

        private void UpdateCurrentAutodealerLabel()
        {
            GetCurrentAutodealer();
            CurrentAutodealerLabel.Text = "Текущий автосалон: " + _CurrentAutodealer.ToString();
        }
        private void GetCurrentAutodealer()
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.GetCurrentAutodealer);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Success)
                {
                    _CurrentAutodealer = (Autodealer)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
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

        #endregion

        #region FilterButton

        private void FilterButton_Click(object sender, EventArgs e)
        {
            if (!_IsCarsFilteringEnabled)
            {
                SetFilter();
            }
            else
            {
                ResetFilter();
            }
        }
        private void SetFilter()
        {
            using (var CarFilteringForm = new CarFilteringForm())
            {
                if (CarFilteringForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                        Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.SetCarFilter);

                        Connection.BinaryFormatter.Serialize(Connection.NetworkStream, CarFilteringForm.BrandFilter);
                        Connection.BinaryFormatter.Serialize(Connection.NetworkStream, CarFilteringForm.ModelFilter);
                        Connection.BinaryFormatter.Serialize(Connection.NetworkStream, CarFilteringForm.YearOfIssueMinFilter);
                        Connection.BinaryFormatter.Serialize(Connection.NetworkStream, CarFilteringForm.YearOfIssueMaxFilter);
                        Connection.BinaryFormatter.Serialize(Connection.NetworkStream, CarFilteringForm.BodyTypeFilter);
                        Connection.BinaryFormatter.Serialize(Connection.NetworkStream, CarFilteringForm.EngineVolumeMinFilter);
                        Connection.BinaryFormatter.Serialize(Connection.NetworkStream, CarFilteringForm.EngineVolumeMaxFilter);
                        Connection.BinaryFormatter.Serialize(Connection.NetworkStream, CarFilteringForm.EngineTypeFilter);
                        Connection.BinaryFormatter.Serialize(Connection.NetworkStream, CarFilteringForm.TransmissionTypeFilter);
                        Connection.BinaryFormatter.Serialize(Connection.NetworkStream, CarFilteringForm.WheelDriveTypeFilter);
                        Connection.BinaryFormatter.Serialize(Connection.NetworkStream, CarFilteringForm.MileageMinFilter);
                        Connection.BinaryFormatter.Serialize(Connection.NetworkStream, CarFilteringForm.MileageMaxFilter);
                        Connection.BinaryFormatter.Serialize(Connection.NetworkStream, CarFilteringForm.BodyColorFilter);
                        Connection.BinaryFormatter.Serialize(Connection.NetworkStream, CarFilteringForm.InteriorMaterialFilter);
                        Connection.BinaryFormatter.Serialize(Connection.NetworkStream, CarFilteringForm.InteriorColorFilter);
                        Connection.BinaryFormatter.Serialize(Connection.NetworkStream, CarFilteringForm.PriceMinFilter);
                        Connection.BinaryFormatter.Serialize(Connection.NetworkStream, CarFilteringForm.PriceMaxFilter);

                        var result = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                        if (result == MessageType.Error)
                        {
                            var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                            MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK);
                        }
                        else
                        {
                            FilterButton.Text = "Удалить фильр";
                            FilterButton.BackColor = Color.Tomato;
                            _IsCarsFilteringEnabled = true;
                            RefreshCarsList();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK);
                    }
                }
            }
        }
        private void ResetFilter()
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.ResetCarFilter);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Error)
                {
                    var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                    MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK);
                }
                else
                {
                    FilterButton.Text = "Установить фильтр";
                    _IsCarsFilteringEnabled = false;
                    RefreshCarsList();
                    FilterButton.BackColor = Color.FromArgb(78, 184, 206);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK);
            }
        }

        #endregion

        #region MyAccountLabel

        private void MyAccountLabel_MouseEnter(object sender, EventArgs e)
        {
            MyAccountLabel.Font = new Font("Century Gothic", 12, FontStyle.Underline);
            MyAccountLabel.ForeColor = Color.FromArgb(78, 184, 206);
            MyAccountLabel.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void MyAccountLabel_MouseLeave(object sender, EventArgs e)
        {
            MyAccountLabel.Font = new Font("Century Gothic", 12, FontStyle.Regular);
            MyAccountLabel.ForeColor = Color.White;
            MyAccountLabel.Cursor = System.Windows.Forms.Cursors.Default;
        }
        private void MyAccountLabel_Click(object sender, EventArgs e)
        {
            using (var myAccountForm = new MyAccountForm())
            {
                myAccountForm.ShowDialog();
            }
        }

        #endregion

        #region MyCarsLabel

        private void MyCarsLabel_MouseEnter(object sender, EventArgs e)
        {
            MyCarsLabel.Font = new Font("Century Gothic", 12, FontStyle.Underline);
            MyCarsLabel.ForeColor = Color.FromArgb(78, 184, 206);
            MyCarsLabel.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void MyCarsLabel_MouseLeave(object sender, EventArgs e)
        {
            MyCarsLabel.Font = new Font("Century Gothic", 12, FontStyle.Regular);
            MyCarsLabel.ForeColor = Color.White;
            MyCarsLabel.Cursor = System.Windows.Forms.Cursors.Default;
        }
        private void MyCarsLabel_Click(object sender, EventArgs e)
        {
            using (var myCarsForm = new MyCarsForm())
            {
                myCarsForm.ShowDialog();
            }
        }

        #endregion

        #region BuyCarButton

        private void CarsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 14)
            {
                BuyCarButton(e);
            }
        }
        private void BuyCarButton(DataGridViewCellEventArgs e)
        {
            var car = _Cars.FirstOrDefault(c => c.CarId == (int)CarsTable[0, e.RowIndex].Value);

            var MessageBoxResult = MessageBox.Show("Вы действительно хотите приобрести этот автомобиль?", "Покупка автомобиля", MessageBoxButtons.YesNo);

            if (MessageBoxResult == DialogResult.Yes)
            {
                BuyCar(car);
                RefreshCarsList();
            }
        }
        private void BuyCar(Car car)
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.BuyCar);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, car);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                MessageBox.Show(message, messageType == MessageType.Error ? "Ошибка!" : "Успешно!", MessageBoxButtons.OK);

                RefreshCarsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK);
            }
        }

        #endregion
    }
}
