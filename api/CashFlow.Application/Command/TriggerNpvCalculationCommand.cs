using MediatR;

namespace CashFlow.Application.Command
{
    public sealed class TriggerNpvCalculationCommand : IRequest
    {
        public int CashFlowId { get; set; }
    }
}
