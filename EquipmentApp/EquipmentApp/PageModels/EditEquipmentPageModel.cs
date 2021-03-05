using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EquipmentApp.PageModels
{
    public class EditEquipmentPageModel : FreshBasePageModel
    {
        public Command EditCommand { get; set; }

        public List<EquipmentApp.Models.EquipmentType> Types { get; set; }

        public EditEquipmentPageModel()
        {
            
        }
    }
}
