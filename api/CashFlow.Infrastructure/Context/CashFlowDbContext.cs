using Microsoft.EntityFrameworkCore;
using CashFlow.Domain.Entity;
using MassTransit;
using Shared.Domain.Core;

namespace CashFlow.Infrastructure.Context
{
    public class CashFlowDbContext : DbContext
    {
        private readonly IBusControl _busControl;

        public CashFlowDbContext(DbContextOptions<CashFlowDbContext> options, IBusControl busControl) : base(options)
        {
            _busControl = busControl;
        }

        public CashFlowDbContext(DbContextOptions<CashFlowDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CashFlowEntity>()
                .ToTable("CashFlow");

            modelBuilder.Entity<CashFlowEntity>().OwnsOne(x => x.DiscountRates, y =>
            {
                y.Property(p => p.LowerBound);
                y.Property(p => p.UpperBound);
            });
        }

        public virtual DbSet<CashFlowEntity> CashFlows { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var domainEvents = ChangeTracker.Entries<AggregateRoot>()
                .SelectMany(x => x.Entity.DomainEvents);

            foreach (var @event in domainEvents)
            {
                await _busControl.Publish(@event, cancellationToken);
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
