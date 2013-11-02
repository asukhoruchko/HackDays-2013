using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Umbrella.Core
{
    public class CdManager
    {
        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(String command, StringBuilder buffer, Int32 bufferSize, IntPtr hwndCallback);

        public void OpenDrive()
        {
            mciSendString("set CDAudio door open", null, 0, IntPtr.Zero);
        }

        public void CloseDrive()
        {
            mciSendString("set CDAudio door closed", null, 0, IntPtr.Zero);
        }
    }
}
