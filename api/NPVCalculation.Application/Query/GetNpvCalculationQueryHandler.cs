using MediatR;
using NPVCalculation.Application.Dto;
using NPVCalculation.Infrastructure.Repository;

namespace NPVCalculation.Application.Query
{
    public class GetNpvCalculationQueryHandler : IRequestHandler<GetNpvCalculationQuery, NpvCalculationQueryDto>
    {
        private readonly INpvCalculationRepository _npvCalculationRepository;

        public GetNpvCalculationQueryHandler(INpvCalculationRepository npvCalculationRepository)
        {
            _npvCalculationRepository = npvCalculationRepository;
        }

        public async Task<NpvCalculationQueryDto> Handle(GetNpvCalculationQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException("Query is null");
            }

            var result = await _npvCalculationRepository.FindNpvCalculationByCashFlowId(request.CashFlowId);

            if (result == null)
            {
                throw new InvalidOperationException("Npv calculation not found for a given cash flow");
            }

            return new NpvCalculationQueryDto(result.NpvCalculations.Select(x => new NpvCalculationDto(x.Rate, x.NpvValue)));
        }
    }
}
