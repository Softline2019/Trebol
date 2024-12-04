using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftLine.Trebol.Application.Features.Companies.Commands.DeleteCompany;
using SoftLine.Trebol.Application.Features.Companies.Commands.UpdateCompany;
using SoftLine.Trebol.Application.Features.Companies.Queries.Vms;
using SoftLine.Trebol.Application.Features.Third.Queries.Vms;

namespace SoftLine.Trebol.WebAPIRest.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CompanyVm>), (int)HttpStatusCode.OK)]

        [HttpPost("create", Name = "CreateCompanyReceipt")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<CompanyVm>> CreateCompany([FromForm] Application.Features.Companies.Commands.CreateCompanies.CreateCompanyCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCompanyCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCompanyCommand { Id = id });
            return NoContent();
        }
    }
}

