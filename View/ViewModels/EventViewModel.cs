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
        public EventViewModel(EventsDecribeService decribeService, AccessViewModel accessViewModel)
        {
            DecribeService = decribeService;
            AccessViewModel = accessViewModel;
            Init();
        }
        [ObservableProperty]
        private IEnumerable<EventPoint>? _activePoints;

        public EventsDecribeService DecribeService { get; }
        public AccessViewModel AccessViewModel { get; }


        #region СТартовая точка фильтра
        private DateTimeOffset _startDate = new DateTimeOffset(DateTime.Today);
        public DateTimeOffset StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }


        private TimeSpan _startTime = new TimeSpan();
        public TimeSpan StartTime
        {
            get => _startTime;
            set => SetProperty(ref _startTime, value);
        }
        #endregion

        #region Конечная точка фильтра
        private DateTimeOffset _endDate = new DateTimeOffset(DateTime.Today.AddDays(1));
        public DateTimeOffset EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        private TimeSpan _endTime = new TimeSpan();
        public TimeSpan EndTime
        {
            get => _endTime;
            set => SetProperty(ref _endTime, value);
        }
        #endregion

        #region Индикатор загрузки данных истории проб
        [ObservableProperty]
        private bool _downloadHisytoryProbsIndicator;
        #endregion



        public async void Init()
        {
            await GetHistory();
            DecribeService.UpdateErrorsEvent += () =>
            {
                ActivePoints = DecribeService.Events?.Where(e => e.IsActive).OrderByDescending(e => e.LastDateTime);
            };
            AccessViewModel.PropertyChanged += async (s, e) =>
            {
                if (e.PropertyName is nameof(AccessViewModel.CurrentUser))
                {
                    await GetHistory();
                }
            };
            DecribeService.AddHistoryEvent += AddHistoryItem;

        }

        [ObservableProperty]
        private ObservableCollection<EventHistoryItem> _eventHistoryItems = new ObservableCollection<EventHistoryItem>();


        private UserAccessLevel GetCurrentUserLevel()
        {
            if (AccessViewModel is null || AccessViewModel.CurrentUser is null)
                return UserAccessLevel.None;
            else return AccessViewModel.CurrentUser.AccessLevel;
        }

        [RelayCommand]
        private async Task GetHistory()
        {
            var start = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, StartTime.Hours, StartTime.Minutes, StartTime.Seconds);
            var end = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, EndTime.Hours, EndTime.Minutes, EndTime.Seconds);
            var items = (await DecribeService.GetHistory(start, end))
                .Where(h => h.AccessLevel <= GetCurrentUserLevel())
                .OrderByDescending(h => h.Date);
            EventHistoryItems = new ObservableCollection<EventHistoryItem>(items);
        }

        private async void AddHistoryItem(EventHistoryItem eventHistoryItem)
        {
            try
            {
                if (eventHistoryItem.AccessLevel > GetCurrentUserLevel()) return;
                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    if (EventHistoryItems is null) return;
                    EventHistoryItems.Insert(0, eventHistoryItem);

                });
            }
            catch (Exception)
            {
            }
        }
    }
}
