using CommunityToolkit.Mvvm.ComponentModel;

namespace Core.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public AccessViewModel AccessViewModel { get; }
    public PlcViewModel PlcViewModel { get; }

    [ObservableProperty]
    public object? _eventsVm;

    public MainViewModel(AccessViewModel accessViewModel,
        PlcViewModel plcViewModel)
    {
        AccessViewModel = accessViewModel;
        PlcViewModel = plcViewModel;

    }

}
