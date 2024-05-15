using SoftLine.Trebol.Application.Models.Email;
using System.Net.Mail;

namespace SoftLine.Trebol.Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task<bool> SendEmail(EmailMessage email, string token);
}
