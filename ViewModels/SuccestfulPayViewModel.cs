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
    public class SuccestfulPayViewModel : ViewModelBase
    {
        private readonly INavigationService _navigate;

        public SuccestfulPayViewModel(INavigationService navigate)
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
    }
}
