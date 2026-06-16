using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PCC_App;
using PCC_App.BusinessLogic;
using PCC_App.BusinessLogic;
using PCC_App.DataAccess;

namespace PCC_App
{
    public partial class CabinetForm : Form
    {
        private readonly int _currentUserId;
        private readonly AppLogic _logic;
        private void CabinetForm_Load(object sender, EventArgs e)
        {
            RefreshUserData();
        }
        public CabinetForm(int userId, string connectionString)
        {
            InitializeComponent();
            _currentUserId = userId;
            _logic = new AppLogic(connectionString);
            RefreshUserData();
            LoadHalls();
        }
        private void RefreshUserData()
        {
            // Берем актуальные данные из БД (через скрытый DatabaseHelper)
            User currentUser = _logic.GetUserById(_currentUserId);

            if (currentUser != null)
            {
                lblNickname.Text = currentUser.Nickname;
                lblBalance.Text = currentUser.Balance.ToString() + " руб.";
            }
        }

        private void btnTopUp_Click(object sender, EventArgs e)
        {
            // 1. Проверяем, что юзер ввел число, а не буквы
            if (int.TryParse(txtTopUpAmount.Text, out int amount))
            {
                // 2. Отдаем работу нашему "мозгу"
                string resultMessage = _logic.TopUpBalance(_currentUserId, amount);

                // 3. Выводим ответ (успех или ошибку)
                MessageBox.Show(resultMessage, "Касса", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Обновляем баланс на экране и очищаем поле ввода
                RefreshUserData();
                txtTopUpAmount.Clear();
            }
            else
            {
                MessageBox.Show("Братишка, введи нормальное число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LoadSessionHistory()
        {
            try
            {
                // Вызываем логику. Она вернет List<Session>
                var history = _logic.GetHistory(_currentUserId);

                // Привязываем список к таблице
                // Важно: dgvHistory — это имя (Name) твоего DataGridView в дизайнере!
                dgvHistory.DataSource = null; // Сбрасываем старые данные
                dgvHistory.DataSource = history;

                // Настройка колонок (делаем красиво)
                if (dgvHistory.Columns.Count > 0)
                {
                    if (dgvHistory.Columns["Id"] != null) dgvHistory.Columns["Id"].Visible = false;
                    if (dgvHistory.Columns["UserNickname"] != null) dgvHistory.Columns["UserNickname"].HeaderText = "Игрок";
                    if (dgvHistory.Columns["PcNumber"] != null) dgvHistory.Columns["PcNumber"].HeaderText = "ПК №";
                    if (dgvHistory.Columns["HallType"] != null) dgvHistory.Columns["HallType"].HeaderText = "Зал";
                    if (dgvHistory.Columns["StartTime"] != null) dgvHistory.Columns["StartTime"].HeaderText = "Начало";
                    if (dgvHistory.Columns["EndTime"] != null) dgvHistory.Columns["EndTime"].HeaderText = "Конец";
                    if (dgvHistory.Columns["TotalCost"] != null) dgvHistory.Columns["TotalCost"].HeaderText = "Цена (руб)";

                    // Растягиваем колонки по ширине таблицы
                    dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке истории: " + ex.Message);
            }
        }
        private void btnShowHistory_Click(object sender, EventArgs e)
        {
            LoadSessionHistory();
            dgvHistory.Visible = !dgvHistory.Visible;
        }

        private void dgvHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void cmbTariffs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTariffs.SelectedItem is Tariff tariff)
            {
                var hoursList = new List<int>();
                for (int h = tariff.MinHours; h <= tariff.MaxHours; h++)
                    hoursList.Add(h);

                cmbHours.DataSource = hoursList;
                if (cmbHours.Items.Count > 0)
                    cmbHours.SelectedIndex = 0;
            }
            else
            {
                cmbHours.DataSource = null;
            }
            UpdateTotalPrice();
        }
        private void cmbHours_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
            RefreshAvailableComputers();
        }
        private void UpdateTotalPrice()
        {
            if (cmbTariffs.SelectedItem is Tariff tariff &&
                cmbHours.SelectedItem is int hours)
            {
                int total = tariff.PricePerHour * hours;
                txtTotalPrice.Text = $"{total} руб.";
            }
            else
            {
                txtTotalPrice.Text = "";
            }
        }

        private void LoadHalls()
        {
            var halls = _logic.GetAllHalls();

            cmbHalls.DataSource = halls;
            cmbHalls.DisplayMember = "Name"; // То, что видит юзер (например, "VIP Зал")
            cmbHalls.ValueMember = "Id";     // То, что скрыто под капотом (ID зала)

            cmbHalls.SelectedIndex = -1; // Чтобы по умолчанию ничего не было выбрано
        }

        /*(private void btnBook_Click(object sender, EventArgs e)
        {
            // 1. СНАЧАЛА ПРОВЕРЯЕМ ЗАПОЛНЕННОСТЬ (чтобы не ловить вылеты)
            if (cmbHalls.SelectedIndex == -1 ||
                cmbComputers.SelectedIndex == -1 ||
                cmbTariffs.SelectedIndex == -1 ||
                cmbHours.SelectedIndex == -1)
            {
                MessageBox.Show("Заполните все поля бронирования.");
                return;
            }

            // 2. ТЕПЕРЬ ПРОВЕРЯЕМ СТАТУС ПК (прямо из выбранного элемента списка)
            dynamic selectedPc = cmbComputers.SelectedItem;
            string pcStatus = selectedPc.Status;

            if (pcStatus == "Занят")
            {
                MessageBox.Show("Этот компьютер занят, выберите другой или подождите.");
                return;
            }
            if (pcStatus == "В ремонте")
            {
                MessageBox.Show("Компьютер сломан или находится в ремонте.");
                return;
            }

            // 3. ЕСЛИ ВСЁ ОК — ВЫТАСКИВАЕМ ID ДЛЯ БАЗЫ ДАННЫХ
            int hallId = (int)cmbHalls.SelectedValue;
            int computerId = (int)cmbComputers.SelectedValue;
            int tariffId = (int)cmbTariffs.SelectedValue;
            int hours = (int)cmbHours.SelectedItem;

            // 4.ОТПРАВЛЯЕМ ЗАПРОС НА БРОНИРОВАНИЕ
            var result = _logic.BookComputer(_currentUserId, computerId, tariffId, hours);
            MessageBox.Show(result.message);

            // 5. ОБНОВЛЯЕМ ИНТЕРФЕЙС ПРИ УСПЕХЕ
            if (result.success)
            {
                RefreshUserData();                           // Обновит баланс на форме
                cmbHalls_SelectedIndexChanged(null, null);   // Перезагрузит ПК (теперь этот ПК станет "Занят до...") и тарифы
                LoadSessionHistory();                        // Обновит таблицу сессий внизу
            }
        }*/
        private void btnBook_Click(object sender, EventArgs e)
        {
            if (cmbHalls.SelectedIndex == -1 ||
                cmbComputers.SelectedIndex == -1 ||
                cmbTariffs.SelectedIndex == -1 ||
                cmbHours.SelectedIndex == -1)
            {
                MessageBox.Show("Заполните все поля бронирования.");
                return;
            }

            dynamic selectedPc = cmbComputers.SelectedItem;
            string pcStatus = selectedPc.Status;

            if (pcStatus == "Занят")
            {
                MessageBox.Show("Этот компьютер занят на выбранный вами интервал времени!");
                return;
            }
            if (pcStatus == "В ремонте")
            {
                MessageBox.Show("Компьютер в ремонте.");
                return;
            }

            int computerId = (int)cmbComputers.SelectedValue;
            int tariffId = (int)cmbTariffs.SelectedValue;
            int hours = Convert.ToInt32(cmbHours.SelectedItem);

            // --- ОПЯТЬ СКЛЕИВАЕМ ДАТУ И ВРЕМЯ ДЛЯ БАЗЫ ---
            DateTime selectedDate = dtpBookingDate.Value.Date;
            DateTime selectedTime = dtpBookingTime.Value;
            DateTime bookingStart = new DateTime(
                selectedDate.Year, selectedDate.Month, selectedDate.Day,
                selectedTime.Hour, selectedTime.Minute, 0
            );
            // Защита: нельзя бронировать в прошлом
            if (bookingStart < DateTime.Now.AddMinutes(-5))
            {
                MessageBox.Show("Нельзя забронировать компьютер на прошедшее время!");
                return;
            }

            // Передаем дату в метод бизнес-логики (нужно будет добавить параметр bookingStart в твой метод!)
            var result = _logic.BookComputer(_currentUserId, computerId, tariffId, hours, bookingStart);
            MessageBox.Show(result.message);

            if (result.success)
            {
                RefreshUserData();
                RefreshAvailableComputers(); // Обновит список с учетом только что созданной брони
                LoadSessionHistory();
            }
        }
        private void linkTopUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (panelTopUp.Visible)
            {
                panelTopUp.Visible = false;
                panelMain.Visible = true;
            }
            else
            {
                panelMain.Visible = false;
                panelTopUp.Visible = true;
                txtTopUpAmount.Focus();
            }
        }
        private void linkToLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new AuthForm().Show();
            this.Close();  // потом закрываем текущее
        }

        // 1. Создаем универсальный метод обновления данных на форме
        private void RefreshAvailableComputers()
        {
            if (cmbHalls.SelectedValue == null || !(cmbHalls.SelectedValue is int)) return;
            if (cmbHours.SelectedItem == null) return;

            int hallId = (int)cmbHalls.SelectedValue;

            // --- ВОТ ТУТ СКЛЕИВАЕМ ДАТУ И ВРЕМЯ ---
            DateTime selectedDate = dtpBookingDate.Value.Date; // Берем только день
            DateTime selectedTime = dtpBookingTime.Value;      // Берем время

            // Создаем итоговую дату со временем
            DateTime reqStart = new DateTime(
                selectedDate.Year, selectedDate.Month, selectedDate.Day,
                selectedTime.Hour, selectedTime.Minute, 0
            );
            int hours = Convert.ToInt32(cmbHours.SelectedItem);

            DataTable dt = _logic.GetComputersByTimeInterval(hallId, reqStart, hours);
            var comboItems = new List<object>();

            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                int number = Convert.ToInt32(row["pc_number"]);
                string dbStatus = row["status"].ToString(); // общий статус из таблицы компьютеров (например, В ремонте)

                string displayText = $"ПК №{number} (Свободен)";
                string calculatedStatus = "Свободен";

                // Если подзапрос нашел пересечение броней в этот интервал
                if (row["conflict_start"] != DBNull.Value)
                {
                    DateTime confStart = Convert.ToDateTime(row["conflict_start"]);
                    DateTime confEnd = Convert.ToDateTime(row["conflict_end"]);

                    displayText = $"ПК №{number} (Занят с {confStart:dd.MM HH:mm} до {confEnd:HH:mm})";
                    calculatedStatus = "Занят";
                }
                else if (dbStatus == "В ремонте")
                {
                    displayText = $"ПК №{number} (В ремонте)";
                    calculatedStatus = "В ремонте";
                }

                comboItems.Add(new { Id = id, Display = displayText, Status = calculatedStatus });
            }

            // Перепривязываем ComboBox компьютеров
            cmbComputers.DataSource = comboItems;
            cmbComputers.ValueMember = "Id";
            cmbComputers.DisplayMember = "Display";
        }

        // 2. Теперь подвязываем этот метод к событиям формы:
        private void cmbHalls_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshAvailableComputers();

            // Не забываем загрузку тарифов, которую мы чинили в прошлый раз!
            if (cmbHalls.SelectedValue is int hallId)
            {
                cmbTariffs.DataSource = _logic.GetTariffsByHall(hallId);
                cmbTariffs.ValueMember = "Id";
                cmbTariffs.DisplayMember = "Name";
            }
        }


        private void dtpBookingTime_ValueChanged(object sender, EventArgs e)
        {
            RefreshAvailableComputers();
        }

        private void dtpBookingDate_ValueChanged(object sender, EventArgs e)
        {
            RefreshAvailableComputers();
        }


    }
}

