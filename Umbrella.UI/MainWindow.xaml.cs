using System;
using System.Windows;
using System.Windows.Input;
using Umbrella.Core;

namespace Umbrella.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly KeyboardManager keyboardManager;

        public MainWindow()
        {
            InitializeComponent();
            
            keyboardManager = new KeyboardManager(this);
            keyboardManager.KeyDown += KeyboardManagerOnKeyDown;
            keyboardManager.UmbrellaKeyDown += KeyboardManagerOnUmbrellaKeyDown;
        }

        private void KeyboardManagerOnUmbrellaKeyDown(object sender, KeyEventArgs args)
        {
            MessageBox.Show("Ubrella key down.");
        }

        private void KeyboardManagerOnKeyDown(object sender, KeyEventArgs args)
        {
            MessageBox.Show("Just a key down.");
        }
    }
}
