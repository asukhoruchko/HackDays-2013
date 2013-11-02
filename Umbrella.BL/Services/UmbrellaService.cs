using System.Windows;
using Umbrella.BL.Entity;
using Umbrella.Core;
using System.Windows.Input;

namespace Umbrella.BL.Services
{
    public class UmbrellaService
    {
        private readonly CdManager cdManager = new CdManager();
        private readonly KeyboardManager keyboardManager;

        public UmbrellaService(DependencyObject dependencyObject)
        {
            keyboardManager = new KeyboardManager(dependencyObject);
            keyboardManager.UmbrellaKeyDown += KeyboardManagerOnUmbrellaKeyDown;
        }

        private void KeyboardManagerOnUmbrellaKeyDown(object sender, KeyEventArgs args)
        {
                        
        }

        public void Do(User user)
        {
            cdManager.OpenDrives();
        }
    }
}
