using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Umbrella.BL.Services;

namespace Umbrella.UI
{
    public class MainUI
    {
        private readonly OperationService operationService = new OperationService();

        private readonly MainWindow window;

        public MainUI(MainWindow window)
        {
            this.window = window;
        }

        public void Init()
        {
            var operations = operationService.GetTaken();
            foreach (var operation in operations)
            {
                var item = new ListBoxItem { Content = operation.User.LastName };
                window.TakenListBox.Items.Add(item);
            }
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
