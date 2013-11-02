using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Umbrella.Core
{
    public class CdManager
    {
        private readonly char[] DRIVE_LETTERS = { 'E', 'F' };

        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(String command, string buffer, int bufferSize, int hwndCallback);

        public void OpenDrives()
        {
            foreach (char driveLetter in DRIVE_LETTERS)
                ThreadPool.QueueUserWorkItem(OpenDrive, driveLetter);

            Thread.Sleep(5 * 1000);
        }

        public void CloseDrives()
        {
            foreach (char driveLetter in DRIVE_LETTERS)
                ThreadPool.QueueUserWorkItem(CloseDrive, driveLetter);

            Thread.Sleep(5 * 1000);
        }

        private static void OpenDrive(object data)
        {
            char driveLetter = (char)data;

            string returnString = string.Empty;
            mciSendString("open " + driveLetter + ": type CDaudio shareable alias drive" + driveLetter, returnString, 0, 0);
            int result = mciSendString("set drive" + driveLetter + " door open", returnString, 0, 0);
            Console.Out.WriteLine("Set drive:" + result);
        }

        private void CloseDrive(object data)
        {
            char driveLetter = (char)data;

            string returnString = string.Empty;

            mciSendString("open " + driveLetter + ": type CDaudio shareable alias drive" + driveLetter, returnString, 0, 0);
            int result = mciSendString("set drive" + driveLetter + " door closed", returnString, 0, 0);
            Console.Out.WriteLine("Set drive:" + result);
        }
    }
}
