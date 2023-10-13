using CommunityToolkit.Mvvm.ComponentModel;
using Core.Models.Events;
using Core.Services.Plc;
using Core.ViewModels;
using System.ComponentModel;

namespace Core.Services.Events;

public partial class EventsDecribeService : ObservableObject
{
    public EventsDecribeService(PlcMainService plcMainService)
    {

        PlcMainService = plcMainService;        
        Init();
    }

    [ObservableProperty]
    private List<EventPoint>? _events = new List<EventPoint>();   
    public PlcMainService PlcMainService { get; }
    

    public event Action UpdateErrorsEvent =  delegate { };
    public event Action<EventHistoryItem> AddHistoryEvent = delegate { };

    #region  Инициализация
    private  void Init()
    {
        Events = PlcMainService.PlcModel.Errors.Errors
            .Select((e, i) => new EventPoint(e, "Value", true)
            {
                Message = e.Description,
                EventCode = i.ToString("d4"),
                IsActive = e.Value
            }).ToList();        
        AddPlcConnectionErr();
        foreach (var e in Events)
        {
            e.PropertyChanged += OnEventChanged;
        }       

    }
    

    private void AddPlcConnectionErr()
    {
        if (Events is null) Events = new List<EventPoint>();
        Events.Add(new EventPoint(PlcMainService.PlcStateInfo, nameof(PlcMainService.PlcStateInfo.Connected), false)
        {
            Message = "Нет связи с ПЛК",
            EventCode = "0300"
        });
    }  

    
    #endregion

    #region Действие по изменению активности в списке событий
    private async void OnEventChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (sender is null) return;
        if (!(sender is EventPoint eventPoint)) return;
        UpdateErrorsEvent?.Invoke();
        if (e.PropertyName == nameof(eventPoint.IsActive))
        {
            var newItem = new EventHistoryItem
            {
                IsActive = eventPoint.IsActive,
                Date = DateTime.Now,
                EventCode = eventPoint.EventCode,
                Message = eventPoint.Message,
                AccessLevel = Models.AccesControl.UserAccessLevel.None

            };  

        }

    }
    #endregion
}
