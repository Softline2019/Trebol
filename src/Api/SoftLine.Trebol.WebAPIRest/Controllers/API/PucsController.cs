
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftLine.Trebol.Application.Features.Pucs.Commands.CreatePucs;
using SoftLine.Trebol.Application.Features.Pucs.Queries.GetAllPucs;
using SoftLine.Trebol.Application.Features.Pucs.Queries.Vms;
using System.Net;
using Microsoft.Extensions.Logging;

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
            _logger.LogError(ex, "Error creating PUC. Details: {Message}, StackTrace: {StackTrace}", ex.Message, ex.StackTrace);
            return StatusCode(500, "Internal server error while creating PUC");
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

}