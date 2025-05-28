using MassTransit;
using NPVCalculation.Domain.Services;
using NPVCalculation.Infrastructure.Repository;
using Shared.Domain.Events;

namespace NPVCalculation.Application.Consumers
{
    public class NpvCalculationTriggeredConsumer : IConsumer<INpvCalculationTriggered>
    {
        private readonly INpvCalculationRepository _npvCalculationRepository;
        private readonly INpvCalculationService _npvCalculationService;

        public NpvCalculationTriggeredConsumer(INpvCalculationRepository npvCalculationRepository, INpvCalculationService npvCalculationService)
        {
            _npvCalculationRepository = npvCalculationRepository;
            _npvCalculationService = npvCalculationService;
        }

        public async Task Consume(ConsumeContext<INpvCalculationTriggered> context)
        {
            var message = context.Message;
            if(message == null)
            {
                throw new ArgumentNullException("Message is null");
            }

            var npvCalculation = _npvCalculationService.CalclateNpv(message.CashFlowValues, message.DiscountRates, message.Increment, message.CashFlowId);
            await _npvCalculationRepository.InsertNpvCalculationAsync(npvCalculation);
        }
    }
}
