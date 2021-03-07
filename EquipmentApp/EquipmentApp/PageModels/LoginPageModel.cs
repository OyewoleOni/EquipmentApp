using EquipmentApp.Models;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;

namespace EquipmentApp.PageModels
{
    public class LoginPageModel : FreshBasePageModel
    {

        public Color PageBackGroundColor { get; set; }
        public Color MainTextColor { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand UserNameCompletedCommand { get; set; }
        public ICommand PasswordFocusCommand { get; set; }


        public LoginPageModel()
        {
            LoginCommand = new Command(Login);
            RegisterCommand = new Command(Register);
            PasswordFocusCommand = new Command<Entry>(PasswordFocus);
            PageBackGroundColor = Models.Constants.BackgroundColor;
            MainTextColor = Models.Constants.MainTextColor;
        }

        private void Register()
        {
            CoreMethods.PushPageModel<RegisterPageModel>();
        }

        private void PasswordFocus(Entry obj)
        {
            obj.Focus();
        }

        private void UserNameCompleted(Entry obj)
        {
            obj.Focus();
        }

        private void Login()
        {
            IsBusy = true;
            User user = new User(UserName, Password);
            if (user.CheckUserInfo())
            {
                IsBusy = false;
                CoreMethods.PushPageModel<EquipmentPageModel>(user);
                
            }
            else
            {
                IsBusy = false;
                CoreMethods.DisplayAlert("Wrong User", "Your credentials are not correct. Please check them. Thanks", "Cancel");
            }
        }

        private string _userName = "oni1";

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _password = "oni1";

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                RaisePropertyChanged();
            }
        }


    }
}
