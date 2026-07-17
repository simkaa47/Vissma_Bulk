using CommunityToolkit.Mvvm.ComponentModel;
using Core.Services.Events;
using System.Reflection;
namespace Core.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public AccessViewModel AccessViewModel { get; }
    public PlcViewModel PlcViewModel { get; }

    [ObservableProperty]
    public object? _eventsVm;

    #region Версия ПО
    public string SoftVersion { get; private set; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();
    #endregion

    public MainViewModel(AccessViewModel accessViewModel,
        PlcViewModel plcViewModel)
    {
        AccessViewModel = accessViewModel;
        PlcViewModel = plcViewModel;

    }

}
