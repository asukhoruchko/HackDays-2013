using System.Windows;
using System.Windows.Input;
using Umbrella.Core;

namespace Umbrella.UI
{
    public enum UmbrellaAppState
    {
        Main,
        Login,
        Process
    }

    public partial class MainWindow : Window
    {
        private readonly KeyboardManager keyboardManager;
        public UmbrellaAppState UmbrellaAppState;
        
        private readonly LoginUI loginUI;
        private readonly MainUI mainUI;

        public MainWindow()
        {
            InitializeComponent();

            loginUI = new LoginUI(this);
            mainUI = new MainUI(this);

            UmbrellaAppState = UmbrellaAppState.Main;
            mainUI.Init();

            keyboardManager = new KeyboardManager(this);
            keyboardManager.KeyDown += KeyboardManagerOnKeyDown;
            keyboardManager.UmbrellaKeyDown += KeyboardManagerOnUmbrellaKeyDown;

            WindowState = WindowState.Maximized;
        }


        private void KeyboardManagerOnUmbrellaKeyDown(object sender, KeyEventArgs args)
        {
            switch (UmbrellaAppState)
            {
                case UmbrellaAppState.Main:
                    break;

                case UmbrellaAppState.Login:
                    break;

                case UmbrellaAppState.Process:
                    break;
            }
        }

        private void KeyboardManagerOnKeyDown(object sender, KeyEventArgs args)
        {
            switch (UmbrellaAppState)
            {
                case UmbrellaAppState.Main:
                    mainUI.OnKeyDown(args);
                    break;

                case UmbrellaAppState.Login:
                    loginUI.OnKeyDown(args);
                    break;

                case UmbrellaAppState.Process:
                    break;
            }
        }
    }
}
