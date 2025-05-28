using CashFlow.Domain.Entity;
using MongoDB.Driver;

namespace CashFlow.Infrastructure.Repository
{
    public class NoSqlCashFlowRepository : INoSqlCashFlowRepository
    {
        private readonly IMongoCollection<NoSqlCashFlowEntity> _cashFlowCollection;

        public NoSqlCashFlowRepository(IMongoDatabase database)
        {
            _cashFlowCollection = database.GetCollection<NoSqlCashFlowEntity>("cashFlows");
        }

        public async Task<NoSqlCashFlowEntity> FindNpvCalculationById(int id)
        {
            return await _cashFlowCollection.Find(x => x.CashFlowId == id).SingleOrDefaultAsync();
        }

        public async Task InsertCashFlow(NoSqlCashFlowEntity npvCalculation)
        {
            await _cashFlowCollection.InsertOneAsync(npvCalculation);
        }
    }
}
