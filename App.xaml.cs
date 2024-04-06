using LeoBank.ViewModels;
using LeoBank.Views;
using SimpleInjector;
using System.Configuration;
using System.Data;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using LeoBank.Context;
using LeoBank.Models;
using LeoBank.Services.Classes;
using LeoBank.Services.Interfaces;

namespace LeoBank
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; set; }
        
        void Register()
        {
            Container = new Container();
            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<INavigationService, NavigationService>();
            Container.RegisterSingleton<IUserService, UserService>();
            Container.RegisterSingleton<IRegexService, RegexService>();
            Container.RegisterSingleton<IAdminService, AdminService>();
            Container.RegisterSingleton<ISuperAdminService, SuperAdminService>();
            Container.RegisterSingleton<ICardService, CardService>();
            Container.RegisterSingleton<CurrentUserService>();
            Container.RegisterSingleton<LeobankDbContext>();
            Container.RegisterSingleton<MainWindowViewModel>();
            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<LoginViewModel>();
            Container.RegisterSingleton<RegisterViewModel>();
            Container.RegisterSingleton<CardViewModel>();
            Container.RegisterSingleton<CrediteViewModel>();
            Container.RegisterSingleton<InvestityViewModel>();
            Container.RegisterSingleton<NDSViewModel>();
            Container.RegisterSingleton<OrderViewModel>();
            Container.RegisterSingleton<NameRedactViewModel>();
            Container.RegisterSingleton<ProfileSettingsViewModel>();
            Container.RegisterSingleton<PhoneRedactViewModel>();
            Container.RegisterSingleton<EmailRedactViewModel>();
            Container.RegisterSingleton<PayBalanceViewModel>();
            Container.RegisterSingleton<AmountBalanceViewModel>();
            Container.RegisterSingleton<SuccestfulPayViewModel>();

            Container.Register<AdminViewModel>();
            Container.Register<SuperAdminViewModel>();


            Container.Verify();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();
            var window = new MainWindow();
            window.DataContext = Container.GetInstance<MainWindowViewModel>();
            window.Show();
        }
    }

}
