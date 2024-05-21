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
    public class AuthController : ControllerBase
    {
        private IMediator _mediator;
        private IManageImageService _manageImageService;

        public AuthController(IMediator mediator, IManageImageService manageImageService)
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
            if (request.Photo is not null)
            {
                var resultImage = await _manageImageService.UploadImage(new ImageData
                {
                    ImageStream = request.Photo!.OpenReadStream(),
                    Name = request.FirstName
                });

                request.PhotoId = resultImage.PublicId;
                request.PhotoUrl = resultImage.Url;
            }

            return await _mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpPost("register", Name = "Register")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<AuthResponse>> Register([FromForm] RegisterUserCommand request)
        {
            if (request.Photo is not null)
            {
                var resultImage = await _manageImageService.UploadImage(new ImageData
                    {
                        ImageStream = request.Photo!.OpenReadStream(),
                        Name = request.Photo.Name
                    }
                );

                request.PhotoId = resultImage.PublicId;
                request.PhotoUrl = resultImage.Url;
            }

            return await _mediator.Send(request);
        }
    }
}
