using EquipmentApp.Models;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EquipmentApp.Pages
{
   public class EquipmentDetailModel : FreshBasePageModel
    {
        public Equipment Equipment { get; set; }

        public Command EditCommand { get; set; }

        public EquipmentDetailModel()
        {
            EditCommand = new Command(editEquipment);
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            Equipment = (Equipment)initData;
        }

        private void editEquipment(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
