using MediatR; 
using SoftLine.Trebol.Application.Features.Auths.Users.Vms;
using System.ComponentModel.DataAnnotations;

namespace SoftLine.Trebol.Application.Features.Auths.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<AuthResponse>
    {
        //[Required(ErrorMessage = "Email Vacio")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Password Vacio")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Company vacio")]
        public int IdCompany { get; set; }

    }
}

