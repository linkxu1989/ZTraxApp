using System;
using System.ComponentModel;

namespace ZTraxApp.Models
{
    public class Events : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; OnPropertyChanged("ID"); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }

        private DateTime timestamp;
        public DateTime TimeStamp
        {
            get { return timestamp; }
            set { timestamp = value; OnPropertyChanged("TimeStamp"); }
        }

        private string typeofevent;
        public string TypeOfEvent
        {
            get { return typeofevent; }
            set { typeofevent = value; OnPropertyChanged("TypeOfEvent"); }
        }

        private string hostname;
        public string Hostname
        {
            get { return hostname; }
            set { hostname = value; OnPropertyChanged("Hostname"); }
        }

        private string location;
        public string Location
        {
            get { return location; }
            set { location = value; OnPropertyChanged("Location"); }
        }

        private string tagid;
        public string TagID
        {
            get { return tagid; }
            set { tagid = value; OnPropertyChanged("TagID"); }
        }

        private string assetid;
        public string AssetID
        {
            get { return assetid; }
            set { assetid = value; OnPropertyChanged("AssetID"); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }
    }
}

