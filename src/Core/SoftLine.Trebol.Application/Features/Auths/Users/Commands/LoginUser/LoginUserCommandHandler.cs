using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SoftLine.Trebol.Application.Contracts.Identity;
using SoftLine.Trebol.Application.Exceptions;
using SoftLine.Trebol.Application.Features.Addresses.Vms;
using SoftLine.Trebol.Application.Features.Auths.Users.Vms;
using SoftLine.Trebol.Application.Persistence;
using SoftLine.Trebol.Domain;

namespace SoftLine.Trebol.Application.Features.Auths.Users.Commands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthResponse>
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;

    public LoginUserCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IAuthService authService, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _authService = authService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<AuthResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email!);
        if (user is null)
        {
            throw new NotFoundException(nameof(User), request.Email!);
        }

        if (!user.IsActive)
        {
            throw new Exception($"El usuario está bloqu ead, contacte al admin");
        }

        var resultado = await _signInManager.CheckPasswordSignInAsync(user, request.Password!, false);
        if (!resultado.Succeeded)
        {
            throw new Exception("Las credenciales del usuario son erroneas");
        }

        //var direccionEnvio = await _unitOfWork.Repository<Address>().GetEntityAsync(x => x.UserName == user.UserName);

        var roles = await _userManager.GetRolesAsync(user);

        var authResponse = new AuthResponse
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Phone = user.Phone,
            Email = user.Email,
            UserName = user.UserName,
            Avatar = user.AvatarUrl,            
            Token = _authService.CreateToken(user, roles),
            Roles = roles
        };

        return authResponse;
    }
}
