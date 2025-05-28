using Shared.Domain.Core;

namespace CashFlow.Domain.Entity
{
    public class NoSqlCashFlowEntity : NoSqlAggregateRoot
    {
        public NoSqlCashFlowEntity(int cashFlowId, ICollection<double> values)
        {
            Id = Guid.NewGuid();
            CashFlowId = cashFlowId;
            Values = values;
        }

        public int CashFlowId { get; set; }
        public ICollection<double> Values { get; set; }
    }
}
