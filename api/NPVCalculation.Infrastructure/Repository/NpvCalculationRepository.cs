using MongoDB.Driver;
using NPVCalculation.Domain.Entities;

namespace NPVCalculation.Infrastructure.Repository
{
    public class NpvCalculationRepository : INpvCalculationRepository
    {
        private readonly IMongoCollection<NpvCalculation> _npvCalculationCollection;

        public NpvCalculationRepository(IMongoDatabase database)
        {
            _npvCalculationCollection = database.GetCollection<NpvCalculation>("npvCalculations");
        }

        public async Task<NpvCalculation> FindNpvCalculationByCashFlowId(int id)
        {
            return await _npvCalculationCollection.Find(x => x.CashFlowId == id).SingleOrDefaultAsync();
        }

        public async Task InsertNpvCalculationAsync(NpvCalculation npvCalculation)
        {
            await _npvCalculationCollection.InsertOneAsync(npvCalculation);
        }
    }
}
