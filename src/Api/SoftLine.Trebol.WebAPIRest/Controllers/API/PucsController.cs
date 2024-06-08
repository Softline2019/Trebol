
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftLine.Trebol.Application.Features.Pucs.Commands.CreatePucs;
using SoftLine.Trebol.Application.Features.Pucs.Queries.GetAllPucs;
using SoftLine.Trebol.Application.Features.Pucs.Queries.Vms;
using System.Net;
using Microsoft.Extensions.Logging;
using SoftLine.Trebol.Application.Features.Pucs.Commands.DeletePucs;
using SendGrid.Helpers.Errors.Model;
using SoftLine.Trebol.Application.Features.Pucs.Commands.UpdatePucs;

namespace SoftLine.Trebol.WebAPIRest.Controllers.API;

[Route("api/[controller]")]
[ApiController]
public class PucsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<PucsController> _logger;

    public PucsController(IMediator mediator, ILogger<PucsController> logger)
    {
        _mediator = mediator;
        _logger = logger;

    }

    [HttpPost("create", Name = "CreatePuc")]
    [ProducesResponseType((int)HttpStatusCode.OK)]

    public async Task<ActionResult<PucsVm>>CreatePuc([FromForm] CreatePucsCommand request)
    {
        try
        {
            var result = _mediator.Send(request);
            return Ok(result);
        }

        catch (Exception ex)
        {
            _logger.LogError(ex, "Error crear PUC. Details: {Message}, StackTrace: {StackTrace}", ex.Message, ex.StackTrace);
            return StatusCode(500, "Internal server error con crear PUC");
        }
    }



    [HttpGet("getAll", Name = "GetAllPucs")]
    [ProducesResponseType(typeof(List<PucsVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<List<PucsVm>>> GetAllPucs()
    {
        var query = new GetAllPucsQuery();
        var result = await _mediator.Send(query);
       return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePuc(int id)
    {
        var command = new DeletePucsCommand { Id = id };
        try
        {
            await _mediator.Send(command);
            return NoContent(); // HTTP 204
        }
        catch (NotFoundException)
        {
            return NotFound(); // HTTP 404
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePuc(int id, [FromBody] UpdatePucsCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("ID in URL does not match ID in request body.");
        }

        try
        {
            await _mediator.Send(command);
            return NoContent(); // HTTP 204
        }
        catch (NotFoundException)
        {
            return NotFound(); // HTTP 404
        }
    }
}
