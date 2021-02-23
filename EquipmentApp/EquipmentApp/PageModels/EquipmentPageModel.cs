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

        public EquipmentPageModel(IRestServices restServices)
        {
            _restServices = restServices;
            Equipments = new ObservableCollection<EquipmentViewModel>();
            LoadEquipments();
            AddEquipmentCommand = new Command(addEquipment);
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
        }

        private Equipment selectedEquipment;

        public Equipment SelectedEquipment
        {
            get { return selectedEquipment; }
            set
            {
                selectedEquipment = value;
                if (selectedEquipment != null)
                {
                    CoreMethods.PushPageModel<EquipmentDetailPageModel>(selectedEquipment);
                }

            }
        }
    }
}
