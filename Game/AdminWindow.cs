using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game.NewFolder1
{
    internal class AdminWindow
    {
        private Models.User _loggedInUser;
        public AdminWindow(Models.User user)
        {
            InitializeComponent();
            _loggedInUser = user;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}
