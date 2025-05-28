using Shared.Domain.Core;

namespace NPVCalculation.Domain.ValueObjects
{
    public class NpvCalculationElement : ValueObject
    {
        public double Rate { get; set; }
        public double NpvValue { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Rate;
            yield return NpvValue;
        }
    }
}
