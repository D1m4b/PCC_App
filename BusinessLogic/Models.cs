using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCC_App.BusinessLogic
{
    public enum ComputerStatus
    {
        Свободен,
        Занят,
        Ремонт
    }
    //у нас в таблице можно добавить названия залов, но для удобства я хочу использовать enum class
    public enum HallType
    {
        Обычный = 1,
        ВИП = 2,
        Плойка = 3
    }
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }
        public int RoleId { get; set; }
    }
    public class Hall
    {
        public int Id { get; set; }
        public HallType Type { get; set; }
        public string Name => Type.ToString();
    }
    public class Tariff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PricePerHour { get; set; }
        public int HallId { get; set; }

        // Отображаемое имя для ComboBox
        public string DisplayName => $"{Name} ({PricePerHour} руб/ч)";

        // Вычисляем минимальное количество часов из названия
        public int MinHours
        {
            get
            {
                if (Name.Contains("до"))         // "до 5 часов"
                    return 1;
                else if (Name.Contains("+"))    // "12+ часов"
                {
                    string numStr = Name.Split('+')[0].Trim();
                    return int.TryParse(numStr, out int n) ? n + 1 : 13;
                }
                else                            // "5-12 часов"
                {
                    string[] parts = Name.Split('-');
                    if (parts.Length >= 2 && int.TryParse(parts[0].Trim(), out int min))
                        return min;
                }
                return 1; // fallback
            }
        }

        // Вычисляем максимальное количество часов из названия
        public int MaxHours
        {
            get
            {
                if (Name.Contains("до"))
                {
                    string numStr = Name.Replace("до", "").Replace("часов", "").Trim();
                    return int.TryParse(numStr, out int n) ? n : 5;
                }
                else if (Name.Contains("+"))
                    return 24; // разумный потолок
                else
                {
                    string[] parts = Name.Split('-');
                    if (parts.Length >= 2)
                    {
                        string maxPart = parts[1].Replace("часов", "").Trim();
                        if (int.TryParse(maxPart, out int max))
                            return max;
                    }
                }
                return 24;
            }
        }
    }
    public class Computer
    {
        public int Id { get; set; }
        public int HallId { get; set; }
        public HallType HallType { get; set; }
        public int PcNumber { get; set; }
        public string Specs { get; set; }
        public ComputerStatus Status { get; set; }
    }
    public class Session
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ComputerId { get; set; }


        public string UserNickname { get; set; }
        public int PcNumber { get; set; }
        public int TotalCost { get; set; }
        public HallType HallType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

