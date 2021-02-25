using EquipmentApp.PageModels;
using EquipmentApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EquipmentApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EquipmentPage : ContentPage
    {
        public EquipmentPage()
        {
            InitializeComponent();
        }

       
        private void btnEdit_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            var equipment = button.BindingContext as EquipmentViewModel;

            var vm = BindingContext as EquipmentPageModel;

            vm?.EditEquipmentCommand.Execute(equipment);
        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            var equipment = button.BindingContext as EquipmentViewModel;

            var vm = BindingContext as EquipmentPageModel;

            vm?.DeleteEquipmentCommand.Execute(equipment);
        }
    }
}