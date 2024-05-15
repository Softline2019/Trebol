using MediatR;
using SoftLine.Trebol.Application.Features.Auths.Users.Vms;

namespace SoftLine.Trebol.Application.Features.Auths.Users.Commands.LoginUser;

public class LoginUserCommand : IRequest<AuthResponse>
{
    public string? Email { get; set; }
    public string? Password { get; set; }

}
