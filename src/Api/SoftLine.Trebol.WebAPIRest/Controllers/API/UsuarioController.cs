using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftLine.Trebol.Application.Contracts.Infrastructure;
using SoftLine.Trebol.Application.Features.Auths.Users.Commands.LoginUser;
using SoftLine.Trebol.Application.Features.Auths.Users.Commands.RegisterUser;
using SoftLine.Trebol.Application.Features.Auths.Users.Vms;
using SoftLine.Trebol.Application.Models.ImageManagement;
using System.Net;

namespace SoftLine.Trebol.WebAPIRest.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IMediator _mediator;
        private IManageImageService _manageImageService;

        public UsuarioController(IMediator mediator, IManageImageService manageImageService)
        {
            _mediator = mediator;
            _manageImageService = manageImageService;
        }

        [AllowAnonymous]
        [HttpPost("login", Name = "Login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginUserCommand request)
        {
            return await _mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpPost("register2", Name = "Register2")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<AuthResponse>> Register2([FromBody] RegisterUserCommand request)
        {
            if (request.Foto is not null)
            {
                var resultImage = await _manageImageService.UploadImage(new ImageData
                {
                    ImageStream = request.Foto!.OpenReadStream(),
                    Nombre = request.Nombre
                });

                request.FotoId = resultImage.PublicId;
                request.FotoUrl = resultImage.Url;
            }

            return await _mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpPost("register", Name = "Register")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<AuthResponse>> Register([FromForm] RegisterUserCommand request)
        {
            if (request.Foto is not null)
            {
                var resultImage = await _manageImageService.UploadImage(new ImageData
                {
                    ImageStream = request.Foto!.OpenReadStream(),
                    Nombre = request.Foto.Name
                }
                );

                request.FotoId = resultImage.PublicId;
                request.FotoUrl = resultImage.Url;
            }

            return await _mediator.Send(request);
        }
    }
}
