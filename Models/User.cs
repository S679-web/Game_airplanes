using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models
{
    internal class User
    {
            public int Id { get; set; }
            public string Username { get; set; }
            public string PasswordHash { get; set; } // Hash пароля
            public int RoleId { get; set; }
            public Role Role { get; set; } // Навигационное свойство
     
    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } // Свойство Name для отображения в ComboBox
    }

    public class GameResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
        public DateTime PlayedAt { get; set; } = DateTime.Now;
    }
}
