﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeoBank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoBank.ViewModels
{
    public class InvestityViewModel : ViewModelBase
    {
        private readonly INavigationService _navigate;

        public InvestityViewModel(INavigationService navigate)
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
    }
}
