﻿using MediatR;
using Microsoft.AspNetCore.Http;
using SoftLine.Trebol.Application.Features.Auths.Users.Vms;

namespace SoftLine.Trebol.Application.Features.Auths.Users.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<AuthResponse>
{
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public IFormFile? Foto { get; set; }
    public string? FotoUrl { get; set; }
    public string? FotoId { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
}
