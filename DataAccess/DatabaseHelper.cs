using System;
using System.Collections.Generic;
using Npgsql;
using PCC_App.BusinessLogic;

namespace PCC_App.DataAccess
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public (int userId, int roleId)? GetUserIdandRole(string nickname, string password)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT id, role_id FROM users WHERE nickname = @nick AND password = @pass";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nick", nickname);
                    cmd.Parameters.AddWithValue("@pass", password);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (reader.GetInt32(0), reader.GetInt32(1));
                        }
                    }
                }
            }
            return null;
        }

        public User GetUserByNickname(string nickname)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT id, nickname, fullname, email, balance, role_id FROM users WHERE nickname = @nick";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nick", nickname);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetInt32(0),
                                Nickname = reader.GetString(1),
                                Fullname = reader.GetString(2),
                                Email = reader.GetString(3),
                                Balance = reader.GetInt32(4),
                                RoleId = reader.GetInt32(5)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public User GetUserById(int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT id, nickname, fullname, email, balance, role_id FROM users WHERE id = @uid";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", id);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetInt32(0),
                                Nickname = reader.GetString(1),
                                Fullname = reader.GetString(2),
                                Email = reader.GetString(3),
                                Balance = reader.GetInt32(4),
                                RoleId = reader.GetInt32(5)
                            };
                        }
                    }
                }
            }
            return null;
        }

        // НОВЫЙ МЕТОД: Проверка, существует ли уже такой юзер
        public bool IsUserExists(string nickname, string email)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM users WHERE nickname = @nick OR email = @email";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nick", nickname);
                    cmd.Parameters.AddWithValue("@email", email);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public void RegisterUser(string nickname, string fullname, string email, string password)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO users (nickname, fullname, email, password, balance, role_id) VALUES (@nick, @full, @email, @pass, 0, 2)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nick", nickname);
                    cmd.Parameters.AddWithValue("@full", fullname);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@pass", password);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateBalance(int userId, int amount)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "UPDATE users SET balance = balance + @amt WHERE id = @uid";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@amt", amount);
                    cmd.Parameters.AddWithValue("@uid", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Tariff> GetTariffsByHall(int hallId)
        {
            var tariffs = new List<Tariff>();
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT id, name, price_per_hour, hall_id FROM tariffs WHERE hall_id = @hallId";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@hallId", hallId);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tariffs.Add(new Tariff
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                PricePerHour = reader.GetInt32(2),
                                HallId = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }
            return tariffs;
        }

        public Tariff GetTariffById(int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT id, name, price_per_hour, hall_id FROM tariffs WHERE id = @id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return new Tariff
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                PricePerHour = reader.GetInt32(2),
                                HallId = reader.GetInt32(3)
                            };
                    }
                }
            }
            return null;
        }

        public List<Computer> GetFreeComputersByHall(int hallId)
        {
            List<Computer> computers = new List<Computer>();
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"SELECT c.id, c.hall_id, h.name, c.pc_number, c.specs, c.status 
                              FROM computers c JOIN halls h ON c.hall_id = h.id
                              WHERE c.hall_id = @hid AND c.status = 'Свободен'";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@hid", hallId);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            computers.Add(new Computer
                            {
                                Id = reader.GetInt32(0),
                                HallId = reader.GetInt32(1),
                                HallType = (HallType)Enum.Parse(typeof(HallType), reader.GetString(2)),
                                PcNumber = reader.GetInt32(3),
                                Specs = reader.GetString(4),
                                Status = (ComputerStatus)Enum.Parse(typeof(ComputerStatus), reader.GetString(5))
                            });
                        }
                    }
                }
            }
            return computers;
        }

        public void UpdateComputerStatus(int computerId, ComputerStatus newStatus)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "UPDATE computers SET status = @st WHERE id = @cid";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@st", newStatus.ToString());
                    cmd.Parameters.AddWithValue("@cid", computerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CreateSession(int userId, int computerId, int tariffId, int hours, int totalCost)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO sessions (user_id, computer_id, tariff_id, start_time, end_time, total_cost) VALUES (@uid, @cid, @tid, @start, @end, @cost)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", userId);
                    cmd.Parameters.AddWithValue("@cid", computerId);
                    cmd.Parameters.AddWithValue("@tid", tariffId);
                    cmd.Parameters.AddWithValue("@start", DateTime.Now);
                    cmd.Parameters.AddWithValue("@end", DateTime.Now.AddHours(hours));
                    cmd.Parameters.AddWithValue("@cost", totalCost);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Session> GetUserSessions(int userId)
        {
            List<Session> sessions = new List<Session>();
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"SELECT s.id, u.nickname, c.pc_number, h.name, s.start_time, s.end_time, s.total_cost
                              FROM sessions s
                              JOIN users u ON s.user_id = u.id
                              JOIN computers c ON s.computer_id = c.id
                              JOIN halls h ON c.hall_id = h.id
                              WHERE s.user_id = @uid
                              ORDER BY s.start_time DESC";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", userId);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sessions.Add(new Session
                            {
                                Id = reader.GetInt32(0),
                                UserNickname = reader.GetString(1),
                                PcNumber = reader.GetInt32(2),
                                HallType = (HallType)Enum.Parse(typeof(HallType), reader.GetString(3)),
                                StartTime = reader.GetDateTime(4),
                                EndTime = reader.GetDateTime(5),
                                TotalCost = reader.GetInt32(6)
                            });
                        }
                    }
                }
            }
            return sessions;
        }

        public List<Session> GetActiveSessions()
        {
            List<Session> active = new List<Session>();
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"SELECT s.id, u.nickname, c.pc_number, h.name, s.start_time, s.end_time, s.total_cost, c.id AS computer_id
                              FROM sessions s
                              JOIN users u ON s.user_id = u.id
                              JOIN computers c ON s.computer_id = c.id
                              JOIN halls h ON c.hall_id = h.id
                              WHERE c.status = 'Занят' AND s.end_time > NOW()
                              ORDER BY h.name, c.pc_number";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        active.Add(new Session
                        {
                            Id = reader.GetInt32(0),
                            UserNickname = reader.GetString(1),
                            PcNumber = reader.GetInt32(2),
                            HallType = (HallType)Enum.Parse(typeof(HallType), reader.GetString(3)),
                            StartTime = reader.GetDateTime(4),
                            EndTime = reader.GetDateTime(5),
                            TotalCost = reader.GetInt32(6),
                            ComputerId = reader.GetInt32(7)
                        });
                    }
                }
            }
            return active;
        }

        public void EndSession(int sessionId, int computerId)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE sessions SET end_time = NOW() WHERE id = @sid; UPDATE computers SET status = 'Свободен' WHERE id = @cid";
                    cmd.Parameters.AddWithValue("@sid", sessionId);
                    cmd.Parameters.AddWithValue("@cid", computerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Hall> GetHalls()
        {
            List<Hall> halls = new List<Hall>();
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT id, name FROM halls";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string valueFromDb = reader.GetString(1);
                            if (Enum.TryParse(valueFromDb, out HallType hType))
                            {
                                halls.Add(new Hall
                                {
                                    Id = id,
                                    Type = hType
                                });
                            }
                        }
                    }
                }
            }
            return halls;
        }
    }
}