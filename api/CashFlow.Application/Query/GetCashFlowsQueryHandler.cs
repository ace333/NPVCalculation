using CashFlow.Application.Dto;
using CashFlow.Infrastructure.Repository;
using MediatR;

namespace CashFlow.Application.Query
{
    public class GetCashFlowsQueryHandler : IRequestHandler<GetCashFlowsQuery, PaginatedList<CashFlowDto>>
    {
        private readonly ICashFlowRepository _cashFlowRepository;

        public GetCashFlowsQueryHandler(ICashFlowRepository cashFlowRepository)
        {
            _cashFlowRepository = cashFlowRepository;
        }

        public async Task<PaginatedList<CashFlowDto>> Handle(GetCashFlowsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException("Query is null");
            }

            return await _cashFlowRepository.GetAll()
                .Select(c => new CashFlowDto(c.Id, c.DiscountRates.LowerBound, c.DiscountRates.UpperBound, c.Increment, c.HasNpvCalculation))
                .AsPaginatedList(request.Limit, request.Offset);
        }
    }
}
