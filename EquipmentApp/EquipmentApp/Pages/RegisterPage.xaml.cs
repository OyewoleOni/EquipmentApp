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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void entUserName_Completed(object sender, EventArgs e)
        {
            entPassword.Focus();
        }

        private void entPassword_Completed(object sender, EventArgs e)
        {
            entConfirmPassword.Focus();
        }

        private void entConfirmPassword_Completed(object sender, EventArgs e)
        {
            btnRegister.Focus();
        }
    }
}