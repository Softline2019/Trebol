
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftLine.Trebol.Application.Features.Pucs.Commands.CreatePucs;
using SoftLine.Trebol.Application.Features.Pucs.Queries.Vms;
using System.Net;

namespace SoftLine.Trebol.WebAPIRest.Controllers.API;

[Route("api/[controller]")]
[ApiController]
public class PucsController : ControllerBase
{
    private IMediator _mediator;

    public PucsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create", Name ="CreatePuc")]
    [ProducesResponseType((int)HttpStatusCode.OK)]

    public async Task<ActionResult<PucsVm>> CreatePuc([FromForm] CreatePucsCommand request)
    {
        return await _mediator.Send(request);
    }
}
