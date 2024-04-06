using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeoBank.Context;
using LeoBank.Models;
using LeoBank.Services.Classes;
using LeoBank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LeoBank.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigate;
        private readonly LeobankDbContext _context;
        private readonly CurrentUserService _currentUserService;
        private ObservableCollection<Transaction> _transactions;
        private Transaction _selectedTransactions;
        private readonly User _user = new();
        private decimal _balance;

        public decimal Balance
        {
            get => _balance;
            set => Set(ref _balance, value);
        }

        public ObservableCollection<Transaction> Transactions
        {
            get => _transactions;
            set => Set(ref _transactions, value);
        }

        public Transaction SelectedTransactions
        {
            get => _selectedTransactions;
            set => Set(ref _selectedTransactions, value);
        }

        public MainViewModel(INavigationService navigate, LeobankDbContext context, CurrentUserService currentUserService)
        {
            _navigate = navigate;
            _context = context;
            _currentUserService = currentUserService;

            _currentUserService.PropertyChanged += (sender, args) =>
            {
                Balance = _currentUserService.Balance;
            };
            _currentUserService.UpdateUserData(_user);
            Transactions = new ObservableCollection<Transaction>(_context.Transactions);
        }

        public RelayCommand Card
        {
            get => new(
                () =>
                {
                    _navigate.NavigateTo<CardViewModel>();
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

        public RelayCommand Order
        {
            get => new(
                () =>
                {
                    _navigate.NavigateTo<OrderViewModel>();
                });
        }

        public RelayCommand Pay
        {
            get => new(
                () =>
                {
                    _navigate.NavigateTo<PayBalanceViewModel>();
                });
        }
    }
}
