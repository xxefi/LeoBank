using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using LeoBank.Messages;

namespace LeoBank.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        private ViewModelBase _currentView;

        public ViewModelBase CurrentView
        {
            get => _currentView;
            set => Set(ref _currentView, value);
        }

        public MainWindowViewModel(IMessenger messenger)
        {
            CurrentView = App.Container.GetInstance<LoginViewModel>();
            _messenger = messenger;
            
            _messenger.Register<NavigationMessage>(this, message =>
            {
                CurrentView = message.ViewModelBase;
            });
        }
    }
}
