using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PCC_App.DataAccess;

namespace PCC_App.BusinessLogic
{
    public class AppLogic
    {
        private readonly DatabaseHelper _db;

        public AppLogic(string connectionString)
        {
            _db = new DatabaseHelper(connectionString);
        }

        // --- АВТОРИЗАЦИЯ И РЕГИСТРАЦИЯ ---

        public (int userId, int roleId)? LoginUser(string nickname, string password)
        {
            return _db.GetUserIdandRole(nickname, password);
        }

        public (bool success, string message) RegisterNewUser(string nickname, string fullname, string email, string password)
        {
            // 1. Проверки на дурака
            if (string.IsNullOrWhiteSpace(nickname) || nickname.Contains("никнейм") ||
                string.IsNullOrWhiteSpace(password) || password.Contains("пароль") ||
                string.IsNullOrWhiteSpace(fullname) || fullname.Contains("ФИО") ||
                string.IsNullOrWhiteSpace(email) || email.Contains("почту"))
            {
                return (false, "Пожалуйста, заполните все поля корректно!");
            }

            if (password.Length < 4)
            {
                return (false, "Пароль должен быть больше 4 символов!");
            }

            string[] nameParts = fullname.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (nameParts.Length != 3)
            {
                return (false, "Неправильно введено ФИО! Введите Фамилию, Имя и Отчество через пробел.");
            }

            // 2. Проверка БД на занятость
            try
            {
                if (_db.IsUserExists(nickname, email))
                {
                    return (false, "Пользователь с таким никнеймом или почтой уже существует!");
                }

                // 3. Сохранение
                _db.RegisterUser(nickname, fullname, email, password);
                return (true, "Регистрация успешна! Теперь войдите.");
            }
            catch (Exception ex)
            {
                return (false, "Ошибка базы данных: " + ex.Message);
            }
        }

        // --- ЛИЧНЫЙ КАБИНЕТ ---

        public User SearchUserById(int id)
        {
            return _db.GetUserById(id);
        }

        public User GetUserById(int id)
        {
            return _db.GetUserById(id);
        }

        public string TopUpBalance(int userId, int amount)
        {
            if (amount <= 0)
            {
                return "Ошибка: Сумма пополнения должна быть больше нуля!";
            }
            _db.UpdateBalance(userId, amount);
            return $"Успех: Ваш баланс пополнен на {amount} руб.";
        }

        public List<Session> GetHistory(int userId)
        {
            return _db.GetUserSessions(userId);
        }

        public (bool success, string message) BookComputer(int userId, int computerId, int tariffId, int hours, DateTime bookingStart)
        {
            var user = _db.GetUserById(userId);
            if (user == null) return (false, "Пользователь не найден");

            var tariff = _db.GetTariffById(tariffId);
            if (tariff == null) return (false, "Тариф не найден");

            int cost = tariff.PricePerHour * hours;
            if (user.Balance < cost)
                return (false, $"Недостаточно средств. Требуется {cost}, у вас {user.Balance}");

            _db.UpdateBalance(userId, -cost);

            // Передаем выбранное время старта брони в базу данных
            _db.CreateSession(userId, computerId, tariffId, hours, cost, bookingStart);

            // МЕНЯЕМ СТАТУС ТОЛЬКО ЕСЛИ СЕССИЯ НАЧИНАЕТСЯ СЕЙЧАС (например, в ближайшие 10 минут)
            if (bookingStart <= DateTime.Now.AddMinutes(10))
            {
                _db.UpdateComputerStatus(computerId, ComputerStatus.Занят);
            }

            return (true, $"Бронь на {hours} ч. оформлена. Списано {cost} руб.");
        }

        public List<Computer> GetFreePcs(int hallId)
        {
            return _db.GetFreeComputersByHall(hallId);
        }

        // --- ДЛЯ АДМИНА ---

        public User SearchUser(string nickname)
        {
            if (string.IsNullOrWhiteSpace(nickname))
                return null;
            return _db.GetUserByNickname(nickname);
        }

        public string AdminChangeBalance(int userId, int amountToAdd)
        {
            _db.UpdateBalance(userId, amountToAdd);
            return $"Успех: Баланс пользователя успешно изменен.";
        }

        public List<Session> GetAllActiveSessions()
        {
            return _db.GetActiveSessions();
        }

        public string EndSessionEarly(int sessionId, int pcId)
        {
            _db.EndSession(sessionId, pcId);
            return "Успех: Сессия завершена, компьютер снова свободен.";
        }

        // --- ЗАЛЫ И ТАРИФЫ ---

        public List<Hall> GetAllHalls()
        {
            return _db.GetHalls();
        }

        public List<Computer> GetFreePcsByHall(int hallId)
        {
            return _db.GetFreeComputersByHall(hallId);
        }

        public DataTable GetComputersWithSessions(int hallId)
        {
            // Просто перенаправляем запрос в базу данных
            return _db.GetComputersWithSessions(hallId);
        }

        public List<Tariff> GetTariffsByHall(int hallId)
        {
            return _db.GetTariffsByHall(hallId);
        }

        public DataTable GetComputersByTimeInterval(int hallId, DateTime reqStart, int hours)
        {
            DateTime reqEnd = reqStart.AddHours(hours);
            return _db.GetComputersByTimeInterval(hallId, reqStart, reqEnd);
        }
    }
}
