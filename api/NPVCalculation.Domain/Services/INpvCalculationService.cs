using NPVCalculation.Domain.Entities;
using Shared.Domain.ValueObjects;

namespace NPVCalculation.Domain.Services
{
    public interface INpvCalculationService
    {
        NpvCalculation CalclateNpv(ICollection<double> cahsFlow, DiscountRates discountRates, double increment, int cashFlowId);
    }
}
