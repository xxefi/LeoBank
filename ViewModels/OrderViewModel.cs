using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using LeoBank.Context;
using LeoBank.Models;
using LeoBank.Services.Classes;
using LeoBank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LeoBank.ViewModels
{
    public class OrderViewModel : ViewModelBase
    {
        private readonly INavigationService _navigate;
        private readonly CurrentUserService _currentUserService;
        private readonly LeobankDbContext _context;

        private int _userId;
        private User _user;

        public int UserId
        {
            get => _userId;
            set => Set(ref _userId, value);
        }

        public User User
        {
            get => _user;
            set => Set(ref _user, value);
        }

        public OrderViewModel(INavigationService navigate, LeobankDbContext context, CurrentUserService currentUserService)
        {
            _navigate = navigate;
            _context = context;
            _currentUserService = currentUserService;

            _currentUserService.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(CurrentUserService.UserId))
                {
                    UserId = _currentUserService.UserId;

                    User = _context.Users.FirstOrDefault(u => u.UserId == UserId);
                }
            };
        }

        public RelayCommand Instagram
        {
            get => new(
                () =>
                {
                    try
                    {
                        ProcessStartInfo psi = new ProcessStartInfo
                        {
                            FileName = "cmd",
                            Arguments = "$/c start https://instagram.com/leobank.az"
                        };
                        Process.Start(psi);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
        }

        public RelayCommand DashBoard
        {
            get => new(
                () =>
                {
                    _navigate.NavigateTo<MainViewModel>();
                });
        }

        public RelayCommand Credite
        {
            get => new(
                () =>
                {
                    _navigate.NavigateTo<CrediteViewModel>();
                });
        }
        public RelayCommand Investity
        {
            get => new(
                () =>
                {
                    _navigate.NavigateTo<InvestityViewModel>();
                });
        }

        public RelayCommand EDV
        {
            get => new(
                () =>
                {
                    _navigate.NavigateTo<NDSViewModel>();
                });
        }

        public RelayCommand ProfileSettings
        {
            get => new(
                () =>
                {
                    _navigate.NavigateTo<ProfileSettingsViewModel>();
                });
        }

        public RelayCommand Exit
        {
            get => new(
                () =>
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти из аккаунта?", "Уведомление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        _navigate.NavigateTo<LoginViewModel>();
                    }
                });
        }
    }
}
