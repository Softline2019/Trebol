using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftLine.Trebol.Application.Features.Third.Commands.CreateThirdParty;
using SoftLine.Trebol.Application.Features.Third.Queries.Vms;
using System.Net;

namespace SoftLine.Trebol.WebAPIRest.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThirdPartyController : ControllerBase
    {
        private IMediator _mediator;

        public ThirdPartyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("create", Name = "CreateThirdPartyReceipt")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ThirdPartyVm>> CreateThirdParty([FromForm] CreateThirdPartyCommand request)
        {
            return await _mediator.Send(request);
        }



    }

}
