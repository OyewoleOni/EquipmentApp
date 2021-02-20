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
        public App()
        {
            InitializeComponent();
            FreshIOC.Container.Register<IRestServices, RestServices>();

            var mainPage = FreshPageModelResolver.ResolvePageModel<EquipmentPageModel>();
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
    }
}
