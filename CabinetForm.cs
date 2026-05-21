using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PCC_App.BusinessLogic;
using PCC_App.DataAccess;
using PCC_App;
using PCC_App.BusinessLogic;

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

        private void cmbHalls_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHalls.SelectedIndex == -1) return;

            int selectedHallId = (int)cmbHalls.SelectedValue;

            // Свободные ПК
            var freePcs = _logic.GetFreePcsByHall(selectedHallId);
            cmbComputers.DataSource = freePcs;
            cmbComputers.DisplayMember = "PcNumber";  // просто номер ПК
            cmbComputers.ValueMember = "Id";

            // Тарифы
            var tariffs = _logic.GetTariffsByHall(selectedHallId);
            cmbTariffs.DataSource = tariffs;
            cmbTariffs.DisplayMember = "DisplayName";
            cmbTariffs.ValueMember = "Id";

            // Очищаем выбор часов и цену
            cmbHours.DataSource = null;
            txtTotalPrice.Text = "";
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

        private void btnBook_Click(object sender, EventArgs e)
        {
            // Проверка заполненности
            if (cmbHalls.SelectedIndex == -1 ||
                cmbComputers.SelectedIndex == -1 ||
                cmbTariffs.SelectedIndex == -1 ||
                cmbHours.SelectedIndex == -1)
            {
                MessageBox.Show("Заполните все поля бронирования.");
                return;
            }

            int hallId = (int)cmbHalls.SelectedValue;
            int computerId = (int)cmbComputers.SelectedValue;
            int tariffId = (int)cmbTariffs.SelectedValue;
            int hours = (int)cmbHours.SelectedItem;

            // Дополнительная проверка — вдруг компьютер заняли в эту же секунду
            var freePcs = _logic.GetFreePcsByHall(hallId);
            if (freePcs.All(c => c.Id != computerId))
            {
                MessageBox.Show("Этот компьютер уже занят или в ремонте. Выберите другой.");
                cmbHalls_SelectedIndexChanged(null, null); // обновим список
                return;
            }

            var result = _logic.BookComputer(_currentUserId, computerId, tariffId, hours);
            MessageBox.Show(result.message);

            if (result.success)
            {
                RefreshUserData();                   // обновит баланс на форме
                cmbHalls_SelectedIndexChanged(null, null); // перезагрузит ПК (уберет занятый)
                LoadSessionHistory();                       // обновит таблицу сессий
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
       
    }
}

