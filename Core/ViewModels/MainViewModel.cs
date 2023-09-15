namespace Core.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public AccessViewModel AccessViewModel { get; }
    public PlcViewModel PlcViewModel { get; }

    public MainViewModel(AccessViewModel accessViewModel,
        PlcViewModel plcViewModel)
    {
        AccessViewModel = accessViewModel;
        PlcViewModel = plcViewModel;

    }

}
