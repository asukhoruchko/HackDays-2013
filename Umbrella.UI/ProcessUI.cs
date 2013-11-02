using System.Threading;
using System.Windows.Input;
using System.Windows.Threading;
using Umbrella.BL.Entity;
using Umbrella.Core;

namespace Umbrella.UI
{
    public class ProcessUI
    {
        private readonly CdManager cdManager = new CdManager();

        private readonly MainWindow window;
        private bool isClosed;
        private const int TIMER_PERIOD = 15*1000;
        private Thread timerThread;

        public ProcessUI(MainWindow window)
        {
            this.window = window;
            window.KeyboardManager.KeyDown += OnKeyDown;
        }

        private void OnKeyDown(object sender, KeyEventArgs args)
        {
            if (args.Handled)
                return;

            if (window.UmbrellaAppState != UmbrellaAppState.Process) 
                return;

            if (args.Key != Key.Enter)
                return;
            
            window.MainUI.Select();
            Finish();
        }

        private void Finish()
        {
            lock (this)
            {
                if (!isClosed)
                {
                    cdManager.CloseDrives();
                    timerThread.Abort();
                    isClosed = true;
                }
            }
        }

        public void Process(User user)
        {
            cdManager.OpenDrives();
            isClosed = false;
            WaitToFinish();
        }

        private void WaitToFinish()
        {
            timerThread = new Thread(Timer);
            timerThread.Start();
        }

        private void Timer()
        {
            Thread.Sleep(TIMER_PERIOD);
            window.Dispatcher.Invoke(UpdateMainUI, DispatcherPriority.Normal);
            Finish();
        }

        private void UpdateMainUI()
        {
            window.MainUI.Select();
        }

        public void Select()
        {
            window.UmbrellaAppState = UmbrellaAppState.Process;
            window.MessageLabel.Content = "Вы можете взять или вернуть зонтик.";
        }
    }
}
