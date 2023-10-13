using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Models.AccesControl;
using Core.Models.Events;
using Core.Services.Events;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace View.ViewModels
{
    public partial class EventViewModel : ObservableObject
    {
        public EventViewModel(EventsDecribeService decribeService)
        {
            DecribeService = decribeService;            
            Init();
        }
        [ObservableProperty]
        private IEnumerable<EventPoint>? _activePoints;

        public EventsDecribeService DecribeService { get; } 

        public async void Init()
        {
            ActivePoints = DecribeService.Events?.Where(e => e.IsActive).OrderByDescending(e => e.LastDateTime);
            DecribeService.UpdateErrorsEvent += () =>
            {
                ActivePoints = DecribeService.Events?.Where(e => e.IsActive).OrderByDescending(e => e.LastDateTime);
            };

        }
    }
        
}
