using MediatR;

namespace SoftLine.Trebol.Application.Features.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommand : IRequest
    {
        public int Id { get; set; }

    }

}
