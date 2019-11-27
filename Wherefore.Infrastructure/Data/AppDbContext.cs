using Wherefore.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Wherefore.Core.Entities;
using Wherefore.Core.SharedKernel;
using System.Reflection;

namespace Wherefore.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        //public AppDbContext(DbContextOptions options) : base(options)
        //{
        //}

        public AppDbContext(DbContextOptions<AppDbContext> options, IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
        }

        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            int result = base.SaveChanges();

            // ignore events if no dispatcher provided
            if (_dispatcher == null) return result;

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events)
                {
                    _dispatcher.Dispatch(domainEvent);
                }
            }

            return result;
        }
    }
}