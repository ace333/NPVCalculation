using CashFlow.Infrastructure.Repository;
using MediatR;
using Shared.Domain.Events;

namespace CashFlow.Application.Command
{
    public sealed class TriggerNpvCalculationCommandHandler : IRequestHandler<TriggerNpvCalculationCommand>
    {
        private readonly ICashFlowRepository _cashFlowRepository;
        private readonly INoSqlCashFlowRepository _noSqlCashFlowRepository;

        public TriggerNpvCalculationCommandHandler(ICashFlowRepository cashFlowRepository, INoSqlCashFlowRepository noSqlCashFlowRepository)
        {
            _cashFlowRepository = cashFlowRepository;
            _noSqlCashFlowRepository = noSqlCashFlowRepository;
        }

        public async Task Handle(TriggerNpvCalculationCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException("Command is null");
            }

            var cashFlow = await _cashFlowRepository.GetByIdAsync(request.CashFlowId);
            var noSqlCashFlow = await _noSqlCashFlowRepository.FindNpvCalculationById(request.CashFlowId);

            cashFlow.AddDomainEvent(new NpvCalculationTriggered(cashFlow.Id, noSqlCashFlow.Values, cashFlow.DiscountRates, cashFlow.Increment));
            await _cashFlowRepository.CommitAsync();
        }
    }
}
