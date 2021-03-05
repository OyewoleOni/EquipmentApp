using EquipmentApp.Data;
using EquipmentApp.Interfaces;
using EquipmentApp.Models;
using EquipmentApp.Pages;
using EquipmentApp.ViewModel;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EquipmentApp.PageModels
{
    public class AddEquipmentPageModel : FreshBasePageModel
    {
        private IRestServices _restServices;


        public ICommand SaveCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        public List<EquipmentApp.Models.EquipmentType> Types { get; set; }

        public AddEquipmentPageModel(IRestServices restServices)
        {
            _restServices = restServices;

            SaveCommand = new Command(async () => await saveEquipment());
            LogoutCommand = new Command(logout);
        }

        private void logout(object obj)
        {
            CoreMethods.PushPageModel<LoginPageModel>();
        }

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
            set
            {
                selectedType = value;
                RaisePropertyChanged();
            }
        }

        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }


        private EquipmentViewModel _equipment;

        public EquipmentViewModel Equipment
        {
            get { return _equipment; }
            set
            {
                _equipment = value;
                RaisePropertyChanged();
            }
        }


       

        public override void Init(object initData)
        {
            base.Init(initData);

            Equipment = (EquipmentViewModel)initData;
            if(Equipment != null)
            {
                Types = PopulateData.GetTypes();
                SelectedType = Equipment.Type;
                Name = Equipment.Name;
                Quantity = Equipment.Quantity;
                Id = Equipment.Id;
            }
            else
            {
                Types = PopulateData.GetTypes();
            }
        }

        private async Task saveEquipment()
        {
            if(Id == null)
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
                try
                {
                    var isCreated = await _restServices.PostEquipment(equipment);

                    if (isCreated)
                    {
                        var result = await CoreMethods.DisplayAlert("Hi", "Your record has been added successfully......", "Alright", "Cancel");
                        if (result)
                        {
                            await CoreMethods.PushPageModel<EquipmentPageModel>();
                        }
                    }
                    else
                    {
                        await CoreMethods.DisplayAlert("Opps", "Something went wrong......", "Ok");
                    }
                }
                catch (Exception)
                {
                    //log errors here
                    throw;
                }

            }
            else
            {
                var equipment = new EquipmentUpdate()
                {
                    Id = Id,
                    Name = Name,
                    Quantity = Quantity,
                    Status = 1,
                    StatusName = "Active",
                    Type = SelectedType.Id,
                    TypeName = SelectedType.TypeName
                };

                var isUpdated = await _restServices.UpdateEquipment(equipment);
                if (isUpdated)
                {
                    var result = await CoreMethods.DisplayAlert("Hi", "Your record has been updated successfully......", "Alright", "Cancel");
                    if (result)
                    {
                        await CoreMethods.PushPageModel<EquipmentPageModel>();
                    }
                }
                else
                {
                    await CoreMethods.DisplayAlert("Opps", "Something went wrong......", "Ok");
                }
            }

        }

    }
}
