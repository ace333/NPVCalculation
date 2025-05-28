using Shared.Domain.Core;
using Shared.Domain.ValueObjects;

namespace CashFlow.Domain.Entity
{
    public class CashFlowEntity : AggregateRoot
    {
        public CashFlowEntity(DiscountRates discountRates, double increment)
        {
            DiscountRates = discountRates;
            Increment = increment;
        }

        protected CashFlowEntity() { }

        public DiscountRates DiscountRates { get; set; }
        public double Increment { get; set; }
    }
}
