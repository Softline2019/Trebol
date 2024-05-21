using Microsoft.AspNetCore.Identity;

namespace SoftLine.Trebol.Domain;

public class User : IdentityUser
{    
    public string? FirstName { get; set; }
    public string? LastName { get; set; }    
    public string? Phone { get; set; }
    public bool IsActive { get; set; } = true;
    public int IdCompany { get; set; }
    public string? AvatarUrl { get; set; }
}
