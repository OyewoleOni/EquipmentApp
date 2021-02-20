﻿using EquipmentApp.Interfaces;
using EquipmentApp.Models;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EquipmentApp.PageModels
{
    public class EquipmentPageModel : FreshBasePageModel
    {
        private IRestServices _restServices;

        public ObservableCollection<Equipment> Equipments { get; set; }

        public EquipmentPageModel(IRestServices restServices)
        {
            _restServices = restServices;
            Equipments = new ObservableCollection<Equipment>();
            LoadEquipments();
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
                    //CoreMethods.PushPageModel<EquipDetailsPageModel>(selectedEquipment);
                }

            }
        }
    }
}
