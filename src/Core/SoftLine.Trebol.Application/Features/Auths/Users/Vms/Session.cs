using SoftLine.Trebol.Application.Features.Addresses.Vms;

namespace SoftLine.Trebol.Application.Features.Auths.Users.Vms;

public class Session
{
    public string userName { get; set; }
    public string email { get; set; }
    public string token { get; set; }
    public ICollection<string>? Roles { get; set; }

}