﻿using System;
using System.ComponentModel;
using System.Timers;

namespace ZTraxApp.ViewModels
{
    public class ClockViewModel : INotifyPropertyChanged

    {
        public ClockViewModel()
        {
            var timer = new Timer();
            timer.Interval = 1000;  // 1 second update.
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        public string Time
        {
            get { return DateTime.Now.ToLongTimeString(); }
        }

        public string Date
        {
            get { return DateTime.Now.ToString("yyyy/MM/dd"); }
        }

        public string Week
        {
            get { return DateTime.Now.ToString("dddd"); }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            NotifyPropertyChanged("Time");
            NotifyPropertyChanged("Date");
            NotifyPropertyChanged("Week");
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
