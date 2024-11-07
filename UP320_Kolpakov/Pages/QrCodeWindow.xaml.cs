using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using QRCoder;

namespace UP320_Kolpakov.Pages
{
    /// <summary>
    /// Логика взаимодействия для QrCodeWindow.xaml
    /// </summary>
    public partial class QrCodeWindow : Window
    {
        public QrCodeWindow()
        {
            InitializeComponent();
            QRCode();
        }
        private void QRCode()
        {

            string url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);


            Bitmap qrCodeImage = qrCode.GetGraphic(20);


            imageQr.Source = ConvertBitmapToBitmapImage(qrCodeImage);
        }

        private BitmapImage ConvertBitmapToBitmapImage(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }
    }
}
