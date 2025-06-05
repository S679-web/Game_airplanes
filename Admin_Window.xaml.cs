using System.Linq;
using System.Windows;
using Game.Models;
using Game.NewFolder1;

namespace Game
{
    public partial class Admin_Window: Window
    {
        private AppDbContext _context = new AppDbContext();
        private Role[] _roles;

        public object UsersDataGrid { get; private set; }
        public object ResultsDataGrid { get; private set; }


        private void UsersDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (UsersDataGrid is User user)
            {
                ResultsDataGrid = _context.GameResult
                    .ToList();
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid is User user)
            {
                if (MessageBox.Show("Удалить пользователя?", "Подтвердите", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _context.SaveChanges();
                   
                }
            }
        }

        private void ChangeRole_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid is User user)
            {
                var newRole = _roles.FirstOrDefault(r => r.Id != user.RoleId);
                if (newRole != null)
                {
                    user.RoleId = newRole.Id;
                    _context.SaveChanges();
                 
                }
            }
        }

        private void ResetPassword_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid is User user)
            {
                string newPassword = "123456";
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
                _context.SaveChanges();
                MessageBox.Show($"Пароль сброшен на: {newPassword}");
            }
        }
    }
}
