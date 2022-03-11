using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ZTraxApp.Models
{
    public class Locations : INotifyPropertyChanged
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

        private string full_Name;
        public string FULL_NAME
        {
            get { return full_Name; }
            set { full_Name = value; OnPropertyChanged("FULL_NAME"); }
        }

        private string type;
        public string TYPE
        {
            get { return type; }
            set { type = value; OnPropertyChanged("TYPE"); }
        }

        private string short_Name;
        public string SHORT_NAME
        {
            get { return short_Name; }
            set { short_Name = value; OnPropertyChanged("SHORT_NAME"); }
        }

        private string name;
        public string NAME
        {
            get { return name; }
            set { name = value; OnPropertyChanged("NAME"); }
        }

        private string classBarCode;
        public string CLASSBARCODE
        {
            get { return classBarCode; }
            set { classBarCode = value; OnPropertyChanged("CLASSBARCODE"); }
        }

        private string bardcode;
        public string BARCODE
        {
            get { return bardcode; }
            set { bardcode = value; OnPropertyChanged("BARCODE"); }
        }

        private string city;
        public string City
        {
            get { return city; }
            set { city = value; OnPropertyChanged("City"); }
        }

        private string country;
        public string Country
        {
            get { return country; }
            set { country = value; OnPropertyChanged("Country"); }
        }

    }
}

