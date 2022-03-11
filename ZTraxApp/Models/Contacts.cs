using System.ComponentModel;

namespace ZTraxApp.Models
{
    public class Contacts : INotifyPropertyChanged
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

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged("LastName "); }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged("FirstName"); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }

        private string imAccountID;
        public string IMAccountID
        {
            get { return imAccountID; }
            set { imAccountID = value; OnPropertyChanged("IMAccountID"); }
        }

        private string orgID;
        public string OrgID
        {
            get { return orgID; }
            set { orgID = value; OnPropertyChanged("OrgID"); }
        }

        private string imEmployeeNo;
        public string IMEmployeeNo
        {
            get { return imEmployeeNo; }
            set { imEmployeeNo = value; OnPropertyChanged("IMEmployeeNo"); }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; OnPropertyChanged("Phone"); }
        }

        private string fax;
        public string Fax
        {
            get { return fax; }
            set { fax = value; OnPropertyChanged("Fax"); }
        }

        private string superuser;
        public string Superuser
        {
            get { return superuser; }
            set { superuser = value; OnPropertyChanged("Superuser"); }
        }

        private string globalRead;
        public string GlobalRead
        {
            get { return globalRead; }
            set { globalRead = value; OnPropertyChanged("GlobalRead"); }
        }

        private string groupName;
        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; OnPropertyChanged("GroupName"); }
        }

        private string login;
        public string Login
        {
            get { return login; }
            set { login = value; OnPropertyChanged("Login"); }
        }

        private string contactLoginID;
        public string ContactLoginID
        {
            get { return contactLoginID; }
            set { contactLoginID = value; OnPropertyChanged("ContactLoginID"); }
        }

        private string lastUpdate;
        public string LastUpdate
        {
            get { return lastUpdate; }
            set { lastUpdate = value; OnPropertyChanged("LastUpdate"); }
        }

        private string emAccountID;
        public string EmAccountID
        {
            get { return emAccountID; }
            set { emAccountID = value; OnPropertyChanged("EmAccountID"); }
        }

        private string emid;
        public string Emid
        {
            get { return emid; }
            set { emid = value; OnPropertyChanged("Emid"); }
        }

        private string partOfProvider;
        public string PartOfProvider
        {
            get { return partOfProvider; }
            set { partOfProvider = value; OnPropertyChanged("PartOfProvider"); }
        }

        private string providerID;
        public string ProviderID
        {
            get { return providerID; }
            set { providerID = value; OnPropertyChanged("ProviderID"); }
        }

        private string notes;
        public string Notes
        {
            get { return notes; }
            set { notes = value; OnPropertyChanged("Notes"); }
        }

        private string integrationId1;
        public string IntegrationId1
        {
            get { return integrationId1; }
            set { integrationId1 = value; OnPropertyChanged("IntegrationId1"); }
        }

        private string integrationId2;
        public string IntegrationId2
        {
            get { return integrationId2; }
            set { integrationId2 = value; OnPropertyChanged("IntegrationId2"); }
        }

        private string managerID;
        public string ManagerID
        {
            get { return managerID; }
            set { managerID = value; OnPropertyChanged("ManagerID"); }
        }

        private string locID;
        public string LocID
        {
            get { return locID; }
            set { locID = value; OnPropertyChanged("LocID"); }
        }

        private string shipToLocID;
        public string ShipToLocID
        {
            get { return shipToLocID; }
            set { shipToLocID = value; OnPropertyChanged("ShipToLocID"); }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged("Status"); }
        }

        private string permOrg;
        public string PermOrg
        {
            get { return permOrg; }
            set { permOrg = value; OnPropertyChanged("PermOrg"); }
        }
        private string permLoc;
        public string PermLoc
        {
            get { return permLoc; }
            set { permLoc = value; OnPropertyChanged("PermLoc"); }
        }

        private string permContact;
        public string PermContact
        {
            get { return permContact; }
            set { permContact = value; OnPropertyChanged("PermContact"); }
        }

        private string permProvider;
        public string PermProvider
        {
            get { return permProvider; }
            set { permProvider = value; OnPropertyChanged("PermProvider"); }
        }

        private string permLoan;
        public string PermLoan
        {
            get { return permLoan; }
            set { permLoan = value; OnPropertyChanged("PermLoan"); }
        }

        private string createDate;
        public string CreateDate
        {
            get { return createDate; }
            set { createDate = value; OnPropertyChanged("CreateDate"); }
        }

    }
}
