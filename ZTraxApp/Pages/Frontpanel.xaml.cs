using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Zebra.Sdk.Comm;
using ZTraxApp.ViewModels;

namespace ZTraxApp.Pages
{
    /// <summary>
    /// Interaction logic for Frontpanel.xaml
    /// </summary>
    public partial class Frontpanel : Page
    {
        FrontpanelViewModel ViewModel;
        public Frontpanel()
        {
            InitializeComponent();
            ViewModel = new FrontpanelViewModel();
            this.DataContext = ViewModel;
            //ipAddress.Text = Properties.Settings.Default.ipAddress;
        }

        private void Image_Click(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 1)
            {
                //Point pointer = new Point();
                Point pointer = Mouse.GetPosition(e.Source as FrameworkElement);
                //MessageBox.Show(pointer.X.ToString() + "," + pointer.Y.ToString());
                int x_point = Convert.ToInt32(pointer.X);
                int y_point = Convert.ToInt32(pointer.Y);
                //MessageBox.Show(x_point.ToString() + y_point.ToString());
                string IPAdress = ipAddress.Text.ToString();
                int Port = 9100;
                string Command = @"! U1 getvar " + '"' + @"display.image" + '"' + @" ";
                string Pointer = @"! U1 setvar " + '"' + @"diag.simulate_touch_press_event" + '"' + @" " + '"' + x_point + "," + y_point + '"' + @" ";
                GetPrintImage(IPAdress, Pointer, Port);
                GetPrintImage(IPAdress, Command, Port);
                e.Handled = true;
            }
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            string IPAdress = ipAddress.Text.ToString();
            int Port = 9100;
            string Command = stringSend.Text.ToString();
            GetPrintString(IPAdress, Command, Port);
        }
        

        private void GetPrintImage(string theIpAddress, string Command, int Port)
        {
            // Instantiate connection for ZPL TCP port at given address
            Connection thePrinterConn = new TcpConnection(theIpAddress, Port);
            BitmapImage imageSource = new BitmapImage();
            try
            {
                // Open the connection - physical connection is established here.
                thePrinterConn.Open();
                // This example prints "This is a ZPL test." near the top of the label.
                //string Data = Command;

                byte[] byteCommand = Encoding.Default.GetBytes(Command);
                byte[] LinkOsbyteResponse = thePrinterConn.SendAndWaitForResponse(byteCommand, 1000, 2000, "\n\"\"");
                string received_string = Encoding.Default.GetString(LinkOsbyteResponse).TrimStart('"').TrimEnd('"');
                byte[] received_byte = Encoding.Default.GetBytes(received_string);
                //int data_length = Encoding.UTF8.GetBytes(received_data).Length;

                if (received_byte.Length > 2)
                {
                    MemoryStream ms = new MemoryStream(received_byte, 0, received_byte.Length);
                    //ms.Position = 0;
                    //ms.Seek(0, SeekOrigin.Begin);
                    imageSource.BeginInit();
                    imageSource.StreamSource = ms;
                    imageSource.EndInit();
                }
                //else
                //{
                //    imageSource.BeginInit();
                //    imageSource.UriSource = new Uri("/Resources/Image/noimage.png", UriKind.Relative);
                //    imageSource.EndInit();
                //}

                //return imageSource;
            }
            catch (Exception e)
            {
                // Handle communications error here.
                Console.WriteLine(e.ToString());
            }
            finally
            {
                // Close the connection to release resources.
                thePrinterConn.Close();
            }
            if (imageSource != null)
            {
                if (imageSource.CanFreeze)
                    imageSource.Freeze();
            }
            image.Source = imageSource;
        }

        private void GetPrintString(string theIpAddress, string Command, int Port)
        {
            // Instantiate connection for ZPL TCP port at given address
            Connection thePrinterConn = new TcpConnection(theIpAddress, Port);
            string received_string = "";
            try
            {
                // Open the connection - physical connection is established here.
                thePrinterConn.Open();
                // This example prints "This is a ZPL test." near the top of the label.
                //string Data = Command;

                byte[] byteCommand = Encoding.Default.GetBytes(Command);
                byte[] LinkOsbyteResponse = thePrinterConn.SendAndWaitForResponse(byteCommand, 1000, 2000, "\n\"\"");
                received_string = Encoding.Default.GetString(LinkOsbyteResponse);
            }
            catch (Exception e)
            {
                // Handle communications error here.
                Console.WriteLine(e.ToString());
            }
            finally
            {
                // Close the connection to release resources.
                thePrinterConn.Close();
            }
            stringResponse.Text += received_string;

        }

    }
}
