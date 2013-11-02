using System.Windows;
using System.Windows.Input;
using Umbrella.BL.Entity;
using Umbrella.BL.Exceptions;
using Umbrella.BL.Services;
using Umbrella.Core;

namespace Umbrella.UI
{
    public partial class Login : Window
    {
        private readonly UmbrellaService umbrellaService = new UmbrellaService();
        private readonly KeyboardManager keyboardManager;

        public Login()
        {
            InitializeComponent();

            keyboardManager = new KeyboardManager(this);
            keyboardManager.KeyDown += KeyboardManagerOnKeyDown;
        }

        private void KeyboardManagerOnKeyDown(object sender, KeyEventArgs args)
        {
            if (args.Key != Key.Enter) 
                return;

            var authenticationManager = new AuthenticationManager();
            var userService = new UserService(authenticationManager);

            try
            {
                userService.Authentication(LoginTextBox.Text, PasswordTextBox.Password);
                umbrellaService.Do();
            }
            catch (InvalidUserException e)
            {
                MessageBox.Show("Упсс ... аутенификация в домене VIAcode не проходит :(.");
            }
        }
    }
}
