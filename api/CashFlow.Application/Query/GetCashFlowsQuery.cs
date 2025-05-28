using CashFlow.Application.Dto;
using MediatR;

namespace CashFlow.Application.Query
{
    public sealed class GetCashFlowsQuery : PageableQuery, IRequest<PaginatedList<CashFlowDto>>
    {
    }
}
