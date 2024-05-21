using CloudinaryDotNet.Core;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SoftLine.Trebol.Application.Contracts.Identity;
using SoftLine.Trebol.Application.Exceptions;
using SoftLine.Trebol.Application.Features.Auths.Users.Vms;
using SoftLine.Trebol.Domain;

namespace SoftLine.Trebol.Application.Features.Auths.Users.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, AuthResponse>
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IAuthService _authService;

    public RegisterUserCommandHandler(
                UserManager<User> userManager,
                RoleManager<IdentityRole> roleManager,
                IAuthService authService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _authService = authService;
    }

    public async Task<AuthResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var existeUsuarioByEmail = await _userManager.FindByEmailAsync(request.Email!) is null ? false : true;
        if (existeUsuarioByEmail)
        {
            throw new BadRequestException("El Email del usuario ya existe en la base de datos.");
        }

        var existeUsuarioByUserName = await _userManager.FindByNameAsync(request.UserName!) is null ? false : true;
        if (existeUsuarioByEmail)
        {
            throw new BadRequestException("El Username del usuario ya existe en la base de datos.");
        }

        var usuario = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Phone = request.Phone,
            Email = request.Email,
            UserName = request.UserName,
            AvatarUrl = request.PhotoUrl
        };

        var resultado = await _userManager.CreateAsync(usuario!, request.Password!);
        if (resultado.Succeeded)
        {
            await _userManager.AddToRoleAsync(usuario, AppRole.GenericUser);
            var roles = await _userManager.GetRolesAsync(usuario);

            return new AuthResponse
            {
                Id = usuario.Id,
                FirstName = usuario.FirstName,
                LastName = usuario.LastName,
                Phone = usuario.Phone,
                Email = usuario.Email,
                UserName = usuario.UserName,
                Avatar = usuario.AvatarUrl,
                Token = _authService.CreateToken(usuario, roles),
                Roles = roles
            };
        }

        throw new Exception("No se pudo registrar el usuario");
    }
}
