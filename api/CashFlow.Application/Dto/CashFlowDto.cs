namespace CashFlow.Application.Dto
{
    public sealed class CashFlowDto
    {
        public CashFlowDto(int id, double lowerBoundDiscountRate, double upperBoundDiscountRate, double increment)
        {
            Id = id;
            LowerBoundDiscountRate = lowerBoundDiscountRate;
            UpperBoundDiscountRate = upperBoundDiscountRate;
            Increment = increment;
        }

        public int Id { get; set; }
        public double LowerBoundDiscountRate { get; set; }
        public double UpperBoundDiscountRate { get; set; }
        public double Increment { get; set; }
    }
}
