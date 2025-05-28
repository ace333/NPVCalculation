using Shared.Domain.Core;

namespace Shared.Domain.ValueObjects
{
    public class DiscountRates : ValueObject
    {
        public DiscountRates(double lowerBound, double upperBound)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }

        public double LowerBound { get; set; }
        public double UpperBound { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return LowerBound;
            yield return UpperBound;
        }
    }
}
