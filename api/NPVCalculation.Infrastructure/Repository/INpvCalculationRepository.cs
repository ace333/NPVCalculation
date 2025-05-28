using NPVCalculation.Domain.Entities;

namespace NPVCalculation.Infrastructure.Repository
{
    public interface INpvCalculationRepository
    {
        Task InsertNpvCalculationAsync(NpvCalculation npvCalculation);
        Task<NpvCalculation> FindNpvCalculationByCashFlowId(int id);
    }
}
