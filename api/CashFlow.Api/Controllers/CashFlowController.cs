using CashFlow.Application.Command;
using CashFlow.Application.Dto;
using CashFlow.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CashFlow.Api.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Route("api/[controller]")]
    public class CashFlowController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CashFlowController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedList<CashFlowDto>))]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerOperation("Returns cash flows collection paginated")]
        public async Task<IActionResult> GetCashFlowsAsync([FromQuery] GetCashFlowsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerOperation("Creates a new cash flow entity and returns 201 success code")]
        public async Task<IActionResult> CreateCashFlowAsync([FromBody] CreateCashFlowCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return Created();
        }

        [HttpPost("trigger")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerOperation("Creates a new cash flow entity and returns 201 success code")]
        public async Task<IActionResult> TriggerNpvCalculationAsync([FromBody] TriggerNpvCalculationCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return Accepted();
        }
    }
}
