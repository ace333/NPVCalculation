using CashFlow.Domain.Entity;
using CashFlow.Infrastructure.Core;

namespace CashFlow.Infrastructure.Repository
{
    public interface ICashFlowRepository : IBaseRepository<CashFlowEntity>
    {
        IQueryable<CashFlowEntity> GetAll();
        Task<CashFlowEntity> GetByIdAsync(int id);
    }
}
