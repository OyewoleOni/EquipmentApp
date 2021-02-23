using EquipmentApp.Interfaces;
using EquipmentApp.Models;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EquipmentApp.PageModels
{
    public class AddEquipmentPageModel : FreshBasePageModel
    {
        private IRestServices _restServices;

        public Command SaveCommand { get; set; }

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

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public AddEquipmentPageModel(IRestServices restServices)
        {
            _restServices = restServices;
            SaveCommand = new Command(saveEquipment);
        }

        private void saveEquipment(object obj)
        {
            var equipment = new Equipment()
            {
                Name = Name,
                Quantity = Quantity,
                Status = 1,
                StatusName = "Active"
            };
        }
    }
}
