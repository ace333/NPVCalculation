using Shared.Domain.ValueObjects;

namespace Shared.Domain.Events
{
    public interface INpvCalculationTriggered
    {
        int CashFlowId { get; }
        ICollection<double> CashFlowValues { get;}
        DiscountRates DiscountRates { get; }
        double Increment { get; }
    }
}
