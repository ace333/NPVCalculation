using CashFlow.Domain.Entity;

namespace CashFlow.Infrastructure.Repository
{
    public interface INoSqlCashFlowRepository
    {
        Task InsertCashFlow(NoSqlCashFlowEntity npvCalculation);
        Task<NoSqlCashFlowEntity> FindNpvCalculationById(int id);
    }
}
