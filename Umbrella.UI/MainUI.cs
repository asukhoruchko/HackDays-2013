using System.Windows;
using System.Windows.Input;
using Umbrella.BL.Services;

namespace Umbrella.UI
{
    public class MainUI
    {
        public readonly OperationService OperationService = new OperationService();

        private readonly MainWindow window;

        public MainUI(MainWindow window)
        {
            this.window = window;
        }

        public void Init()
        {
            window.TakenListBox.ItemsSource = OperationService.GetTaken();
            Select();
        }

        public void Select()
        {
            window.MessageLabel.Content = "Добро пожаловать в наш зонтомат.";
            window.UmbrellaAppState = UmbrellaAppState.Main;
        }

        public void OnKeyDown(KeyEventArgs args)
        {
            if (window.UmbrellaAppState != UmbrellaAppState.Main)
                return;

            window.OperationLogGrid.Visibility = Visibility.Collapsed;
            window.LoginGrid.Visibility = Visibility.Visible;

            window.LoginUI.Select();

            args.Handled = true;
        }
    }
}
