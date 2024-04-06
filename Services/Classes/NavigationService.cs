using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using LeoBank.Messages;
using LeoBank.Services.Interfaces;

namespace LeoBank.Services.Classes;

public class NavigationService : INavigationService
{
    private readonly IMessenger _messenger;

    public NavigationService(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void NavigateTo<T>() where T : ViewModelBase
    {
        _messenger.Send(new NavigationMessage()
        {
            ViewModelBase = App.Container.GetInstance<T>()
        });
    }
}