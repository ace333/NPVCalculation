using MediatR;

namespace CashFlow.Application.Command
{
    public sealed class CreateCashFlowCommand : IRequest
    {
        public ICollection<double> CashFlowValues { get; set; }
        public double LowerBoundDiscountRate { get; set; }
        public double UpperBoundDiscountRate { get; set; }
        public double Increment { get; set; }
    }
}
