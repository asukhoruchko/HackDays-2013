using System;
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
        private readonly ImageComposer imageComposer = new ImageComposer();
        
        public KeyboardManager KeyboardManager;
        public UmbrellaAppState UmbrellaAppState;
        
        public LoginUI LoginUI { get; private set; }
        public MainUI MainUI { get; private set; }
        public ProcessUI ProcessUI { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            UmbrellaAppState = UmbrellaAppState.Main;

            KeyboardManager = new KeyboardManager(this);
            KeyboardManager.KeyDown += KeyboardManagerOnKeyDown;
            KeyboardManager.UmbrellaKeyDown += KeyboardManagerOnUmbrella;
            KeyboardManager.UmbreallaKeyUp += KeyboardManagerOnUmbrella;

            LoginUI = new LoginUI(this);
            MainUI = new MainUI(this);
            ProcessUI = new ProcessUI(this);
            MainUI.Init();

            WindowState = WindowState.Maximized;

            UmbrellaStatusesImage.Source = imageComposer.Combine(KeyboardManager.UmbrellaStatuses);
        }

        private void KeyboardManagerOnUmbrella(object sender, KeyEventArgs args)
        {
            UmbrellaStatusesImage.Source = imageComposer.Combine(KeyboardManager.UmbrellaStatuses);
        }

        private void KeyboardManagerOnKeyDown(object sender, KeyEventArgs args)
        {
            switch (UmbrellaAppState)
            {
                case UmbrellaAppState.Main:
                    MainUI.OnKeyDown(args);
                    break;

                case UmbrellaAppState.Login:
                    LoginUI.OnKeyDown(args);
                    break;
            }
        }
    }
}
