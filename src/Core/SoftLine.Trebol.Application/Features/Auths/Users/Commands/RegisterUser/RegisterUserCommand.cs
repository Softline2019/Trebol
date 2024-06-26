﻿using MediatR;
using Microsoft.AspNetCore.Http;
using SoftLine.Trebol.Application.Features.Auths.Users.Vms;

namespace SoftLine.Trebol.Application.Features.Auths.Users.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<AuthResponse>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public IFormFile? Photo { get; set; }
    public string? PhotoUrl { get; set; }
    public string? PhotoId { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
}
