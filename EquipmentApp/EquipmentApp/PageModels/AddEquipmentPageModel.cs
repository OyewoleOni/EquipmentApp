using EquipmentApp.Data;
using EquipmentApp.Interfaces;
using EquipmentApp.Models;
using EquipmentApp.ViewModel;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace EquipmentApp.PageModels
{
    public class AddEquipmentPageModel : FreshBasePageModel
    {
        private IRestServices _restServices;

        public Command SaveCommand { get; set; }

        public List<EquipmentApp.Models.EquipmentType> Types { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private EquipmentApp.Models.EquipmentType selectedType;

        public EquipmentApp.Models.EquipmentType SelectedType
        {
            get { return selectedType; }
            set { selectedType = value; }
        }

        public AddEquipmentPageModel(IRestServices restServices)
        {
            _restServices = restServices;
            SaveCommand = new Command(saveEquipment);
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            Types = PopulateData.GetTypes();
        }

        private async void saveEquipment(object obj)
        {
            var equipment = new EquipmentPost()
            {
                Name = Name,
                Quantity = Quantity,
                Status = 1,
                StatusName = "Active",
                Type = SelectedType.Id,
                TypeName = SelectedType.TypeName
            };
            var result = await _restServices.PostEquipment(equipment);

            if (result)
                await CoreMethods.DisplayAlert("Hi", "Your record has been added successfully......", "Alright");
            else
                await CoreMethods.DisplayAlert("Opps", "Something went wrong......", "Ok");
        }
    }
}
