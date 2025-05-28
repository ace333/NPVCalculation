using CashFlow.Domain.Entity;
using CashFlow.Infrastructure.Context;
using CashFlow.Infrastructure.Core;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Repository
{
    public class CashFlowRepository : BaseRepository<CashFlowEntity>, ICashFlowRepository
    {
        private readonly CashFlowDbContext _cashFlowContext;

        public CashFlowRepository(CashFlowDbContext cashFlowContext) : base(cashFlowContext)
        {
            _cashFlowContext = cashFlowContext;
        }

        public IQueryable<CashFlowEntity> GetAll()
        {
            return _cashFlowContext.CashFlows.AsQueryable();
        }

        public async Task<CashFlowEntity> GetByIdAsync(int id)
        {
            return await _cashFlowContext.CashFlows.SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
