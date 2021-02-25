using EquipmentApp.Models;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EquipmentApp.PageModels
{
    public class RegisterPageModel : FreshBasePageModel
    {
        public System.Drawing.Color PageBackGroundColor { get; set; }
        public System.Drawing.Color MainTextColor { get; set; }

        public Command RegisterCommand { get; set; }

        public RegisterPageModel()
        {
            RegisterCommand = new Command(Register);
            PageBackGroundColor = Models.Constants.BackgroundColor;
            MainTextColor = Models.Constants.MainTextColor;
        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private bool isBusy = true;

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; }
        }

        private string confirmPassword;

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { confirmPassword = value; }
        }

        private void Register()
        {
            if(string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                CoreMethods.DisplayAlert("Oops!", "All fields must be filled", "Alright");
            }
            else if(Password != ConfirmPassword)
            {
                CoreMethods.DisplayAlert("Oops!", "Password must match", "Alright");
            }
            else
            {
                User user = new User(UserName, Password);
                App.UserDatabase.SaveUser(user);
                CoreMethods.DisplayAlert("Success!", "Your registration is successful....You can now login", "Alright");
            }
        }
    }
}
