using Shared.Domain.Core;

namespace CashFlow.Infrastructure.Core
{
    public interface IBaseRepository<TEntity> where TEntity : AggregateRoot
    {
        void Add(TEntity entity);
        Task CommitAsync();
    }
}
