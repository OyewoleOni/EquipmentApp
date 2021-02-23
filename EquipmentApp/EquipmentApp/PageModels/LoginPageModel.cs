﻿using EquipmentApp.Models;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace EquipmentApp.PageModels
{
    public class LoginPageModel : FreshBasePageModel
    {

        public Color PageBackGroundColor { get; set; }
        public Color MainTextColor { get; set; }
        public Command LoginCommand { get; set; }
        public Command UserNameCompletedCommand { get; set; }
        public Command PasswordFocusCommand { get; set; }
        public bool IsRunning { get; set; }

        public LoginPageModel()
        {
            LoginCommand = new Command(Login);
            //UserNameCompletedCommand = new Command<Entry>(UserNameCompleted);
            PasswordFocusCommand = new Command<Entry>(PasswordFocus);
            PageBackGroundColor = Models.Constants.BackgroundColor;
            MainTextColor = Models.Constants.MainTextColor;
            IsRunning = false;
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
            IsRunning = true;
            Thread.Sleep(2000);
            User user = new User(UserName, Password);
            if (user.CheckUserInfo())
            {
                CoreMethods.PushPageModel<EquipmentPageModel>();
                IsRunning = false;
            }
            else
            {
                IsRunning = false;
                CoreMethods.DisplayAlert("Wrong User", "Your credentials are not correct. Please check them. Thanks", "Cancel");
            }
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


    }
}
