using CashFlow.Domain.Entity;
using CashFlow.Infrastructure.Repository;
using MediatR;
using Shared.Domain.ValueObjects;

namespace CashFlow.Application.Command
{
    public class CreateCashFlowCommandHandler : IRequestHandler<CreateCashFlowCommand>
    {
        private readonly ICashFlowRepository _cashFlowRepository;
        private readonly INoSqlCashFlowRepository _noSqlCashFlowRepository;

        public CreateCashFlowCommandHandler(ICashFlowRepository cashFlowRepository, INoSqlCashFlowRepository noSqlCashFlowRepository)
        {
            _cashFlowRepository = cashFlowRepository;
            _noSqlCashFlowRepository = noSqlCashFlowRepository;
        }

        public async Task Handle(CreateCashFlowCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException("Command is null");
            }   

            var cashFlow = new CashFlowEntity(new DiscountRates(request.LowerBoundDiscountRate, request.UpperBoundDiscountRate), request.Increment);
            _cashFlowRepository.Add(cashFlow);
            await _cashFlowRepository.CommitAsync();

            var noSqlCashFlow = new NoSqlCashFlowEntity(cashFlow.Id, request.CashFlowValues);
            await _noSqlCashFlowRepository.InsertCashFlow(noSqlCashFlow);
        }
    }
}
