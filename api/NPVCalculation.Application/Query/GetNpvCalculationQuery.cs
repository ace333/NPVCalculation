using MediatR;
using NPVCalculation.Application.Dto;

namespace NPVCalculation.Application.Query
{
    public class GetNpvCalculationQuery : IRequest<NpvCalculationQueryDto>
    {
        public GetNpvCalculationQuery(int cashFlowId)
        {
            CashFlowId = cashFlowId;
        }

        public int CashFlowId { get; private set; }
    }
}
