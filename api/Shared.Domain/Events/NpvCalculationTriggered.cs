using Shared.Domain.Core;
using Shared.Domain.ValueObjects;

namespace Shared.Domain.Events
{
    public class NpvCalculationTriggered : IDomainEvent, INpvCalculationTriggered
    {
        public NpvCalculationTriggered(int cashFlowId, ICollection<double> cashFlowValues, DiscountRates discountRates, double increment)
        {
            CashFlowId = cashFlowId;
            CashFlowValues = cashFlowValues;
            DiscountRates = discountRates;
            Increment = increment;
        }

        public int CashFlowId { get; set; }
        public ICollection<double> CashFlowValues { get; set; }
        public DiscountRates DiscountRates { get; set; }
        public double Increment { get; set; }
    }
}
