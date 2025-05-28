using NPVCalculation.Domain.ValueObjects;
using Shared.Domain.Core;

namespace NPVCalculation.Domain.Entities
{
    public class NpvCalculation : NoSqlAggregateRoot
    {
        public NpvCalculation(int cashFlowId, ICollection<NpvCalculationElement> npvCalculations)
        {
            Id = Guid.NewGuid();
            CashFlowId = cashFlowId;
            NpvCalculations = npvCalculations;
        }

        protected NpvCalculation() { }

        public int CashFlowId { get; set; }
        public ICollection<NpvCalculationElement> NpvCalculations { get; set; }
    }
}
