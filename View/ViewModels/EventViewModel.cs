using CommunityToolkit.Mvvm.ComponentModel;
using Core.Models.Events;
using Core.Services.Events;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void Init()
        {
          
            ActivePoints = DecribeService.Events?.Where(e => e.IsActive).OrderByDescending(e => e.LastDateTime);
            DecribeService.UpdateErrorsEvent += () =>
            {
                ActivePoints = DecribeService.Events?.Where(e => e.IsActive).OrderByDescending(e => e.LastDateTime).ToList();
            };

        }
    }

}
