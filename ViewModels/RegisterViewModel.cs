using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeoBank.Services.Interfaces;
using System.ComponentModel;    
using System.Text.RegularExpressions;
using System.Windows;
using LeoBank.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using LeoBank.Models;
using System.IO;
using LeoBank.Services.Classes;
using Microsoft.Identity.Client;

namespace LeoBank.ViewModels
{
    public class RegisterViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private readonly INavigationService _navigate;
        private readonly IUserService _userService;
        private readonly ICardService _cardService;
        private readonly CurrentUserService _currentUserService;
        private readonly LeobankDbContext _context;
        private readonly User _user = new();

        private bool _registerEnabled;
        private bool _profileEnabled;
        private string _name;
        private string _surname;
        private string _login;
        private string _email;
        private string _fin;
        private string _phone;
        private string _password;
        private string _tryPassword;


        public bool RegisterEnabled
        {
            get => _registerEnabled;
            set
            {
                if (_registerEnabled != value)
                {
                    Set(ref _registerEnabled, value);
                    OnPropertyChanged(nameof(RegisterEnabled));
                }
            }
        }

        public bool ProfileEnabled
        {
            get => _profileEnabled;
            set
            {
                if (_profileEnabled != value)
                {
                    Set(ref _profileEnabled, value);
                    OnPropertyChanged(nameof(ProfileEnabled));
                }
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (Regex.IsMatch(value, "^[A-Z][a-z]+$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _name, value);
                }
                else
                {
                    MessageBox.Show("Недействительный имя");
                    return;
                }
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                if (Regex.IsMatch(value, "^[A-Z][a-z]+$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _surname, value);
                }
                else
                {
                    MessageBox.Show("Недействительная фамилия");
                    return;
                }
            }
        }

        public string Login
        {
            get => _login;
            set
            {
                if (Regex.IsMatch(value, "^[a-zA-Z0-9_-]{3,16}$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _login, value);
                }
                else
                {
                    MessageBox.Show("Недействительный логин");
                    return;
                }
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (Regex.IsMatch(value, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _email, value);
                }
                else
                {
                    MessageBox.Show("Недействительная электронная почта");
                    return;
                }
            }
        }

        public string FIN
        {
            get => _fin;
            set
            {
                if (Regex.IsMatch(value, @"^\d{2}[A-Za-z]{2}\d{2}[A-Za-z]{1}$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _fin, value);
                }
                else
                {
                    MessageBox.Show("Недействительный FIN");
                    return;
                }
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                if (Regex.IsMatch(value, @"^\+\d{3}\d{9}$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _phone, value);
                }
                else
                {
                    MessageBox.Show("Недействительный номер телефона");
                    return;
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (Regex.IsMatch(value, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()-_+=])[A-Za-z\d!@#$%^&*()-_+=]{8,}$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _password, value);
                }
                else
                {
                    MessageBox.Show("Пароль должен содержать как минимум 8 символов," +
                                    " включая хотя бы одну заглавную букву, одну строчную букву, одну цифру, и один специальный символ");
                    return;
                }
            }
        }

        public string TryPassword
        {
            get => _tryPassword;
            set
            {
                if (_tryPassword != value)
                {
                    Set(ref _tryPassword, value);
                    OnPropertyChanged(nameof(TryPassword));
                    ProfileEnabled = !string.IsNullOrWhiteSpace(TryPassword) && TryPassword.Length > 7;
                }
            }
        }
        

        public RegisterViewModel(INavigationService navigate, IUserService userService, ICardService cardService, CurrentUserService currentUserService, LeobankDbContext context)
        {
            _navigate = navigate;
            _userService = userService;
            _cardService = cardService;
            _currentUserService = currentUserService;
            _context = context;
        }

        public RelayCommand PP
        {
            get => new(
                () =>
                {
                    OpenFileDialog file = new();
                    file.Filter = "Фото (*.jpg;*.jpeg*.png*.gif) | *.jpg;*.jpeg;*.png;*.gif";
                    if (file.ShowDialog() == true)
                    {
                        _user.PhotoProfile = File.ReadAllBytes(file.FileName);
                        MessageBox.Show("Фото профиля установлено.");
                        RegisterEnabled = true;
                    }
                });
        }


        public RelayCommand Register
        {
            get => new(() =>
            {
                try
                {
                    using (LeobankDbContext context = new())
                    {
                        if (_context.Users.Any(u => u.Login == Login || u.Email == Email
                                               || u.FIN == FIN || u.Phone == Phone))
                        {
                            MessageBox.Show("Вы уже зарегистрированы");
                            _navigate.NavigateTo<LoginViewModel>();
                        }
                        else if (TryPassword != Password)
                        {
                            MessageBox.Show("Вы неправильно ввели повторный код");
                            return;
                        }
                        else
                        {
                            var user = _userService.UserRegister(Name, Surname, Login, Email, FIN, Phone, Password, _user.PhotoProfile);
                            _context.Users.Add(user);
                            _context.SaveChanges();

                            var get = _userService.GetUser(Email);
                            _currentUserService.UpdateUserData(get);

                            var card = _cardService.GenerateCard(_currentUserService.UserId);
                            _context.Cards.Add(card);
                            _context.SaveChanges();
                            MessageBox.Show("Успешная регистрация");
                            Name = "";
                            Surname = "";
                            Login = "";
                            Email = "";
                            FIN = "";
                            Phone = "";
                            Password = "";
                            TryPassword = "";
                            _navigate.NavigateTo<LoginViewModel>();
                        }
                        
                    }
                }
                catch (SqlException SQL)
                {
                    MessageBox.Show($"SQL Ошибка: {SQL.Message}");
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            });
        }
        public RelayCommand Main
        {
            get => new(
                () =>
                {
                    _navigate.NavigateTo<LoginViewModel>();
                });
        }
        
        
    }
}
