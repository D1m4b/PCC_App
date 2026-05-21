using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCC_App.BusinessLogic;

namespace PCC_App.UI
{
    public partial class AdminForm : Form
    {
        private readonly AppLogic _logic;
        private User _foundUser; // Сюда сохраним юзера, которого нашли

        public AdminForm(int adminId, string connString)
        {
            InitializeComponent();
            _logic = new AppLogic(connString);
            LoadActiveSessions();
            Helpers.SetPlaceholder(txtSearchNick, "Введите ник");
            Helpers.SetPlaceholder(txtAmount, "Введите сумму");
        }


        private void LoadActiveSessions()
        {
            try
            {
                var active = _logic.GetAllActiveSessions();

                dgvActiveSessions.DataSource = null;
                dgvActiveSessions.DataSource = active;

                if (dgvActiveSessions.Columns.Count > 0)
                {
                    // Скрываем технические колонки
                    if (dgvActiveSessions.Columns["Id"] != null)
                        dgvActiveSessions.Columns["Id"].Visible = false;
                    if (dgvActiveSessions.Columns["UserId"] != null)
                        dgvActiveSessions.Columns["UserId"].Visible = false;
                    if (dgvActiveSessions.Columns["ComputerId"] != null)
                        dgvActiveSessions.Columns["ComputerId"].Visible = false; // скрыт, но нам нужен!

                    // Переименовываем заголовки как у юзера
                    if (dgvActiveSessions.Columns["UserNickname"] != null)
                        dgvActiveSessions.Columns["UserNickname"].HeaderText = "Игрок";
                    if (dgvActiveSessions.Columns["PcNumber"] != null)
                        dgvActiveSessions.Columns["PcNumber"].HeaderText = "ПК №";
                    if (dgvActiveSessions.Columns["HallType"] != null)
                        dgvActiveSessions.Columns["HallType"].HeaderText = "Зал";
                    if (dgvActiveSessions.Columns["StartTime"] != null)
                        dgvActiveSessions.Columns["StartTime"].HeaderText = "Начало";
                    if (dgvActiveSessions.Columns["EndTime"] != null)
                        dgvActiveSessions.Columns["EndTime"].HeaderText = "Конец";
                    if (dgvActiveSessions.Columns["TotalCost"] != null)
                        dgvActiveSessions.Columns["TotalCost"].HeaderText = "Цена (руб)";

                    dgvActiveSessions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки сессий: " + ex.Message);
            }
        }

        // 🖥️ ЗАГРУЗКА АКТИВНЫХ СЕССИЙ
        private void btnRefreshSessions_Click(object sender, EventArgs e)
        {
            var active = _logic.GetAllActiveSessions();
            dgvActiveSessions.DataSource = null;
            dgvActiveSessions.DataSource = active;
        }
        private void txtSearchNick_TextChanged(object sender, EventArgs e)
        {

        }

        // 🔍 ПОИСК ЮЗЕРА
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _foundUser = _logic.SearchUser(txtSearchNick.Text);

            if (_foundUser != null)
            {
                lblFullName.Text = "ФИО: " + _foundUser.Fullname;
                lblCurrentBalance.Text = "Баланс: " + _foundUser.Balance + " руб.";
                btnUpdateBalance.Enabled = true;
                panelSearchResult.Visible = true;
            }
            else
            {
                MessageBox.Show("Юзер не найден, бро!");
                btnUpdateBalance.Enabled = false;
                panelSearchResult.Visible = false;
            }
        }
        // 💰 ИЗМЕНЕНИЕ БАЛАНСА РУКАМИ
        private void btnUpdateBalance_Click(object sender, EventArgs e)
        {
            if (_foundUser == null) return;

            if (int.TryParse(txtAmount.Text, out int amount))
            {
                string res = _logic.AdminChangeBalance(_foundUser.Id, amount);
                MessageBox.Show(res);

                // Обновляем данные на экране
                btnSearch_Click(null, null);
            }
        }
        // ❌ ЗАВЕРШИТЬ СЕССИЮ (КИКНУТЬ)
        private void btnEndSession_Click(object sender, EventArgs e)
        {
            if (dgvActiveSessions.CurrentRow != null)
            {
                // Берем сессию из выбранной строки таблицы
                var session = (Session)dgvActiveSessions.CurrentRow.DataBoundItem;

                string res = _logic.EndSessionEarly(session.Id, session.ComputerId);
                MessageBox.Show(res);

                btnRefreshSessions_Click(null, null); // Обновляем список
            }
        }

        private void linkToLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new AuthForm().Show();
            this.Close();
        }

        private void btnRefreshSession_Click(object sender, EventArgs e)
        {
            dgvActiveSessions.DataSource = _logic.GetAllActiveSessions();
        }
    }
}
