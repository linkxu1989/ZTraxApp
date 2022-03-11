using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using ZTraxApp.Commands;
using ZTraxApp.Models;

namespace ZTraxApp.ViewModels
{
    public class FrontpanelViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public FrontpanelViewModel()
        {
            //CurrentImage = new BitmapImage();
            //LoadInfo();
            LoadImage();
            refreshCommand = new RelayCommand(Refresh);
            leftCommand = new RelayCommand(Left);
            upCommand = new RelayCommand(Up);
            rightCommand = new RelayCommand(Right);
            downCommand = new RelayCommand(Down);
            okCommand = new RelayCommand(OK);
            p1Command = new RelayCommand(P1);
            p2Command = new RelayCommand(P2);
            pauseCommand = new RelayCommand(Pause);
            feedCommand = new RelayCommand(Feed);
            cancelCommand = new RelayCommand(Cancel);
            r0Command = new RelayCommand(R0);
            r90Command = new RelayCommand(R90);
            r180Command = new RelayCommand(R180);
            r270Command = new RelayCommand(R270);
            normalCommand = new RelayCommand(Normal);
            invertedCommand = new RelayCommand(Inverted);
            autoCommand = new RelayCommand(Auto);
            resetCommand = new RelayCommand(Reset);
            calibrateCommand = new RelayCommand(Calibrate);
            //saveCommand = new RelayCommand(Save);
            //searchCommand = new RelayCommand(Search);
            //updateCommand = new RelayCommand(Update);
            //deleteCommand = new RelayCommand(Delete);
        }

        #region Display Operation
        private string _PrinterIP = Properties.Settings.Default.ipAddress;
        //private string _SelectedPrinter;

        public string PrinterIP
        {
            get { return _PrinterIP; }
            set
            {
                _PrinterIP = value;
                OnPropertyChanged("PrinterIP");
            }
        }

        private string _PrinterInfo;
        public string SelectedPrinterInfo
        {
            get { return _PrinterInfo; }
            set
            {
                _PrinterInfo = value;
                OnPropertyChanged("SelectedPrinterInfo");
            }
        }

        private BitmapImage _PrinterImage;
        public BitmapImage SelectedPrinterImage
        {
            get { return _PrinterImage; }
            set
            {
                _PrinterImage = value;
                OnPropertyChanged("SelectedPrinterImage");
            }
        }

        private async void LoadImage()
        {
            await Task.Run(() =>
            {
                Visibility = Visibility.Visible;
                int port = 9100;
                string printerip = PrinterIP;
                string image_command = @"! U1 getvar " + '"' + @"display.image" + '"' + @" ";
                string string_command = @"~hi" + @" ";
                SelectedPrinterInfo = CommonService.GetPrintInfo(printerip, string_command, port);
                Properties.Settings.Default.ipAddress = PrinterIP;
                Properties.Settings.Default.Save();
                
                SelectedPrinterImage = CommonService.GetPrintImage(printerip, image_command, port);

                if (SelectedPrinterImage != null)
                {
                    if (SelectedPrinterImage.CanFreeze)
                        SelectedPrinterImage.Freeze();
                }

                Visibility = Visibility.Hidden;
            });
        }

        //private async void LoadInfo()
        //{
        //    await Task.Run(() =>
        //    {
        //        Visibility = Visibility.Visible;
        //        int port = 9100;
        //        string printerip = PrinterIP;
        //        string string_command = @"~hi" + @" ";
        //        SelectedPrinterInfo = CommonService.GetPrintInfo(printerip, string_command, port);
        //        Properties.Settings.Default.ipAddress = PrinterIP;
        //        Properties.Settings.Default.Save();
        //        Visibility = Visibility.Hidden;
        //    });
        //}

        private async void SetData(string command)
        {
            await Task.Run(() =>
            {
                int port = 9100;
                string printerip = PrinterIP;
                Visibility = Visibility.Visible;
                CommonService.GetPrintInfo(printerip, command, port);
                Thread.Sleep(3000);
                Visibility = Visibility.Hidden;
                LoadImage();
            });
        }
        #endregion

        private BitmapImage currentImage;
        public BitmapImage CurrentImage
        {
            get { return currentImage; }
            set { currentImage = value; OnPropertyChanged("CurrentImage"); }
        }


        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        private Visibility visibility;
        public Visibility Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;
                OnPropertyChanged("Visibility");
            }
        }

        #region RefreshOperation
        private RelayCommand refreshCommand;

        public RelayCommand RefreshCommand
        {
            get { return refreshCommand; }
        }

        public void Refresh()
        {
            try
            {
                LoadImage();
                //LoadInfo();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region LeftOperation
        private RelayCommand leftCommand;

        public RelayCommand LeftCommand
        {
            get { return leftCommand; }
        }

        public void Left()
        {
            try
            {
                string command = @"! U1 setvar " + '"' + @"device.frontpanel.key_press" + '"' + @" " + '"' + @"J" + '"' + @" ";
                SetData(command);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region UpOperation
        private RelayCommand upCommand;

        public RelayCommand UpCommand
        {
            get { return upCommand; }
        }

        public void Up()
        {
            try
            {
                string command = @"! U1 setvar " + '"' + @"device.frontpanel.key_press" + '"' + @" " + '"' + @"L" + '"' + @" ";
                SetData(command);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region RightOperation
        private RelayCommand rightCommand;

        public RelayCommand RightCommand
        {
            get { return rightCommand; }
        }

        public void Right()
        {
            try
            {
                string command = @"! U1 setvar " + '"' + @"device.frontpanel.key_press" + '"' + @" " + '"' + @"K" + '"' + @" ";
                SetData(command);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region DownOperation
        private RelayCommand downCommand;

        public RelayCommand DownCommand
        {
            get { return downCommand; }
        }

        public void Down()
        {
            try
            {
                string command = @"! U1 setvar " + '"' + @"device.frontpanel.key_press" + '"' + @" " + '"' + @"M" + '"' + @" ";
                SetData(command);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region OKOperation
        private RelayCommand okCommand;

        public RelayCommand OKCommand
        {
            get { return okCommand; }
        }

        public void OK()
        {
            try
            {
                string command = @"! U1 setvar " + '"' + @"device.frontpanel.key_press" + '"' + @" " + '"' + @"N" + '"' + @" ";
                SetData(command);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region P1Operation
        private RelayCommand p1Command;

        public RelayCommand P1Command
        {
            get { return p1Command; }
        }

        public void P1()
        {
            try
            {
                string command = @"! U1 setvar " + '"' + @"device.frontpanel.key_press" + '"' + @" " + '"' + @"O" + '"' + @" ";
                SetData(command);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region P2Operation
        private RelayCommand p2Command;

        public RelayCommand P2Command
        {
            get { return p2Command; }
        }

        public void P2()
        {
            try
            {
                string command = @"! U1 setvar " + '"' + @"device.frontpanel.key_press" + '"' + @" " + '"' + @"P" + '"' + @" ";
                SetData(command);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region PauseOperation
        private RelayCommand pauseCommand;

        public RelayCommand PauseCommand
        {
            get { return pauseCommand; }
        }

        public void Pause()
        {
            try
            {
                string command = @"! U1 setvar " + '"' + @"device.frontpanel.key_press" + '"' + @" " + '"' + @"A" + '"' + @" ";
                SetData(command);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region FeedOperation
        private RelayCommand feedCommand;

        public RelayCommand FeedCommand
        {
            get { return feedCommand; }
        }

        public void Feed()
        {
            try
            {
                string command = @"! U1 setvar " + '"' + @"device.frontpanel.key_press" + '"' + @" " + '"' + @"B" + '"' + @" ";
                SetData(command);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region CancelOperation
        private RelayCommand cancelCommand;

        public RelayCommand CancelCommand
        {
            get { return cancelCommand; }
        }

        public void Cancel()
        {
            try
            {
                string command = @"! U1 setvar " + '"' + @"device.frontpanel.key_press" + '"' + @" " + '"' + @"C" + '"' + @" ";
                SetData(command);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region R0Operation
        private RelayCommand r0Command;

        public RelayCommand R0Command
        {
            get { return r0Command; }
        }

        public void R0()
        {
            try
            {
                string command = @"! U1 setvar " + '"' + @"display.orientation" + '"' + @" " + '"' + @"0" + '"' + @" ";
                SetData(command);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region R90Operation
        private RelayCommand r90Command;

        public RelayCommand R90Command
        {
            get { return r90Command; }
        }

        public void R90()
        {
            try
            {
                string command = @"! U1 setvar " + '"' + @"display.orientation" + '"' + @" " + '"' + @"90" + '"' + @" ";
                SetData(command);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region R18Operation
        private RelayCommand r180Command;

        public RelayCommand R180Command
        {
            get { return r180Command; }
        }

        public void R180()
        {
            try
            {
                string command = @"! U1 setvar " + '"' + @"display.orientation" + '"' + @" " + '"' + @"180" + '"' + @" ";
                SetData(command);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region R270operation
        private RelayCommand r270Command;

        public RelayCommand R270Command
        {
            get { return r270Command; }
        }

        public void R270()
        {
            try
            {
                string command = @"! U1 setvar " + '"' + @"display.orientation" + '"' + @" " + '"' + @"270" + '"' + @" ";
                SetData(command);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion


        #region NormalOperation
        private RelayCommand normalCommand;

        public RelayCommand NormalCommand
        {
            get { return normalCommand; }
        }

        public void Normal()
        {
            try
            {
                string command = @"! U1 setvar " + '"' + @"display.orientation" + '"' + @" " + '"' + @"normal" + '"' + @" ";
                SetData(command);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region InvertedOperation
        private RelayCommand invertedCommand;

        public RelayCommand InvertedCommand
        {
            get { return invertedCommand; }
        }

        public void Inverted()
        {
            try
            {
                string command = @"! U1 setvar " + '"' + @"display.orientation" + '"' + @" " + '"' + @"inverted" + '"' + @" ";
                SetData(command);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region AutoOperation
        private RelayCommand autoCommand;

        public RelayCommand AutoCommand
        {
            get { return autoCommand; }
        }

        public void Auto()
        {
            try
            {
                string command = @"! U1 setvar " + '"' + @"display.orientation" + '"' + @" " + '"' + @"auto" + '"' + @" ";
                SetData(command);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region ResetOperation
        private RelayCommand resetCommand;

        public RelayCommand ResetCommand
        {
            get { return resetCommand; }
        }

        public void Reset()
        {
            try
            {
                string command = @"! U1 setvar " + '"' + @"device.reset" + '"' + @" " + '"' + @"now" + '"' + @" ";
                SetData(command);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region CalibrationOperation
        private RelayCommand calibrateCommand;

        public RelayCommand CalibrateCommand
        {
            get { return calibrateCommand; }
        }

        public void Calibrate()
        {
            try
            {
                string command = @"~JC" + @" ";
                SetData(command);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion
    }
}