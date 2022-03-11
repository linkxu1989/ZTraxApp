using System.ComponentModel;

namespace ZTraxApp.Models
{
    public class Readers : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private string hostname;
        public string HostName
        {
            get { return hostname; }
            set { hostname = value; OnPropertyChanged("HostName"); }
        }

        private string ipAddress;
        public string IPAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; OnPropertyChanged("IPAddress"); }
        }

        //private bool isConnected;
        //public bool IsConnected
        //{
        //    get { return isConnected; }
        //    set { isConnected = value; OnPropertyChanged("IsConnected"); }
        //}

        private string locDescription;
        public string LocDescription
        {
            get { return locDescription; }
            set { locDescription = value; OnPropertyChanged("LocDescription"); }
        }

        //private string isReading;
        //public string IsReading
        //{
        //    get { return isReading; }
        //    set { isReading = value; OnPropertyChanged("IsReading"); }
        //}

    }
}


