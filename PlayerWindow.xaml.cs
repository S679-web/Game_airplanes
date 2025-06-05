using System;
using System.Windows;
using Game.Models;

namespace Game
{
    public partial class PlayerWindow : Window
    {
        private object user;

        public PlayerWindow(object user)
        {
            InitializeComponent();
            WelcomeLabel = $"Добро пожаловать, {user}!";
            this.user = user;
        }

        public string WelcomeLabel { get; private set; }
    }
}
