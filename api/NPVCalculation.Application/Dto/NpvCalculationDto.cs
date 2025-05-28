namespace NPVCalculation.Application.Dto
{
    public sealed class NpvCalculationDto
    {
        public NpvCalculationDto(double rate, double npvCalculation)
        {
            Rate = rate;
            NpvCalculation = npvCalculation;
        }

        public double Rate { get; private set; }
        public double NpvCalculation { get; private set; }
    }
}
