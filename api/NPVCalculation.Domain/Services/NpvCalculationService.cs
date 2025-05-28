using NPVCalculation.Domain.Entities;
using NPVCalculation.Domain.ValueObjects;
using Shared.Domain.ValueObjects;

namespace NPVCalculation.Domain.Services
{
    public class NpvCalculationService : INpvCalculationService
    {
        public NpvCalculation CalclateNpv(ICollection<double> cashFlows, DiscountRates discountRates, double increment, int cashFlowId)
        {
            if (cashFlows == null || !cashFlows.Any())
                throw new ArgumentException("Cash flows cannot be null or empty");

            if (increment <= 0)
                throw new ArgumentException("Increment must be greater than 0");

            var results = new List<NpvCalculationElement>();

            for (var rate = discountRates.LowerBound; rate <= discountRates.UpperBound; rate += increment)
            {
                double npv = 0.0;

                int t = 0;
                foreach (var cashFlow in cashFlows)
                {
                    // math equation (from internet)
                    npv += cashFlow / Math.Pow(1 + (rate / 100.0), t);
                    t++;
                }

                results.Add(new NpvCalculationElement
                {
                    Rate = rate,
                    NpvValue = Math.Round(npv, 4)
                });
            }

            return new NpvCalculation(cashFlowId, results);
        }
    }
}
