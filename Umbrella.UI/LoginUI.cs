using System.Windows;
using System.Windows.Input;
using Umbrella.BL.Database;
using Umbrella.BL.Exceptions;
using Umbrella.BL.Services;
using Umbrella.Core;

namespace Umbrella.UI
{
    public class LoginUI
    {
        private readonly MainWindow window;
        private readonly UmbrellaService umbrellaService = new UmbrellaService();

        public LoginUI(MainWindow window)
        {
            this.window = window;
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
                userService.Authenticate(window.LoginTextBox.Text, window.PasswordTextBox.Password);
                umbrellaService.Do();
            }
            catch (InvalidUserException e)
            {
                MessageBox.Show("Упсс ... аутенификация в домене VIAcode не проходит :(.", "Ошибка");
            }
        }
    }
}
