﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ZTraxApp.ViewModels;
using ZTraxApp.Models;
using ZTraxApp.Commands;
using System.Collections.ObjectModel;
using System.Windows;

namespace ZTraxApp.ViewModels
{
    public class EventsViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        EventService ObjEventservice;
        public EventsViewModel()
        {
            ObjEventservice = new EventService();
            LoadData();
            CurrentEvents = new Events();
            refreshCommand = new RelayCommand(Refresh);
            //saveCommand = new RelayCommand(Save);
            //searchCommand = new RelayCommand(Search);
            //updateCommand = new RelayCommand(Update);
            //deleteCommand = new RelayCommand(Delete);
        }

        #region Display Operation
        private ObservableCollection<Events> eventsList;
        public ObservableCollection<Events> EventsList
        {
            get { return eventsList; }
            set { eventsList = value; OnPropertyChanged("EventsList"); }
        }

        private async void LoadData()
        {
            await Task.Run(() =>
            {
                Visibility = Visibility.Visible;
                EventsList = new ObservableCollection<Events>(ObjEventservice.GetAll());
                Visibility = Visibility.Hidden;
            });
        }
        #endregion

        private Events currentEvents;
        public Events CurrentEvents
        {
            get { return currentEvents; }
            set { currentEvents = value; OnPropertyChanged("CurrentEvents"); }
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
                LoadData();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion
        //#region SaveOperation
        //private RelayCommand saveCommand;
        //public RelayCommand SaveCommand
        //{
        //    get { return saveCommand; }
        //}

        //public void Save()
        //{
        //    try
        //    {
        //        var IsSaved = ObjContactservice.Add(CurrentContacts);
        //        LoadData();
        //        if (IsSaved)
        //            Message = "Contacts saved";
        //        else
        //            Message = "Save operation failed";
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = ex.Message;
        //    }
        //}
        //#endregion

        //#region SearchOperation
        //private RelayCommand searchCommand;

        //public RelayCommand SearchCommand
        //{
        //    get { return searchCommand; }
        //}


        //public void Search()
        //{
        //    try
        //    {
        //        var ObjContacts = ObjContactservice.Search(currentContacts.Id);
        //        if (ObjContacts != null)
        //        {
        //            CurrentContacts.Name = ObjContacts.Name;
        //            currentContacts.Age = ObjContacts.Age;
        //            Message = "";
        //        }
        //        else
        //        {
        //            Message = "Contacts not found";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = ex.Message;
        //    }
        //}
        //#endregion

        //#region UpdateOperation
        //private RelayCommand updateCommand;

        //public RelayCommand UpdateCommand
        //{
        //    get { return updateCommand; }
        //}

        //public void Update()
        //{
        //    try
        //    {
        //        var IsUpdate = ObjContactservice.Update(CurrentContacts);
        //        if(IsUpdate)
        //        {
        //            Message = "Contacts Updated";
        //        }
        //        else
        //        {
        //            Message = "Update Operation Failed";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = ex.Message;
        //    }
        //}
        //#endregion

        //#region DeleteOperation
        //private RelayCommand deleteCommand;

        //public RelayCommand DeleteCommand
        //{
        //    get { return deleteCommand; }
        //}

        //public void Delete()
        //{
        //    try
        //    {
        //        var IsDelete = ObjContactservice.Delete(CurrentContacts.Id);
        //        if(IsDelete)
        //        {
        //            Message = "Contacts deleted";
        //            LoadData();
        //        }
        //        else
        //        {
        //            Message = "Delete operation failed";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = ex.Message;
        //    }
        //}
        //#endregion

    }
}
