using EquipmentApp.Interfaces;
using EquipmentApp.Models;
using EquipmentApp.PageModels;
using EquipmentApp.ViewModel;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EquipmentApp.PageModels
{
    public class EquipmentPageModel : FreshBasePageModel
    {
        private IRestServices _restServices;

        public ObservableCollection<EquipmentViewModel> Equipments { get; set; }
        public ICommand AddEquipmentCommand { get; set; }
        public ICommand DeleteEquipmentCommand { get; set; }
        public ICommand EditEquipmentCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public EquipmentPageModel(IRestServices restServices)
        {
            _restServices = restServices;
            Equipments = new ObservableCollection<EquipmentViewModel>();
            LoadEquipments();
            AddEquipmentCommand = new Command(addEquipment);
            DeleteEquipmentCommand = new Command(deleteEquipment);
            EditEquipmentCommand = new Command(editEqupment);
            SearchCommand = new Command(searchEquipment);
            LogoutCommand = new Command(logout);
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            User = (User)initData;
            //WelcomeMessage = $"Welcome  {User.UserName}";
            //IsOpen = true;
            if (User != null)
            {
                WelcomeMessage = $"Welcome  {User.UserName}";
                IsOpen = "True";
            }
            else
            {
                WelcomeMessage = "";
                IsOpen = "False";
            }
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

        }
        private void logout(object obj)
        {
            CoreMethods.PushPageModel<LoginPageModel>();
        }

        private async void searchEquipment(object obj)
        {
            var searchText = obj as string;

            var equipments = (string.IsNullOrWhiteSpace(searchText) ? await _restServices.GetEquipments() :
                                            await _restServices.SearchEquipment(searchText));
            Equipments.Clear();
            foreach (var equipment in equipments)
            {
                Equipments.Add(equipment);
            }
            IsBusy = false;
            HasItem = (Equipments.Count > 0) ? true : false;
        }

        private void editEqupment(object obj)
        {
            var equipment = obj as EquipmentViewModel;

            //MessagingCenter.Send(this, "edit", equipment);
            CoreMethods.PushPageModel<AddEquipmentPageModel>(equipment);

            // throw new NotImplementedException();
        }

        private async void deleteEquipment(object obj)
        {
            var content = obj as EquipmentViewModel;
            try
            {
                var result = await CoreMethods.DisplayAlert("Info", $"Are you sure you want to delete {content.Name}?", "Alright", "Cancel");
                if (result)
                {
                    var isDeleted = await _restServices.DeleteEquipment(content.Id);
                    if (isDeleted)
                    {
                        Equipments.Remove(content);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void addEquipment(object obj)
        {
            CoreMethods.PushPageModel<AddEquipmentPageModel>();
        }

        private async void LoadEquipments()
        {
            var equipments = await _restServices.GetEquipments();
            foreach (var equipment in equipments)
            {
                Equipments.Add(equipment);
            }
            IsBusy = false;
            HasItem = (Equipments.Count > 0) ? true : false;
        }

        private Equipment selectedEquipment;

        public Equipment SelectedEquipment
        {
            get { return null; }
            set
            {
                selectedEquipment = value;
                if (selectedEquipment != null)
                {
                    CoreMethods.PushPageModel<EquipmentDetailPageModel>(selectedEquipment);
                    RaisePropertyChanged();
                }

            }
        }

        private bool _hasItem = false;

        public bool HasItem
        {
            get { return _hasItem; }
            set
            {
                _hasItem = value;
                RaisePropertyChanged();
            }
        }


        private bool isBusy = true;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                RaisePropertyChanged();
            }
        }
        private User _user;

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        private string _welcomeMessage;

        public string WelcomeMessage
        {
            get { return _welcomeMessage; }
            set
            {
                _welcomeMessage = value;
                RaisePropertyChanged();
            }
        }

        private string _isOpen;

        public string IsOpen
        {
            get { return _isOpen; }
            set
            {
                _isOpen = value;
                RaisePropertyChanged();
            }
        }



    }
}
