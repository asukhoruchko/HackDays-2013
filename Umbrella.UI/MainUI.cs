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
        }

        public void OnKeyDown(KeyEventArgs args)
        {
            window.OperationLogGrid.Visibility = Visibility.Collapsed;
            window.LoginGrid.Visibility = Visibility.Visible;
            window.UmbrellaAppState = UmbrellaAppState.Login;
            window.LoginTextBox.Focus();
            args.Handled = true;
        }
    }
}
