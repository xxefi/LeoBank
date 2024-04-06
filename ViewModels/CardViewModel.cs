using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeoBank.Context;
using LeoBank.Models;
using LeoBank.Services.Classes;
using LeoBank.Services.Interfaces;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoBank.ViewModels
{
    public class CardViewModel : ViewModelBase
    {
        private readonly INavigationService _navigate;
        private readonly LeobankDbContext _context;
        private readonly CurrentUserService _currentUserService;
        private int _userId;
        private Card _userCard;


        public int UserId
        {
            get => _userId;
            set => Set(ref _userId, value); 
        }
        public Card UserCard
        {
            get => _userCard;
            set => Set(ref _userCard, value);
        }
        public CardViewModel(INavigationService navigate, LeobankDbContext context, CurrentUserService currentUserService)
        {
            _navigate = navigate;
            _context = context;
            _currentUserService = currentUserService;

            _currentUserService.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(CurrentUserService.UserId))
                {
                    UserId = _currentUserService.UserId;

                    UserCard = _context.Cards.FirstOrDefault(c => c.UserId == UserId);

                }
            };
        }
        public string ExpiryDateFormatted  => UserCard?.ExpiryDate.ToString("MM/yy", CultureInfo.InvariantCulture);
        

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
