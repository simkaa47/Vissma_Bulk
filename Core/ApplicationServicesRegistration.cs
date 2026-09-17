using Core.Contracts.Access;
using Core.Infrastructure.DataAccess;
using Core.Infrastructure.DataAccess.Repositories;
using Core.Services.Access;
using Core.Services.Events;
using Core.Services.Mapping;
using Core.Services.Plc;
using Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Core.Services.Activity;

namespace Core
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            if (services is null) services = new ServiceCollection();
            services.AddMapper();
            services.AddDbContext<ApplicationContext>(options => { });
            var appDataPath = Environment.CurrentDirectory;
            var logDirectory = Path.Combine(appDataPath, "Activity log data");
            var logFilePath = Path.Combine(logDirectory, $"activity_log_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.json");
            services.AddSingleton<IActivityLogService, ActivityLogService>(sp => new ActivityLogService(logFilePath));
            services.AddSingleton<MainViewModel>();            
            services.AddSingleton<AccessViewModel>();
            services.AddSingleton<IUserAccessService, UserAccessService>();
            services.AddSingleton<PlcMainService>();
            
            services.AddSingleton<PlcViewModel>(); 
            services.AddSingleton<EventsDecribeService>();            
            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));


            return services;
        }
    }
}
