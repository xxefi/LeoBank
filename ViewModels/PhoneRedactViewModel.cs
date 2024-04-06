using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeoBank.Context;
using LeoBank.Models;
using LeoBank.Services.Classes;
using LeoBank.Services.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace LeoBank.ViewModels
{
    public class PhoneRedactViewModel : ViewModelBase
    {
        private readonly INavigationService _navigate;
        private readonly CurrentUserService _currentUserService;
        private readonly LeobankDbContext _context;
        private readonly User user;

        private string _phone;

        public string Phone
        {
            get => _phone;
            set => Set(ref _phone, value);
        }

        public PhoneRedactViewModel(INavigationService navigate, CurrentUserService currentUserService, LeobankDbContext context)
        {
            user = new User();
            _navigate = navigate;
            _currentUserService = currentUserService;
            _context = context;

            _currentUserService.PropertyChanged += (sender, args) =>
            {
                Phone = _currentUserService.Phone;
            };
            _currentUserService.UpdateUserData(user);
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigate.NavigateTo<ProfileSettingsViewModel>();
                });
        }

        public RelayCommand Save
        {
            get => new(
                () =>
                {
                    try
                    {
                        var user = _context.Users.FirstOrDefault(u => u.Name == _currentUserService.Name
                        && u.Email == _currentUserService.Email && u.Phone == _currentUserService.Phone);
                        if (Regex.IsMatch(Phone, @"^\+\d{3}\d{9}$"))
                        {
                            if (user != null)
                            {
                                user.Phone = Phone;
                                _currentUserService.Phone = Phone;
                                _context.SaveChanges();
                                MessageBox.Show("Изменения сохранены");
                                _navigate.NavigateTo<ProfileSettingsViewModel>();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Недействительный номер");
                            return;
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
        }
    }
}
