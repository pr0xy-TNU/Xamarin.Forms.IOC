using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FreshMvvm;
using AppDIv2.repo;
using FluentValidation;
using AppDIv2.validation;
using Acr.UserDialogs;
using AppDIv2.PageModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppDIv2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitDI();
            var startPage = FreshPageModelResolver.ResolvePageModel<AddUserPageModel>();
            MainPage = new FreshNavigationContainer(startPage);

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        protected void InitDI()
        {
            FreshIOC.Container.Register<IUserRepository, UserRepository>();
            FreshIOC.Container.Register<IValidator, UserValidator>();
            FreshIOC.Container.Register<IUserDialogs>(UserDialogs.Instance);
            FreshIOC.Container.Register(this);

        }
    }
}
