using System.ComponentModel;
using System.Configuration;
using System.Text.Json.Serialization;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeoBank.Context;
using LeoBank.Services.Classes;
using LeoBank.Services.Interfaces;
using Microsoft.Data.SqlClient;

namespace LeoBank.ViewModels;

public class LoginViewModel : ViewModelBase, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    private readonly INavigationService _navigate;
    private readonly IAdminService _adminService;
    private readonly ISuperAdminService _superAdminService;
    private readonly IUserService _userService;
    private readonly CurrentUserService _currentUserService;
    private readonly LeobankDbContext _context;

    private string _email;
    private string _password;
    private bool _loginEnabled;

    public bool LoginEnabled
    {
        get => _loginEnabled;
        set
        {
            if (_loginEnabled != value)
            {
                Set(ref _loginEnabled, value);
                OnPropertyChanged(nameof(LoginEnabled));
            }
        }
    }

    public string Email
    {
        get => _email;
        set => Set(ref _email, value);
    }

    public string Password
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                Set(ref _password, value);
                OnPropertyChanged(nameof(Password));
                LoginEnabled = !string.IsNullOrWhiteSpace(Password) && Password.Length > 4;
            }
        }
    }

    public LoginViewModel(INavigationService navigate, IUserService userService, IAdminService adminService, ISuperAdminService superAdminService, CurrentUserService currentUserService, LeobankDbContext context)
    {
        _navigate = navigate;
        _userService = userService;
        _adminService = adminService;
        _superAdminService = superAdminService;
        _currentUserService = currentUserService;
        _context = context;
    }

    public RelayCommand Login
    {
        get => new(() =>
        {
            try
            {
                if (_adminService.AdminLogin(Email, Password))
                {
                    _navigate.NavigateTo<AdminViewModel>();
                }
                else if (_superAdminService.SuperAdminLogin(Email, Password))
                {
                    _navigate.NavigateTo<SuperAdminViewModel>();
                }
                else if (_userService.UserLogin(Email, Password))
                {
                    var user = _userService.GetUser(Email);
                    _currentUserService.UpdateUserData(user);
                    _navigate.NavigateTo<MainViewModel>();
                }
                else
                {
                    MessageBox.Show("Неправильный e-mail или пароль");
                    return;
                }
                Email = "";
                Password = "";
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
    
    public RelayCommand Register
    {
        get => new(
            () =>
            {
                _navigate.NavigateTo<RegisterViewModel>();
            });
    }
}