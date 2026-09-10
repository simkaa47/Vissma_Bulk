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
            services.AddSingleton<IActivityLogService, ActivityLogService>();
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
