namespace NPVCalculation.Application.Dto
{
    public sealed class NpvCalculationQueryDto
    {
        public NpvCalculationQueryDto(IEnumerable<NpvCalculationDto> npvCalculations)
        {
            NpvCalculations = npvCalculations;
        }

        public IEnumerable<NpvCalculationDto> NpvCalculations { get; set; }
    }
}
