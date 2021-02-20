using EquipmentApp.Interfaces;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentApp.PageModels
{
    public class AddEquipmentPageModel : FreshBasePageModel
    {
        private IRestServices _restServices;

        public AddEquipmentPageModel(IRestServices restServices)
        {
            _restServices = restServices;
        }
    }
}
