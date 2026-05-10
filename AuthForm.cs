using System;
using System.Drawing;
using System.Windows.Forms;
using PCC_App.BusinessLogic;
using PCC_App.UI;
using PCC_App;

namespace PCC_App
{
    public partial class AuthForm : Form
    {
        private readonly string _connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=Pc_club_App";
        private readonly AppLogic _logic;

        public AuthForm()
        {
            InitializeComponent();
            _logic = new AppLogic(_connectionString);

            // Настройка подсказок (Placeholder) через твой хелпер!
            Helpers.SetPlaceholder(txtLogin, "Введите свой никнейм");
            Helpers.SetPlaceholder(txtPassword, "Введите свой пароль");
            Helpers.SetPlaceholder(txtNickname, "Придумайте свой никнейм");
            Helpers.SetPlaceholder(txtRegPassword, "Придумайте свой пароль");
            Helpers.SetPlaceholder(txtFullname, "Введите ваше ФИО через пробел");
            Helpers.SetPlaceholder(txtEmail, "Введите вашу почту");
        }

        // --- КНОПКА ВХОДА ---
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string pass = txtPassword.Text;

            var result = _logic.LoginUser(login, pass);

            if (result != null)
            {
                int userId = result.Value.userId;
                int roleId = result.Value.roleId;

                if (roleId == 2) // Админ
                {
                    AdminForm adminFrm = new AdminForm(userId, _connectionString);
                    adminFrm.Show();
                    this.Hide();
                }
                else // Обычный юзер
                {
                    CabinetForm cabFrm = new CabinetForm(userId, _connectionString);
                    cabFrm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Неверный ник или пароль, бро. Попробуй еще раз.");
            }
        }

        // --- КНОПКА РЕГИСТРАЦИИ ---
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Вызываем умный метод из логики
            var result = _logic.RegisterNewUser(txtNickname.Text, txtFullname.Text, txtEmail.Text, txtRegPassword.Text);

            if (result.success)
            {
                MessageBox.Show(result.message);

                // Очистка полей
                txtNickname.Text = "Придумайте свой никнейм";
                txtNickname.ForeColor = Color.Gray;
                txtFullname.Text = "Введите ваше ФИО через пробел";
                txtFullname.ForeColor = Color.Gray;
                txtEmail.Text = "Введите вашу почту";
                txtEmail.ForeColor = Color.Gray;
                txtRegPassword.Text = "Придумайте свой пароль";
                txtRegPassword.ForeColor = Color.Gray;

                panelRegister.Visible = false;
                panelLogin.Visible = true;
            }
            else
            {
                MessageBox.Show(result.message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // --- ПЕРЕКЛЮЧЕНИЕ ПАНЕЛЕЙ ---


        private void linkToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelRegister.Visible = false;
            panelLogin.Visible = true;
        }

        private void linkToRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelLogin.Visible = false;
            panelRegister.Visible = true;
        }
    }
}