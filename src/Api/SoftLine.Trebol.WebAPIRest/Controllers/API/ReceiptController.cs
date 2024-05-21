using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftLine.Trebol.Application.Features.Receipts.Commands.CreateReceipts;
using SoftLine.Trebol.Application.Features.Receipts.Queries.Vms;
using System.Net;

namespace SoftLine.Trebol.WebAPIRest.Controllers.API;

[Route("api/[controller]")]
[ApiController]
public class ReceiptController : ControllerBase
{
    private IMediator _mediator;

    public ReceiptController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create", Name = "CreateReceipt")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<ReceiptsVm>> CreateReceipt([FromForm] CreateReceiptsCommand request)
    {
        return await _mediator.Send(request);
    }
}
