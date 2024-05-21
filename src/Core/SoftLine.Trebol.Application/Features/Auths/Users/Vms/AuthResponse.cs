using SoftLine.Trebol.Application.Features.Addresses.Vms;

namespace SoftLine.Trebol.Application.Features.Auths.Users.Vms;

public class AuthResponse
{
    public string? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Token { get; set; }
    public string? Avatar { get; set; }
    public int IdCompany { get; set; }
    public ICollection<string>? Roles { get; set; }

}