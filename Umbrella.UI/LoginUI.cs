using System.Windows;
using System.Windows.Input;
using Umbrella.BL.Database;
using Umbrella.BL.Entity;
using Umbrella.BL.Exceptions;
using Umbrella.BL.Services;
using Umbrella.Core;

namespace Umbrella.UI
{
    public class LoginUI
    {
        private readonly MainWindow window;

        public LoginUI(MainWindow window)
        {
            this.window = window;
        }

        public void Select()
        {
            window.MessageLabel.Content = "Аутентифицируйтесь в домене VIAcode.";
            window.UmbrellaAppState = UmbrellaAppState.Login;
            window.LoginTextBox.Focus();

        }

        public void OnKeyDown(KeyEventArgs args)
        {
            if (args.Key != Key.Enter)
                return;

            var authenticationManager = new AuthenticationManager();
            var userService = new UserService(
                authenticationManager, 
                new SessionFactory("default", 10));

            try
            {
                User user = userService.Authenticate(window.LoginTextBox.Text, window.PasswordTextBox.Password);
                window.LoginTextBox.Text = string.Empty;
                window.PasswordTextBox.Password = string.Empty;

                window.OperationLogGrid.Visibility = Visibility.Visible;
                window.LoginGrid.Visibility = Visibility.Hidden;

                args.Handled = true;

                window.ProcessUI.Select();
                window.ProcessUI.Process(user);
            }
            catch (InvalidUserException e)
            {
                MessageBox.Show("Упсс ... аутенификация в домене VIAcode не проходит :(.", "Ошибка");
            }
        }
    }
}
