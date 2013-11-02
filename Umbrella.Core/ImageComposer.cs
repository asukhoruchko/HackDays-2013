using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace Umbrella.Core
{
    public class ImageComposer
    {
        private string PATH = @"Images\";

        public BitmapSource Combine(IEnumerable<bool> umbrellaStatuses)
        {
            Bitmap finalImage = new Bitmap(500, 500);

            using (Graphics g = Graphics.FromImage(finalImage))
            {
                g.Clear(Color.Transparent);

                int i = 1;
                foreach (bool umbrellaStatus in umbrellaStatuses)
                {
                    string fileName;
                    if (umbrellaStatus)
                        fileName = PATH + "r" + i + ".png";
                    else
                        fileName = PATH + "w" + i + ".png";

                    Bitmap image = new Bitmap(fileName);
                    i++;

                    g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
                    
                }
            }

            return Bitmap2BitmapImage(finalImage);
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        private BitmapSource Bitmap2BitmapImage(Bitmap bitmap)
        {
            IntPtr hBitmap = bitmap.GetHbitmap();
            BitmapSource retval;

            try
            {
                retval = Imaging.CreateBitmapSourceFromHBitmap(
                             hBitmap,
                             IntPtr.Zero,
                             Int32Rect.Empty,
                             BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                DeleteObject(hBitmap);
            }

            return retval;
        }
    }
}
