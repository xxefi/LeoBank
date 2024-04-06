using LeoBank.Models;
using LeoBank.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Xaml.Behaviors.Media;
using System.ComponentModel;

namespace LeoBank.Services.Classes;

public class CurrentUserService : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private int _userid;
    private string _name = string.Empty;
    private string _surname = string.Empty;
    private string _login = string.Empty;
    private string _email = string.Empty;
    private string _fin = string.Empty;
    private string _phone = string.Empty;
    private decimal _balance = 0;
    private byte[] _photoProfile = [];

    public int UserId
    {
        get => _userid;
        set
        {
            _userid = value;
            OnPropertyChanged(nameof(UserId));
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public string Surname
    {
        get => _surname;
        set
        {
            _surname = value;
            OnPropertyChanged(nameof(Surname));
        }
    }

    public string Login
    {
        get => _login;
        set
        {
            _login = value;
            OnPropertyChanged(nameof(Login));
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged(nameof(Email));
        }
    }

    public string FIN
    {
        get => _fin;
        set
        {
            _fin = value;
            OnPropertyChanged(nameof(FIN));
        }
    }

    public string Phone
    {
        get => _phone;
        set
        {
            _phone = value;
            OnPropertyChanged(nameof(Phone));
        }
    }

    public decimal Balance
    {
        get => _balance;
        set
        {
            _balance = value;
            OnPropertyChanged(nameof(Balance));
        }
    }

    public byte[] ProfilePhoto
    {
        get => _photoProfile;
        set
        {
            _photoProfile = value;
            OnPropertyChanged(nameof(ProfilePhoto));
        }
    }

    

    public void UpdateUserData(User user)
    {
        UserId = user.UserId;
        Name = user.Name;
        Surname = user.Surname;
        Login = user.Login;
        Email = user.Email;
        FIN = user.FIN;
        Phone = user.Phone;
        Balance = user.Balance;
        ProfilePhoto = user.PhotoProfile;
    }
}