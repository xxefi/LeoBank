using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeoBank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoBank.ViewModels
{
    public class NDSViewModel : ViewModelBase
    {
        private readonly INavigationService _navigate;
        public NDSViewModel(INavigationService navigate)
        {
            _navigate = navigate;
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
        public RelayCommand Order
        {
            get => new(
                () =>
                {
                    _navigate.NavigateTo<OrderViewModel>();
                });
        }
    }
}
