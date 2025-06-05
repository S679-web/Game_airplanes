using System.Windows;
using System.Data.Entity;
using System.Windows.Controls;
using Game.Models;
using Game;

namespace Game
{
    public partial class RegistrationWindow : Window
    {
        private AppDbContext _context = new AppDbContext();

        public RegistrationWindow(System.Collections.IEnumerable roles)
        {
            InitializeComponent();

            // Подгружаем роли
            var role = _context.Roles;
            RoleComboBox.ItemsSource = roles;
            RoleComboBox.SelectedIndex = 0; // Выбираем первую роль по умолчанию
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            var selectedRole = RoleComboBox.SelectedItem as Role;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || selectedRole == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }


            var user = new User
            {
                Username = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                RoleId = selectedRole.Id
            };

            MessageBox.Show("Пользователь успешно зарегистрирован!");
            new LoginWindow().Show();
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }
    }
}
