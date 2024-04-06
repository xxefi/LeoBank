using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeoBank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LeoBank.ViewModels
{
    public class PayBalanceViewModel : ViewModelBase
    {
        private readonly INavigationService _navigate;

        private string _card;
        private string _date;
        private string _cvv;

        public string Card
        {
            get => _card;
            set => Set(ref _card, value);
        }

        public string Date
        {
            get => _date;
            set => Set(ref _date, value);
        }

        public string CVV
        {
            get => _cvv;
            set => Set(ref _cvv, value);
        }

        public PayBalanceViewModel(INavigationService navigate)
        {
            _navigate = navigate;
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigate.NavigateTo<MainViewModel>();
                });
        }

        public RelayCommand Pay
        {
            get => new(
                () =>
                {
                    if (string.IsNullOrWhiteSpace(Card) || string.IsNullOrWhiteSpace(Date) || string.IsNullOrWhiteSpace(CVV))
                    {
                        MessageBox.Show("Поля не могут быть пустыми");
                        return;
                    }
                    _navigate.NavigateTo<AmountBalanceViewModel>();
                });
        }
    }
}
