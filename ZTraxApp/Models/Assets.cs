using System.ComponentModel;

namespace ZTraxApp.Models
{
    public class Assets : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private int assetID;
        public int AssetID
        {
            get { return assetID; }
            set { assetID = value; OnPropertyChanged("AssetID"); }
        }

        private string assetNo;
        public string AssetNo
        {
            get { return assetNo; }
            set { assetNo = value; OnPropertyChanged("AssetNo"); }
        }

        private string equipNo;
        public string EquipNo
        {
            get { return equipNo; }
            set { equipNo = value; OnPropertyChanged("EquipNo"); }
        }

        private string manufacturer;
        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; OnPropertyChanged("Manufacturer"); }
        }

        private string serialNo;
        public string SerialNo
        {
            get { return serialNo; }
            set { serialNo = value; OnPropertyChanged("SerialNo"); }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged("Status"); }
        }

        private string manufModelNo;
        public string ManufModelNo
        {
            get { return manufModelNo; }
            set { manufModelNo = value; OnPropertyChanged("ManufModelNo"); }
        }

        private string barcode;
        public string Barcode
        {
            get { return barcode; }
            set { barcode = value; OnPropertyChanged("Barcode"); }
        }

        private string srvInterval;
        public string SrvInterval
        {
            get { return srvInterval; }
            set { srvInterval = value; OnPropertyChanged("SrvInterval"); }
        }

        private string svrDueDate;
        public string SvrDueDate
        {
            get { return svrDueDate; }
            set { svrDueDate = value; OnPropertyChanged("SvrDueDate"); }
        }


    }
}

