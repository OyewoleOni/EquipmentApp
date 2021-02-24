using EquipmentApp.Data;
using EquipmentApp.Interfaces;
using EquipmentApp.PageModels;
using EquipmentApp.Services;
using FreshMvvm;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EquipmentApp
{
    public partial class App : Application
    {
        static TokenDatabaseController tokenDatabase;
        static UserDatabaseController userDatabase;
        public App()
        {
            InitializeComponent();
            FreshIOC.Container.Register<IRestServices, RestServices>();

            var mainPage = FreshPageModelResolver.ResolvePageModel<LoginPageModel>();
            var navigationContainer = new FreshNavigationContainer(mainPage);
            MainPage = navigationContainer;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static UserDatabaseController UserDatabase
        {
            get
            {
                if(userDatabase == null)
                {
                    userDatabase = new UserDatabaseController();
                }
                return userDatabase;
            }
        }

        public static TokenDatabaseController TokenDatabase
        {
            get
            {
                if (tokenDatabase == null)
                {
                    tokenDatabase = new TokenDatabaseController();
                }
                return tokenDatabase;
            }
        }
    }
}
