using CommunityToolkit.Mvvm.ComponentModel;
using Core.Infrastructure.DataAccess.Repositories;
using Core.Models.AccesControl;
using Core.Models.Events;
using Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;

namespace Core.Services.Events
{
    public partial class EventMainService : ObservableObject
    {
        public EventMainService(
            IRepository<EventHistoryItem> eventHistoryRepository,
            IServiceProvider serviceProvider)
        {
            _eventHistoryRepository = eventHistoryRepository;
            ServiceProvider = serviceProvider;
        }

        public IServiceProvider ServiceProvider { get; }

        public static event Action<EventHistoryItem> UpdateHistoryEvent;



        #region События

        private readonly IRepository<EventHistoryItem> _eventHistoryRepository;
        #endregion

        #region Добавить в историю запись
        public async Task AddHistoryItem(EventHistoryItem eventHistoryItem)
        {
            try
            {
                using IServiceScope scope = ServiceProvider.CreateScope();
                var eventRepo = scope.ServiceProvider.GetService<IRepository<EventHistoryItem>>();
                var userRepo = scope.ServiceProvider.GetService<IRepository<User>>();
                if (eventRepo is null || userRepo is null) return;
                var dbUser = AccessViewModel.UserId > 0 ? await userRepo.GetByIdAsync(AccessViewModel.UserId) : null;
                eventHistoryItem.User = dbUser;
                await eventRepo.AddAsync(eventHistoryItem);
                UpdateHistoryEvent?.Invoke(eventHistoryItem);
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region Получить историю за определенный промежуток времени
        public async Task<IEnumerable<EventHistoryItem>> GetHistory(DateTime start, DateTime end)
        {
            try
            {
                var history = await _eventHistoryRepository.GetWhere(h => h.Date >= start && h.Date <= end);
                return new BlockingCollection<EventHistoryItem>(new ConcurrentQueue<EventHistoryItem>(history));
            }
            catch (Exception)
            {
                return new BlockingCollection<EventHistoryItem>();
            }
        }
        #endregion



    }
}
