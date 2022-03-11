using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTraxApp.Models
{
    public class Badges : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private string lastname;
        public string LASTNAME
        {
            get { return lastname; }
            set { lastname = value; OnPropertyChanged("LASTNAME"); }
        }

        private string firstname;
        public string FIRSTNAME
        {
            get { return firstname; }
            set { firstname = value; OnPropertyChanged("FIRSTNAME"); }
        }

        private string email;
        public string EMAIL
        {
            get { return email; }
            set { email = value; OnPropertyChanged("EMAIL"); }
        }

        private string employee;
        public string EMPLOYEE
        {
            get { return employee; }
            set { employee = value; OnPropertyChanged("EMPLOYEE"); }
        }

        private DateTime createdtime;
        public DateTime CREATEDTIME
        {
            get { return createdtime; }
            set { createdtime = value; OnPropertyChanged("CREATEDTIME"); }
        }


    }
}


