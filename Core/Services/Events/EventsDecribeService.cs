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

    #region  Инициализация
    private  void Init()
    {
        Events = PlcMainService.PlcModel.Errors.Errors
            .Select((e, i) => new EventPoint(e, "Value", true)
            {
                Message = e.Description,
                Advice = e.Advice,
                EventCode = i.ToString("d4"),
                IsActive = e.Value,
                LastDateTime = DateTime.Now

            }).ToList();        
        AddPlcConnectionErr();
        AddWarnings();
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
            Advice = "Переподключите ПЛК",
            EventCode = "0300"
        });
    }  


    private void AddWarnings()
    {
        if (Events is null) Events = new List<EventPoint>();

        Events.AddRange(PlcMainService.PlcModel.Errors.Warnings
            .Select((e, i) => new EventPoint(e, "Value", true)
            {
                Message = "ПРЕДУПРЕЖДЕНИЕ: " + e.Description,
                Advice = e.Advice,
                EventCode = (70+i).ToString("d4"),
                IsActive = e.Value,
                LastDateTime = DateTime.Now,
                Type = EventType.Event

            }));
    }

    
    #endregion

    #region Действие по изменению активности в списке событий
    private  void OnEventChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (sender is null) return;
        if (!(sender is EventPoint eventPoint)) return;
        if(e.PropertyName == nameof(eventPoint.IsActive))
        {
            eventPoint.LastDateTime = DateTime.Now;
            UpdateErrorsEvent?.Invoke();
        }
             

    }
    #endregion
}
