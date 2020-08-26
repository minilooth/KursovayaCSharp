using Autodealers.Enums;
using Autodealers.Models;
using LiveCharts;
using LiveCharts.Wpf;
using ServerUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace KursovayaCSharp
{
    public partial class AdminMainForm : Form
    {
        #region Members

        #region Cars

        private List<Car> _Cars = null;

        private bool _IsCarsFilteringEnabled = false;

        #endregion

        #region Users

        private List<User> _Users = null;

        private User _CurrentUser = null;

        #endregion

        #region Autodealers

        private List<Autodealer> _Autodealers = null;
        private Autodealer _CurrentAutodealer = null;

        #endregion

        #region Deals

        private List<Deal> _Deals = null;

        #endregion

        #region Statistics

        private List<Statistics> _Statistics = null;

        #endregion

        #endregion

        #region Contructors

        public AdminMainForm()
        {
            InitializeComponent();

            UpdateCurrentAutodealerLabel();
            UpdateCurrentUserLabel();

            OpenCarsPanel();
        }

        #endregion

        #region TopPanel

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

        #region CurrentUserLabel

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
        private void UpdateCurrentUserLabel()
        {
            GetCurrentUser();
            CurrentUserLabel.Text = "Текущий пользователь: " + _CurrentUser.Username;
            if (_CurrentUser.Firstname != null && _CurrentUser.Surname != null)
            {
                CurrentUserLabel.Text += ", " + _CurrentUser.Surname + " " + _CurrentUser.Firstname[0] + ".";
            }
            if (_CurrentUser.Telephone != null)
            {
                CurrentUserLabel.Text += ", " + _CurrentUser.Telephone;
            }
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

        #endregion

        #region LeftPanel

        private void HideAllPanels()
        {
            CarsPanel.Visible = false;
            UsersPanel.Visible = false;
            DealsPanel.Visible = false;
            AutodealersPanel.Visible = false;
            StatisticsPanel.Visible = false;
            NotEnoughStatisticsPanel.Visible = false;
        }

        private void OpenCarsPanel()
        {
            HideAllPanels();
            CarsPanel.Visible = true;
            RefreshCarsList();
            CurrentMenuLabel.Text = "Панель управления автомобилями";
            CurrentMenuLabelPanel.Size = new Size(CurrentMenuLabel.Size.Width - 8, CurrentMenuLabelPanel.Size.Height);
        }

        private void OpenUsersPanel()
        {
            HideAllPanels();
            UsersPanel.Visible = true;
            RefreshUsersList();
            CurrentMenuLabel.Text = "Панель управления пользователями";
            CurrentMenuLabelPanel.Size = new Size(CurrentMenuLabel.Size.Width - 8, CurrentMenuLabelPanel.Size.Height);
        }

        private void OpenDealsPanel()
        {
            HideAllPanels();
            DealsPanel.Visible = true;
            RefreshDealsList();
            CurrentMenuLabel.Text = "Панель управления сделками";
            CurrentMenuLabelPanel.Size = new Size(CurrentMenuLabel.Size.Width - 8, CurrentMenuLabelPanel.Size.Height);
        }

        private void OpenAutodealersPanel()
        {
            HideAllPanels();
            AutodealersPanel.Visible = true;
            RefreshAutodealersList();
            CurrentMenuLabel.Text = "Панель управления автосалонами";
            CurrentMenuLabelPanel.Size = new Size(CurrentMenuLabel.Size.Width - 8, CurrentMenuLabelPanel.Size.Height);
        }

        private void OpenStatisticsPanel()
        {
            HideAllPanels();
            StatisticsPanel.Visible = true;
            RefreshStatisticsData();
            CurrentMenuLabel.Text = "Панель управления статистикой";
            CurrentMenuLabelPanel.Size = new Size(CurrentMenuLabel.Size.Width - 8, CurrentMenuLabelPanel.Size.Height);
        }

        private void CarsButton_Click(object sender, EventArgs e)
        {
            CurrentMenuBrick.Location = new Point(CarsButton.Location.X - 15, CarsButton.Location.Y);
            OpenCarsPanel();
        }

        private void UsersButton_Click(object sender, EventArgs e)
        {
            CurrentMenuBrick.Location = new Point(UsersButton.Location.X - 15, UsersButton.Location.Y);
            OpenUsersPanel();
        }

        private void DealsButton_Click(object sender, EventArgs e)
        {
            CurrentMenuBrick.Location = new Point(DealsButton.Location.X - 15, DealsButton.Location.Y);
            OpenDealsPanel();
        }

        private void AutodealersButton_Click(object sender, EventArgs e)
        {
            CurrentMenuBrick.Location = new Point(AutodealersButton.Location.X - 15, AutodealersButton.Location.Y);
            OpenAutodealersPanel();
        }

        private void StatisticsButton_Click(object sender, EventArgs e)
        {
            CurrentMenuBrick.Location = new Point(StatisticsButton.Location.X - 15, StatisticsButton.Location.Y);
            OpenStatisticsPanel();
        }

        #endregion

        #region CarsPanel

        #region CarsRefreshButton

        private void CarsRefreshButton_Click(object sender, EventArgs e)
        {
            RefreshCarsList();
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
                            item.IsSold ? "Да" : "Нет",
                            "Удалить",
                            "Редактировать"
                        });

                if (item.IsSold && item.Deal.Count > 0)
                {
                    ((DataGridViewDisableButtonCell)CarsTable.Rows[CarsTable.Rows.Count - 1].Cells[15]).Enabled = false;
                    ((DataGridViewDisableButtonCell)CarsTable.Rows[CarsTable.Rows.Count - 1].Cells[16]).Enabled = false;
                }
                else
                {
                    ((DataGridViewDisableButtonCell)CarsTable.Rows[CarsTable.Rows.Count - 1].Cells[15]).Enabled = true;
                    ((DataGridViewDisableButtonCell)CarsTable.Rows[CarsTable.Rows.Count - 1].Cells[16]).Enabled = true;
                }
            }


            CarsTable.ClearSelection();
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

        #region CarAddButton

        private void CarAddButton_Click(object sender, EventArgs e)
        {
            bool IsAdded = false;
            bool IsCanceled = false;

            using (var CarAddForm = new CarAddForm())
            {
                while (!IsAdded && !IsCanceled)
                {
                    CarAddForm.ShowDialog();
                    if (CarAddForm.DialogResult == DialogResult.OK)
                    {
                        var car = new Car();

                        car.Brand = CarAddForm.Brand;
                        car.Model = CarAddForm.Model;
                        car.YearOfIssue = CarAddForm.YearOfIssue;
                        car.BodyType = CarAddForm.BodyType;
                        car.EngineVolume = CarAddForm.EngineVolume;
                        car.EngineType = CarAddForm.EngineType;
                        car.TransmissionType = CarAddForm.TransmissionType;
                        car.WheelDriveType = CarAddForm.WheelDriveType;
                        car.Mileage = CarAddForm.Mileage;
                        car.BodyColor = CarAddForm.BodyColor;
                        car.InteriorMaterial = CarAddForm.InteriorMaterial;
                        car.InteriorColor = CarAddForm.InteriorColor;
                        car.Price = CarAddForm.Price;

                        IsAdded = AddCar(car);

                        if (IsAdded)
                        {
                            RefreshCarsList();
                        }
                    }
                    if (CarAddForm.DialogResult == DialogResult.Cancel)
                    {
                        IsCanceled = true;
                    }
                }
            }
        }

        private bool AddCar(Car car)
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.AddCar);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, car);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Error)
                {
                    MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK);
                    return false;
                }
                else
                {
                    MessageBox.Show(message, "Цена рассчитана.", MessageBoxButtons.OK);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK);
                Environment.Exit(0);
                return false;
            }
        }

        #endregion

        #region CarEdit and CarDelete

        private void CarsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 15)
            {
                if (((DataGridViewDisableButtonCell)CarsTable.Rows[e.RowIndex].Cells[15]).Enabled == true)
                {
                    CarDeleteButton(e);
                }
            }
            if (e.ColumnIndex == 16)
            {
                if (((DataGridViewDisableButtonCell)CarsTable.Rows[e.RowIndex].Cells[15]).Enabled == true)
                {
                    CarEditButton(e);
                }
            }
        }
        private void CarDeleteButton(DataGridViewCellEventArgs e)
        {
            var car = _Cars.FirstOrDefault(c => c.CarId == (int)CarsTable[0, e.RowIndex].Value);

            var MessageBoxResult = MessageBox.Show("Вы действительно хотите удалить?", "Удаление автомобиля", MessageBoxButtons.YesNo);

            if (MessageBoxResult == DialogResult.Yes)
            {
                DeleteCar(car);
                RefreshCarsList();
            }
        }
        private void CarEditButton(DataGridViewCellEventArgs e)
        {
            bool IsEdited = false;
            bool IsClosed = false;
            var car = _Cars.FirstOrDefault(c => c.CarId == (int)CarsTable[0, e.RowIndex].Value);

            using (var CarEditForm = new CarEditForm(car))
            {
                while (!IsEdited && !IsClosed)
                {
                    CarEditForm.ShowDialog();
                    if (CarEditForm.DialogResult == DialogResult.OK)
                    {
                        car.Brand = CarEditForm.Brand;
                        car.Model = CarEditForm.Model;
                        car.YearOfIssue = CarEditForm.YearOfIssue;
                        car.BodyType = CarEditForm.BodyType;
                        car.EngineVolume = CarEditForm.EngineVolume;
                        car.EngineType = CarEditForm.EngineType;
                        car.TransmissionType = CarEditForm.TransmissionType;
                        car.WheelDriveType = CarEditForm.WheelDriveType;
                        car.Mileage = CarEditForm.Mileage;
                        car.BodyColor = CarEditForm.BodyColor;
                        car.InteriorColor = CarEditForm.InteriorColor;
                        car.InteriorMaterial = CarEditForm.InteriorMaterial;
                        car.Price = CarEditForm.Price;

                        IsEdited = EditCar(car);

                        if (IsEdited)
                        {
                            RefreshCarsList();
                        }
                    }
                    if (CarEditForm.DialogResult == DialogResult.Cancel)
                    {
                        IsClosed = true;
                    }
                }
            }
        }
        private void DeleteCar(Car car)
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.DeleteCar);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, car);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Error)
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
        private bool EditCar(Car car)
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.EditCar);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, car);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                MessageBox.Show(message, messageType == MessageType.Error ? "Ошибка!" : "Цена рассчитана.", MessageBoxButtons.OK);
                return messageType == MessageType.Success ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK);
                return false;
            }
        }

        #endregion

        #region CarsFiltering
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

        #endregion

        #region UsersPanel

        #region RefreshUsersButton

        private void RefreshUsersList()
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.GetUsers);

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

                if (_Users != null)
                {
                    AddRowsInUsersTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK);
                Environment.Exit(0);
            }
        }
        private void AddRowsInUsersTable()
        {
            UsersTable.Rows.Clear();

            foreach (var item in _Users)
            {
                UsersTable.Rows.Add(new object[]{
                            item.UserId,
                            item.Username,
                            ShowUsersPasswordsCheckBox.Checked ? item.Password : new string('•', item.Password.Length),
                            item.Firstname,
                            item.Surname,
                            item.Telephone,
                            item.DateOfRegistration,
                            item.SuperUser ? "Администратор" : "Пользователь",
                            item.BanStatus ? "Да" : "Нет",
                            item.BanStatus ? "Разблокировать" : "Заблокировать",
                            "Удалить",
                            "Редактировать"
                        });

                if (item.BanStatus)
                {
                    UsersTable.Rows[UsersTable.RowCount - 1].Cells[9].Style.BackColor = Color.Tomato;
                    UsersTable.Rows[UsersTable.RowCount - 1].Cells[9].Style.SelectionBackColor = Color.Tomato;
                }
            }

            UsersTable.ClearSelection();
        }
        private void RefreshUsersButton_Click(object sender, EventArgs e)
        {
            RefreshUsersList();
        }

        #endregion

        #region AddUserButton

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            bool IsAdded = false;
            bool IsCanseled = false;

            using (var UserAddForm = new UserAddForm())
            {
                while (!IsAdded && !IsCanseled)
                {
                    UserAddForm.ShowDialog();
                    if (UserAddForm.DialogResult == DialogResult.OK)
                    {
                        var user = new User
                        {
                            Username = UserAddForm.Username,
                            Password = UserAddForm.Password,
                            Firstname = UserAddForm.Firstname,
                            Surname = UserAddForm.Surname,
                            Telephone = UserAddForm.Telephone,
                            SuperUser = UserAddForm.SuperUser,
                            BanStatus = UserAddForm.BanStatus
                        };

                        IsAdded = AddUser(user);

                        if (IsAdded)
                        {
                            RefreshUsersList();
                        }
                    }
                    if (UserAddForm.DialogResult == DialogResult.Cancel)
                    {
                        IsCanseled = true;
                    }
                }
            }
        }
        private bool AddUser(User user)
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.AddUser);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, user);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Error)
                {
                    var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                    MessageBox.Show("Ошибка!", message, MessageBoxButtons.OK);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!", ex.Message, MessageBoxButtons.OK);
                Environment.Exit(0);
                return false;
            }
        }

        #endregion

        #region UserEdit, UserDelete and UserBanUnban Buttons

        private void UsersTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                BanUnbanUserButton(e);
            }
            if (e.ColumnIndex == 10)
            {
                DeleteUserButton(e);
            }
            if (e.ColumnIndex == 11)
            {
                EditUserButton(e);
            }
        }
        private void BanUnbanUserButton(DataGridViewCellEventArgs e)
        {
            var user = _Users.FirstOrDefault(u => u.UserId == (int)UsersTable[0, e.RowIndex].Value);

            var MessageBoxResult = MessageBox.Show("Вы действительно хотите " + (user.BanStatus ? "разблокировать" : "заблокировать") + " пользователя?", (!user.BanStatus ? "Блокировка" : "Разблокировка") + " пользователя", MessageBoxButtons.YesNo);

            if (MessageBoxResult == DialogResult.Yes)
            {
                BanUnbanUser(user);
                RefreshUsersList();
            }
        }
        private void DeleteUserButton(DataGridViewCellEventArgs e)
        {
            var user = _Users.FirstOrDefault(u => u.UserId == (int)UsersTable[0, e.RowIndex].Value);

            var MessageBoxResult = MessageBox.Show("Вы действительно хотите удалить пользователя?", "Удаление пользователя", MessageBoxButtons.YesNo);

            if (MessageBoxResult == DialogResult.Yes)
            {
                DeleteUser(user);
                RefreshUsersList();
            }
        }
        private void EditUserButton(DataGridViewCellEventArgs e)
        {
            bool IsEdited = false;
            bool IsClosed = false;
            var user = _Users.FirstOrDefault(u => u.UserId == (int)UsersTable[0, e.RowIndex].Value);

            using (var UserEditForm = new UserEditForm(user))
            {
                while (!IsEdited && !IsClosed)
                {
                    UserEditForm.ShowDialog();
                    if (UserEditForm.DialogResult == DialogResult.OK)
                    {

                        user.Username = UserEditForm.Username;
                        user.Password = UserEditForm.Password;
                        user.Firstname = UserEditForm.Firstname;
                        user.Surname = UserEditForm.Surname;
                        user.Telephone = UserEditForm.Telephone;
                        user.SuperUser = UserEditForm.SuperUser;
                        user.BanStatus = UserEditForm.BanStatus;

                        IsEdited = EditUser(user);

                        if (IsEdited)
                        {
                            RefreshUsersList();
                            UpdateCurrentUserLabel();
                        }
                    }
                    if (UserEditForm.DialogResult == DialogResult.Cancel)
                    {
                        IsClosed = true;
                    }
                }
            }
        }
        private void BanUnbanUser(User user)
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.BanUnbanUser);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, user);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Error)
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
        private void DeleteUser(User user)
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.DeleteUser);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, user);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Error)
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
        private bool EditUser(User user)
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.EditUser);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, user);

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

        #endregion

        #region SearchMode

        private void UserSearchModeTextBox_TextChanged(object sender, EventArgs e)
        {
            SendUserSearchInfo();
            RefreshUsersList();
        }
        private void SendUserSearchInfo()
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.SetUserSearchData);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, UserSearchModeTextBox.Text);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Error)
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
        private void UserSearchModeTextBox_Enter(object sender, EventArgs e)
        {
            UserSearchModeTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            UserSearchPictureBox.Image = Properties.Resources.search_icon_colored;
            UserSearchModePanel.BackColor = Color.FromArgb(78, 184, 206);

            if (UserSearchModeTextBox.Text == "Поиск по логину")
            {
                UserSearchModeTextBox.Clear();
            }
        }
        private void UserSearchModeTextBox_Leave(object sender, EventArgs e)
        {
            UserSearchModeTextBox.ForeColor = Color.White;
            UserSearchPictureBox.Image = Properties.Resources.search_icon;
            UserSearchModePanel.BackColor = Color.White;

            if (UserSearchModeTextBox.Text == "")
            {
                UserSearchModeTextBox.Text = "Поиск по логину";
            }
        }

        #endregion

        #region ShowPasswordsCheckBox

        private void ShowUsersPasswordsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RefreshUsersList();
        }

        #endregion

        #endregion

        #region DealsPanel

        #region RefreshButton

        private void RefreshDealsList()
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.GetDeals);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Success)
                {
                    _Deals = (List<Deal>)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                }
                else
                {
                    var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                    MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK);
                }

                if (_Deals != null)
                {
                    AddRowsInDealsTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK);
                Environment.Exit(0);
            }
        }
        private void AddRowsInDealsTable()
        {
            DealsTable.Rows.Clear();

            foreach (var d in _Deals)
            {
                DealsTable.Rows.Add(new object[]
                {
                    d.DealId,
                    d.User.Username,
                    d.Amount + " $",
                    d.Date,
                    d.Car.Brand + " " + d.Car.Model,
                    d.CarId,
                    d.IsConfirmed ? "Да" : "Нет",
                    "Подтвердить",
                    "Удалить",
                    "Редактировать"
                });


                if (d.IsConfirmed)
                {
                    ((DataGridViewDisableButtonCell)DealsTable.Rows[DealsTable.Rows.Count - 1].Cells[7]).Enabled = false;
                }
            }

            DealsTable.ClearSelection();
        }
        private void RefreshDealsButton_Click(object sender, EventArgs e)
        {
            RefreshDealsList();
        }

        #endregion

        #region DealEdit, DealConfirm and DealDelete Buttons

        private void DealsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (((DataGridViewDisableButtonCell)DealsTable.Rows[e.RowIndex].Cells[7]).Enabled == true)
                {
                    ConfirmDealButton(e);

                    ((DataGridViewDisableButtonCell)DealsTable.Rows[e.RowIndex].Cells[7]).Enabled = false;

                    DealsPanel.Refresh();
                }
            }
            if (e.ColumnIndex == 8)
            {
                DeleteDealButton(e);
            }
            if (e.ColumnIndex == 9)
            {
                EditDealButton(e);
            }
        }
        private void ConfirmDealButton(DataGridViewCellEventArgs e)
        {
            var deal = _Deals.FirstOrDefault(d => d.DealId == (int)DealsTable[0, e.RowIndex].Value);

            var MessageBoxResult = MessageBox.Show("Вы действительно хотите подтвердить сделку?", "Подтверждение сделки", MessageBoxButtons.YesNo);

            if (MessageBoxResult == DialogResult.Yes)
            {
                ConfirmDeal(deal);
                RefreshDealsList();
            }
        }
        private void ConfirmDeal(Deal deal)
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.ConfirmDeal);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, deal);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Error)
                {
                    var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                    MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK);
                }

                var statisticsMessageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (statisticsMessageType == MessageType.Error)
                {
                    var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                    MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK);
                }

                var checkMessageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (checkMessageType == MessageType.Success)
                {
                    var check = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                    string path = CreateCheckFile(check);
                    MessageBox.Show(path == null ? "Ошибка получение чека продажи!" : ("Чек сохранен по адресу: " + path), path == null ? "Ошибка!" : "Чек продажи.", MessageBoxButtons.OK);
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
        private string CreateCheckFile(string check)
        {
            string path = Directory.GetCurrentDirectory() + @"\Checks";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            path += @"\" + DateTime.Now.ToString("d") + @"\";

            directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            path += $"{DateTime.Now.Hour}.{DateTime.Now.Minute}.{DateTime.Now.Second}" + ".txt";

            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    streamWriter.Write(check);
                }
                return path;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK);
            }
            return null;
        }
        private void DeleteDealButton(DataGridViewCellEventArgs e)
        {
            var deal = _Deals.FirstOrDefault(d => d.DealId == (int)DealsTable[0, e.RowIndex].Value);

            var MessageBoxResult = MessageBox.Show("Вы действительно хотите удалить сделку?", "Удаление сделки", MessageBoxButtons.YesNo);

            if (MessageBoxResult == DialogResult.Yes)
            {
                DeleteDeal(deal);
                RefreshDealsList();
            }
        }
        private void DeleteDeal(Deal deal)
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.DeleteDeal);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, deal);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Error)
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
        private void EditDealButton(DataGridViewCellEventArgs e)
        {
            bool IsEdited = false;
            bool IsCanseled = false;

            RefreshCarsList();
            RefreshUsersList();

            var deal = _Deals.FirstOrDefault(d => d.DealId == (int)DealsTable[0, e.RowIndex].Value);

            using (var DealEditForm = new DealEditForm(deal))
            {
                while (!IsEdited && !IsCanseled)
                {
                    DealEditForm.ShowDialog();
                    if (DealEditForm.DialogResult == DialogResult.OK)
                    {
                        var user = _Users.FirstOrDefault(u => u.Username == DealEditForm.Username);

                        deal.UserId = user == null ? 0 : user.UserId;
                        deal.CarId = DealEditForm.CarId;

                        IsEdited = EditDeal(deal);

                        if (IsEdited)
                        {
                            RefreshDealsList();
                        }
                    }
                    if (DealEditForm.DialogResult == DialogResult.Cancel)
                    {
                        IsCanseled = true;
                    }
                }
            }
        }
        private bool EditDeal(Deal deal)
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.EditDeal);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, deal);

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

        #endregion

        #region AddDeal Button

        private void AddDealButton_Click(object sender, EventArgs e)
        {
            bool IsAdded = false;
            bool IsCanseled = false;

            RefreshCarsList();
            RefreshUsersList();

            using (var DealAddForm = new DealAddForm())
            {
                while (!IsAdded && !IsCanseled)
                {
                    DealAddForm.ShowDialog();
                    if (DealAddForm.DialogResult == DialogResult.OK)
                    {
                        var deal = new Deal();

                        var user = _Users.FirstOrDefault(u => u.Username == DealAddForm.Username);

                        deal.UserId = user == null ? 0 : user.UserId;
                        deal.CarId = DealAddForm.CarId;

                        IsAdded = AddDeal(deal);

                        if (IsAdded)
                        {
                            RefreshDealsList();
                        }
                    }
                    if (DealAddForm.DialogResult == DialogResult.Cancel)
                    {
                        IsCanseled = true;
                    }
                }
            }
        }
        private bool AddDeal(Deal deal)
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.AddDeal);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, deal);

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
                Environment.Exit(0);
                return false;
            }
        }

        #endregion

        #region DealSearch

        private void DealSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            SetDealSearchData();
            RefreshDealsList();
        }

        private void DealSearchTextBox_Enter(object sender, EventArgs e)
        {
            DealSearchTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            DealSearchPictureBox.Image = Properties.Resources.search_icon_colored;
            DealSearchPanel.BackColor = Color.FromArgb(78, 184, 206);

            if (DealSearchTextBox.Text == "Поиск по логину")
            {
                DealSearchTextBox.Clear();
            }
        }

        private void DealSearchTextBox_Leave(object sender, EventArgs e)
        {
            DealSearchTextBox.ForeColor = Color.White;
            DealSearchPictureBox.Image = Properties.Resources.search_icon;
            DealSearchPanel.BackColor = Color.White;

            if (DealSearchTextBox.Text == "")
            {
                DealSearchTextBox.Text = "Поиск по логину";
            }
        }

        private void SetDealSearchData()
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.SetDealSearchData);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, DealSearchTextBox.Text);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Error)
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

        #endregion

        #endregion

        #region AutodealersPanel

        #region RefreshButton

        private void RefreshAutodealersList()
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.GetAutodealers);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Success)
                {
                    _Autodealers = (List<Autodealer>)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                }
                else
                {
                    var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                    MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK);
                }

                if (_Autodealers != null)
                {
                    AddRowsInAutodealersTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK);
                Environment.Exit(0);
            }
        }
        private void AddRowsInAutodealersTable()
        {
            AutodealersTable.Rows.Clear();

            foreach (var a in _Autodealers)
            {
                AutodealersTable.Rows.Add(new object[]
                {
                    a.AutodealerId,
                    a.Title,
                    a.WorkingHours,
                    a.City,
                    a.Address,
                    "Удалить",
                    "Редактировать"
                });
            }

            AutodealersTable.ClearSelection();
        }
        private void AutodealersRefreshButton_Click(object sender, EventArgs e)
        {
            RefreshAutodealersList();
        }

        #endregion

        #region AutodealerAddButton

        private void AutodealerAddButton_Click(object sender, EventArgs e)
        {
            bool IsAdded = false;
            bool IsCanseled = false;

            using (var AutodealerAddForm = new AutodealerAddForm())
            {
                while (!IsAdded && !IsCanseled)
                {
                    AutodealerAddForm.ShowDialog();
                    if (AutodealerAddForm.DialogResult == DialogResult.OK)
                    {
                        var autodealer = new Autodealer();

                        autodealer.Title = AutodealerAddForm.Title;
                        autodealer.WorkingHours = AutodealerAddForm.WorkingHours;
                        autodealer.City = AutodealerAddForm.City;
                        autodealer.Address = AutodealerAddForm.Address;

                        IsAdded = AddAutodealer(autodealer);

                        if (IsAdded)
                        {
                            RefreshAutodealersList();
                        }
                    }
                    if (AutodealerAddForm.DialogResult == DialogResult.Cancel)
                    {
                        IsCanseled = true;
                    }
                }
            }
        }
        private bool AddAutodealer(Autodealer autodealer)
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.AddAutodealer);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, autodealer);

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
                Environment.Exit(0);
                return false;
            }
        }

        #endregion

        #region AutodealerDeleteButton and AutodealerEditButton

        private void AutodealersTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                AutodealerDeleteButton(e);
            }
            if (e.ColumnIndex == 6)
            {
                AutodealerEditButton(e);
            }
        }
        private void AutodealerDeleteButton(DataGridViewCellEventArgs e)
        {
            var autodealer = _Autodealers.FirstOrDefault(a => a.AutodealerId == (int)AutodealersTable[0, e.RowIndex].Value);

            var MessageBoxResult = MessageBox.Show("Вы действительно хотите удалить автосалон?", "Удаление автосалона", MessageBoxButtons.YesNo);

            if (MessageBoxResult == DialogResult.Yes)
            {
                DeleteAutodealer(autodealer);
                RefreshAutodealersList();
            }
        }
        private void DeleteAutodealer(Autodealer autodealer)
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.DeleteAutodealer);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, autodealer);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Error)
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
        private void AutodealerEditButton(DataGridViewCellEventArgs e)
        {
            bool IsEdited = false;
            bool IsCanseled = false;

            var autodealer = _Autodealers.FirstOrDefault(a => a.AutodealerId == (int)AutodealersTable[0, e.RowIndex].Value);

            using (var AutodealerEditForm = new AutodealerEditForm(autodealer))
            {
                while (!IsEdited && !IsCanseled)
                {
                    AutodealerEditForm.ShowDialog();
                    if (AutodealerEditForm.DialogResult == DialogResult.OK)
                    {
                        autodealer.Title = AutodealerEditForm.Title;
                        autodealer.WorkingHours = AutodealerEditForm.WorkingHours;
                        autodealer.City = AutodealerEditForm.City;
                        autodealer.Address = AutodealerEditForm.Address;

                        IsEdited = EditAutodealer(autodealer);

                        if (IsEdited)
                        {
                            RefreshAutodealersList();
                            UpdateCurrentAutodealerLabel();
                        }
                    }
                    if (AutodealerEditForm.DialogResult == DialogResult.Cancel)
                    {
                        IsCanseled = true;
                    }
                }
            }
        }
        private bool EditAutodealer(Autodealer autodealer)
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.EditAutodealer);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, autodealer);

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

        #endregion

        #region SearchMode

        private void AutodealerSearchTextBox_Enter(object sender, EventArgs e)
        {
            AutodealerSearchTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            AutodealerSearchPictureBox.Image = Properties.Resources.search_icon_colored;
            AutodealerSearchPanel.BackColor = Color.FromArgb(78, 184, 206);

            if (AutodealerSearchTextBox.Text == "Поиск по названию")
            {
                AutodealerSearchTextBox.Clear();
            }
        }
        private void AutodealerSearchTextBox_Leave(object sender, EventArgs e)
        {
            AutodealerSearchTextBox.ForeColor = Color.White;
            AutodealerSearchPictureBox.Image = Properties.Resources.search_icon;
            AutodealerSearchPanel.BackColor = Color.White;

            if (AutodealerSearchTextBox.Text == "")
            {
                AutodealerSearchTextBox.Text = "Поиск по названию";
            }
        }
        private void AutodealerSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            SendAutodealersSearchData();
            RefreshAutodealersList();
        }
        private void SendAutodealersSearchData()
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.SetAutodealerSearchData);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, AutodealerSearchTextBox.Text);
            
                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Error)
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

        #endregion

        #endregion

        #region StatisticsPanel

        #region RefreshButton

        private void RefreshStatisticsData()
        {
            try
            {
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, MessageType.Action);
                Connection.BinaryFormatter.Serialize(Connection.NetworkStream, ActionType.GetCurrentAutodealerStatistics);

                var messageType = (MessageType)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);

                if (messageType == MessageType.Success)
                {
                    _Statistics = (List<Statistics>)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                    _Statistics.Reverse();
                }
                else
                {
                    var message = (string)Connection.BinaryFormatter.Deserialize(Connection.NetworkStream);
                    MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK);
                }

                if (_Statistics != null && _Statistics.Count != 0)
                {
                    AddDataToCharts();
                }
                else
                {
                    StatisticsPanel.Visible = false;
                    NotEnoughStatisticsPanel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK);
                Environment.Exit(0);
            }
        }
        private void AddDataToCharts()
        {
            UpdateCountOfCarsSoldChart();
            UpdateProfitChart();
            UpdateCountOfClientsChart();
            UpdateTotalSalesChart();
        }
        private void StatisticsRefreshButton_Click(object sender, EventArgs e)
        {
            RefreshStatisticsData();
        }

        #endregion

        #region ChartsUpdate

        private void UpdateCountOfCarsSoldChart()
        {
            var CountOfCarsSoldLineSeries = new LineSeries();
            var CountOfCarsSoldChartValues = new ChartValues<int>();
            CountOfCarsSoldLineSeries.Title = "Количество проданных автомобилей";
            foreach (var s in _Statistics)
            {
                CountOfCarsSoldChartValues.Add(s.CountOfCarsSold);
            }
            CountOfCarsSoldLineSeries.Values = CountOfCarsSoldChartValues;
            CountOfCarsSoldLineSeries.LineSmoothness = 1;

            var ExpectedCountOfCarsSoldLineSeries = new LineSeries();
            var ExpectedCountOfCarsSoldChartValues = new ChartValues<int>();
            ExpectedCountOfCarsSoldLineSeries.Title = "Ожидаемое количество проданных автомобилей";
            foreach (var s in _Statistics)
            {
                ExpectedCountOfCarsSoldChartValues.Add(s.ExpectedCountOfCarsSold);
            }
            ExpectedCountOfCarsSoldLineSeries.Values = ExpectedCountOfCarsSoldChartValues;
            ExpectedCountOfCarsSoldLineSeries.LineSmoothness = 1;

            CountOfCarsSoldCartesianChart.Series.Clear();
            CountOfCarsSoldCartesianChart.Series = new LiveCharts.SeriesCollection
            {
                CountOfCarsSoldLineSeries,
                ExpectedCountOfCarsSoldLineSeries
            };

            var CountOfCarsSoldAxisX = new Axis();
            CountOfCarsSoldAxisX.Title = "Месяц";
            CountOfCarsSoldAxisX.Labels = new List<string>();
            foreach (var s in _Statistics)
            {
                CountOfCarsSoldAxisX.Labels.Add(Utilities.GetDescription<Month>(s.Month));
            }

            var CountOfCarsSoldAxisY = new Axis()
            {
                Title = "Количество",
                LabelFormatter = value => value.ToString()
            };

            DefaultLegend customLegend = new DefaultLegend();
            customLegend.BulletSize = 15;
            customLegend.Foreground = System.Windows.Media.Brushes.White;
            customLegend.Orientation = System.Windows.Controls.Orientation.Horizontal;

            CountOfCarsSoldCartesianChart.AxisX.Clear();
            CountOfCarsSoldCartesianChart.AxisX.Add(CountOfCarsSoldAxisX);
            CountOfCarsSoldCartesianChart.AxisY.Clear();
            CountOfCarsSoldCartesianChart.AxisY.Add(CountOfCarsSoldAxisY);
            CountOfCarsSoldCartesianChart.DefaultLegend = customLegend;
            CountOfCarsSoldCartesianChart.LegendLocation = LegendLocation.Bottom;
        }
        private void UpdateProfitChart()
        {
            var ProfitChartValues = new ChartValues<decimal>();
            foreach(var s in _Statistics)
            {
                ProfitChartValues.Add(s.Profit);
            }

            var ProfitLineSeries = new LineSeries();
            ProfitLineSeries.Title = "Прибыль";
            ProfitLineSeries.Values = ProfitChartValues;
            ProfitLineSeries.LineSmoothness = 1;


            var ExpectedProfitChartValues = new ChartValues<decimal>();
            foreach(var s in _Statistics)
            {
                ExpectedProfitChartValues.Add(s.ExpectedProfit);
            }

            var ExpectedProfitLineSeries = new LineSeries();
            ExpectedProfitLineSeries.Title = "Ожидаемая прибыль";
            ExpectedProfitLineSeries.Values = ExpectedProfitChartValues;
            ExpectedProfitLineSeries.LineSmoothness = 1;

            ProfitCartesianChart.Series.Clear();
            ProfitCartesianChart.Series = new SeriesCollection()
            {
                ProfitLineSeries,
                ExpectedProfitLineSeries
            };

            var ProfitAxisX = new Axis();
            ProfitAxisX.Title = "Месяц";
            ProfitAxisX.Labels = new List<string>();
            foreach (var s in _Statistics)
            {
                ProfitAxisX.Labels.Add(Utilities.GetDescription<Month>(s.Month));
            }

            var ProfitAxisY = new Axis()
            {
                Title = "Прибыль",
                LabelFormatter = value => value.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))
            };

            DefaultLegend customLegend = new DefaultLegend();
            customLegend.BulletSize = 15;
            customLegend.Foreground = System.Windows.Media.Brushes.White;
            customLegend.Orientation = System.Windows.Controls.Orientation.Horizontal;

            ProfitCartesianChart.AxisX.Clear();
            ProfitCartesianChart.AxisX.Add(ProfitAxisX);
            ProfitCartesianChart.AxisY.Clear();
            ProfitCartesianChart.AxisY.Add(ProfitAxisY);
            ProfitCartesianChart.DefaultLegend = customLegend;
            ProfitCartesianChart.LegendLocation = LegendLocation.Bottom;
        }
        private void UpdateCountOfClientsChart()
        {
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            CountOfClientsPieChart.Series.Clear();
            CountOfClientsPieChart.Series = new SeriesCollection();
            foreach(var s in _Statistics)
            {
                var pieSeries = new PieSeries
                {
                    Title = Utilities.GetDescription<Month>(s.Month),
                    Values = new ChartValues<int> { s.CountOfClients },
                    DataLabels = true,
                    LabelPoint = labelPoint
                };
                CountOfClientsPieChart.Series.Add(pieSeries);
            }

            DefaultLegend customLegend = new DefaultLegend();
            customLegend.BulletSize = 15;
            customLegend.Foreground = System.Windows.Media.Brushes.White;
            customLegend.Orientation = System.Windows.Controls.Orientation.Horizontal;

            CountOfClientsPieChart.DefaultLegend = customLegend;
            CountOfClientsPieChart.LegendLocation = LegendLocation.Bottom;
        }
        private void UpdateTotalSalesChart()
        {
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0}$ ({1:P})", chartPoint.Y, chartPoint.Participation );

            TotalSalesPieChart.Series.Clear();
            TotalSalesPieChart.Series = new SeriesCollection();
            foreach (var s in _Statistics)
            {
                var pieSeries = new PieSeries
                {
                    Title = Utilities.GetDescription<Month>(s.Month),
                    Values = new ChartValues<decimal> { s.TotalSales },
                    DataLabels = true,
                    LabelPoint = labelPoint
                };
                TotalSalesPieChart.Series.Add(pieSeries);
            }

            DefaultLegend customLegend = new DefaultLegend();
            customLegend.BulletSize = 15;
            customLegend.Foreground = System.Windows.Media.Brushes.White;
            customLegend.Orientation = System.Windows.Controls.Orientation.Horizontal;

            TotalSalesPieChart.DefaultLegend = customLegend;
            TotalSalesPieChart.LegendLocation = LegendLocation.Bottom;
        }

        #endregion

        #endregion

    }
}
