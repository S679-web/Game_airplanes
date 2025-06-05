using System.Linq;
using System.Windows;
using System.Data.Entity;
using Game;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Game.Models;

namespace Game
{
    public partial class LoginWindow : Window
    {
        private AppDbContext _context = new AppDbContext();
        private object Users;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private AppDbContext Get_context()
        {
            return _context;
        }

        private object GetUsers()
        {
            return Users;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e, AppDbContext _context, object users)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            var user = users.Include(u => u.Role).FirstOrDefault(u => u.Username == username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
                return;
            }

            MessageBox.Show($"Добро пожаловать, {user.Username} ({user.Role.Name})!");

            if (user.Role.Name == "Admin")
                new AdminWindow(user).Show();
            else
                new PlayerWindow(user).Show();

            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            new RegisterWindow().ShowDialog();
        }
    }
}
