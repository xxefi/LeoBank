using GalaSoft.MvvmLight;

namespace LeoBank.Services.Interfaces;

public interface INavigationService
{
    public void NavigateTo<T>() where T : ViewModelBase;
}