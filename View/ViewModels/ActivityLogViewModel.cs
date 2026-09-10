using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Avalonia.Threading;
using Core.ViewModels;
using Core.Services.Activity;

namespace View.ViewModels
{
    public partial class ActivityLogViewModel : ViewModelBase
    {
        private readonly IActivityLogService _logService;

        [ObservableProperty]
        private ObservableCollection<ActivityLogEntry> _logs = new();

        public ActivityLogViewModel(IActivityLogService logService)
        {
            _logService = logService;
            var history = _logService.GetHistory();
            foreach (var entry in history)
            {
                Logs.Add(entry);
            }
            _logService.EntryAdded += OnLogEntryAdded;
        }

        private void OnLogEntryAdded(object? sender, ActivityLogEntry entry)
        {

            Dispatcher.UIThread.InvokeAsync(() =>
            {
                Logs.Add(entry);

                // Ограничиваем количество элементов в UI для производительности
                if (Logs.Count > 500)
                {
                    Logs.RemoveAt(0);
                }
            });
        }
    }
}
