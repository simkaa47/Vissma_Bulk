using CommunityToolkit.Mvvm.ComponentModel;
using Core.Services.Activity;
using Core.Services.Events;
using System.Reflection;
namespace Core.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public AccessViewModel AccessViewModel { get; }
    public PlcViewModel PlcViewModel { get; }

    [ObservableProperty]
    public object? _eventsVm;

    [ObservableProperty]
    public object? _activityLogVm;

    #region Версия ПО
    public string SoftVersion { get; private set; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();
    #endregion

    private readonly IActivityLogService _logService;

    public MainViewModel(AccessViewModel accessViewModel,
        PlcViewModel plcViewModel, IActivityLogService logService)
    {
        AccessViewModel = accessViewModel;
        PlcViewModel = plcViewModel;
        _logService = logService;
        _logService.Log(LogLevel.Info, nameof(MainViewModel), "Приложение запущено.");

    }

}
