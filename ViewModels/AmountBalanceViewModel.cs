using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeoBank.Context;
using LeoBank.Enums;
using LeoBank.Models;
using LeoBank.Services.Classes;
using LeoBank.Services.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LeoBank.ViewModels
{
    public class AmountBalanceViewModel : ViewModelBase
    {
        private readonly INavigationService _navigate;
        private readonly CurrentUserService _currentUserService;
        private readonly LeobankDbContext _context;

        private decimal _amount;

        public decimal Amount
        {
            get => _amount;
            set => Set(ref _amount, value);
        }

        public AmountBalanceViewModel(INavigationService navigate, LeobankDbContext context, CurrentUserService currentUserService)
        {
            _navigate = navigate;
            _currentUserService = currentUserService;
            _context = context;
        }

        public RelayCommand Pay
        {
            get => new(
                () =>
                {
                    try
                    {
                        var user = _context.Users.FirstOrDefault(u => u.UserId == _currentUserService.UserId);
                        if (user != null)
                        {
                            if (Amount == 0)
                            {
                                MessageBox.Show("Введите сумму");
                                return;
                            }
                            user.Balance += Amount;
                            _context.SaveChanges();
                            Transaction transaction = new()
                            {
                                UserId = _currentUserService.UserId,
                                Name = "Пополнение карты",
                                Category = $"{Categories.Зачисление}",
                                Amount = Amount,
                                Status = $"{Status.Успешно}"
                            };
                            _context.Transactions.Add(transaction);
                            _context.SaveChanges();
                            
                            _navigate.NavigateTo<SuccestfulPayViewModel>();
                            _currentUserService.Balance = user.Balance;
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
                    Amount = 0;
                });
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigate.NavigateTo<PayBalanceViewModel>();
                });
        }
    }
}
