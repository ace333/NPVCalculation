using MediatR;
using Microsoft.AspNetCore.Mvc;
using NPVCalculation.Application.Dto;
using NPVCalculation.Application.Query;
using Swashbuckle.AspNetCore.Annotations;

namespace NPVCalculation.Api.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Route("api/[controller]")]
    public class NpvCalculationController : ControllerBase
    {
        private readonly IMediator _mediator;        

        public NpvCalculationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NpvCalculationDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Npv calculation not found for a given cash flow id")]
        [SwaggerOperation("Returns npv calculation for a given cash flow id")]
        public async Task<IActionResult> GetCompanyByIdAsync(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetNpvCalculationQuery(id));
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
