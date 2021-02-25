using EquipmentApp.Interfaces;
using EquipmentApp.Models;
using EquipmentApp.PageModels;
using EquipmentApp.ViewModel;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace EquipmentApp.PageModels
{
    public class EquipmentPageModel : FreshBasePageModel
    {
        private IRestServices _restServices;

        public ObservableCollection<EquipmentViewModel> Equipments { get; set; }
        public Command AddEquipmentCommand { get; set; }
        public Command DeleteEquipmentCommand { get; set; }

        public EquipmentPageModel(IRestServices restServices)
        {
            _restServices = restServices;
            Equipments = new ObservableCollection<EquipmentViewModel>();
            LoadEquipments();
            AddEquipmentCommand = new Command(addEquipment);
            DeleteEquipmentCommand = new Command(deleteEquipment);
        }

        private async void deleteEquipment(object obj)
        {
            var content = obj as EquipmentViewModel;
            var isDeleted = await _restServices.DeleteEquipment(content.Id);
            if (isDeleted)
            {
                Equipments.Remove(content);
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

    }
}
