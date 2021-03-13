using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EquipmentApp.PageModels
{
    public class SampleLoginPageModel : FreshBasePageModel
    {

        public ICommand LoginCommand { get; set; }
        public SampleLoginPageModel()
        {
            LoginCommand = new Command(login);
        }

        private void login(object obj)
        {
            CoreMethods.PushPageModel<SampleSale1PageModel>();
        }
    }
}
