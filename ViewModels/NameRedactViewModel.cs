using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeoBank.Context;
using LeoBank.Models;
using LeoBank.Services.Classes;
using LeoBank.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Xaml.Behaviors.Media;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace LeoBank.ViewModels
{
    public class NameRedactViewModel : ViewModelBase
    {
        private readonly INavigationService _navigate;
        private readonly CurrentUserService _currentUserService;
        private readonly LeobankDbContext _context;
        private readonly User user;

        private string _name;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public NameRedactViewModel(INavigationService navigate, LeobankDbContext context, CurrentUserService currentUserService)
        {
            user = new User();
            _navigate = navigate;
            _currentUserService = currentUserService;
            _context = context;

            _currentUserService.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(CurrentUserService.Name))
                {
                    Name = _currentUserService.Name;
                }
            };
            _currentUserService.UpdateUserData(user);
        }

        public RelayCommand Save
        {
            get => new(
                () =>
                {
                    try
                    {
                        var user = _context.Users.FirstOrDefault(u => u.Name == _currentUserService.Name
                        && u.Phone == _currentUserService.Phone && u.Email == _currentUserService.Email);
                        if (Regex.IsMatch(Name, "^[A-Z][a-z]+$"))
                        {
                            if (user != null)
                            {
                                user.Name = Name;
                                _currentUserService.Name = Name;
                                _context.SaveChanges();
                                MessageBox.Show("Изменения сохранены");
                                _navigate.NavigateTo<ProfileSettingsViewModel>();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Недействительный имя");
                            return;
                        }
                        
                    }
                    catch (SqlException SQL)
                    {
                        MessageBox.Show($"SQL Ошибка {SQL.Message}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigate.NavigateTo<ProfileSettingsViewModel>();
                });
        }
    }
}
