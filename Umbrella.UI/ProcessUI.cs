using System.Threading;
using System.Windows.Input;
using System.Windows.Threading;
using Umbrella.BL.Database;
using Umbrella.BL.Entity;
using Umbrella.BL.Services;
using Umbrella.Core;

namespace Umbrella.UI
{
    public class ProcessUI
    {
        private readonly object locker;
        
        private readonly CdManager cdManager = new CdManager();
        private readonly OperationService operationService = new OperationService(new SessionFactory("default", 10));

        private readonly MainWindow window;
        private bool isClosed;
        private const int TIMER_PERIOD = 15*1000;
        private Thread timerThread;

        private int umbrellasOnStart;
        private User currentUser;

        public ProcessUI(MainWindow window)
        {
            locker = new object();
            
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
            lock (locker)
            {
                if (!isClosed)
                {
                    cdManager.CloseDrives();
                    
                    operationService.Update(currentUser, window.KeyboardManager.ExistingCount() - umbrellasOnStart);
                    isClosed = true;
                    currentUser = null;
                    umbrellasOnStart = 0;

                    timerThread.Abort();
                }
            }
        }

        public void Process(User user)
        {            
            currentUser = user;
            umbrellasOnStart = window.KeyboardManager.ExistingCount();
            cdManager.OpenDrives();
            isClosed = false;
            WaitToFinish();
        }

        private void WaitToFinish()
        {
            timerThread = new Thread(Timer);
            timerThread.SetApartmentState(ApartmentState.STA);
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
