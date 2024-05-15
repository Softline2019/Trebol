
using SoftLine.Trebol.Domain;

namespace SoftLine.Trebol.Application.Contracts.Identity;

public interface IAuthService
{
    string GetSessionUser();

    string CreateToken(Usuario usuario, IList<string>? roles);

}