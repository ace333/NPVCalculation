namespace CashFlow.Application.Dto
{
    public sealed class CashFlowDto
    {
        public CashFlowDto(int id, double lowerBoundDiscountRate, double upperBoundDiscountRate, double increment, bool hasNpvCalculation)
        {
            Id = id;
            LowerBoundDiscountRate = lowerBoundDiscountRate;
            UpperBoundDiscountRate = upperBoundDiscountRate;
            Increment = increment;
            HasNpvCalculation = hasNpvCalculation;
        }

        public int Id { get; set; }
        public double LowerBoundDiscountRate { get; set; }
        public double UpperBoundDiscountRate { get; set; }
        public double Increment { get; set; }
        public bool HasNpvCalculation { get; set; }
    }
}
