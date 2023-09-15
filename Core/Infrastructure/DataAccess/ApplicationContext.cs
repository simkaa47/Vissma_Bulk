using Core.Infrastructure.DataAccess.Repositories;
using Core.Models;
using Core.Models.AccesControl;
using Core.Models.Events;
using Core.Models.Plc;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.DataAccess
{
    public class ApplicationContext : DbContext
    {       
        public DbSet<User> Users => Set<User>();        
        public DbSet<PlcConnectSettings> PlcConnectSettings => Set<PlcConnectSettings>();
        
        public DbSet<EventHistoryItem> EventHistoryItems => Set<EventHistoryItem>();         

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlite("Data Source=vissma.db");
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
    : base(options)
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public ApplicationContext()
        {

        }

        

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityCommon>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
