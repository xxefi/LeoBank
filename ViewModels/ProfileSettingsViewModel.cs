using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeoBank.Context;
using LeoBank.Models;
using LeoBank.Services.Classes;
using LeoBank.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LeoBank.ViewModels
{
    public class ProfileSettingsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigate;
        private readonly CurrentUserService _currentUserService;
        private readonly LeobankDbContext _context;

        private int _userId;
        private byte[] _photoProfile;
        private User _user;

        public int UserId
        {
            get => _userId;
            set => Set(ref _userId, value);
        }

        public byte[] PhotoProfile
        {
            get => _photoProfile;
            set => Set(ref _photoProfile, value);
        }

        public User User
        {
            get => _user;
            set => Set(ref _user, value);
        }

        public ProfileSettingsViewModel(INavigationService navigate, LeobankDbContext context, CurrentUserService currentUserService)
        {
            _navigate = navigate;
            _currentUserService = currentUserService;
            _context = context;

            _currentUserService.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName ==  nameof(CurrentUserService.UserId))
                {
                    UserId = _currentUserService.UserId;

                    User = _context.Users.FirstOrDefault(u => u.UserId == UserId);
                }
                else if (args.PropertyName == nameof(CurrentUserService.ProfilePhoto))
                {
                    PhotoProfile = _currentUserService.ProfilePhoto;

                    User = _context.Users.FirstOrDefault(u => u.UserId == UserId);
                }

            };
        }

        public RelayCommand Photo => new(async () =>
        {
            try
            {
                OpenFileDialog file = new();
                file.Title = "Выберите фото профиля";
                file.Filter = ("Фото (*.jpg;*.jpeg;*.png;*.gif) | *.jpg;*.jpeg;*.png;*.gif");
                if (file.ShowDialog() == true)
                {
                    PhotoProfile = await File.ReadAllBytesAsync(file.FileName);
                    User.PhotoProfile = PhotoProfile;
                    _currentUserService.ProfilePhoto = PhotoProfile;
                    _context.SaveChanges();
                    MessageBox.Show("Фото профиля установлено.");
                }
            }
            catch (SqlException SQL)
            {
                MessageBox.Show($"SQL Ошибка: {SQL.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        });
        

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigate.NavigateTo<OrderViewModel>();
                });
        }

        public RelayCommand Name
        {
            get => new(
                () =>
                {
                    _navigate.NavigateTo<NameRedactViewModel>();
                });
        }

        public RelayCommand Phone
        {
            get => new(
                () =>
                {
                    _navigate.NavigateTo<PhoneRedactViewModel>();
                });
        }

        public RelayCommand Email
        {
            get => new(
                () =>
                {
                    _navigate.NavigateTo<EmailRedactViewModel>();
                });
        }




        public RelayCommand Exit
        {
            get => new(
                () =>
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти?", "Уведомление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        _navigate.NavigateTo<LoginViewModel>();
                    }
                });
        }
    }
}
