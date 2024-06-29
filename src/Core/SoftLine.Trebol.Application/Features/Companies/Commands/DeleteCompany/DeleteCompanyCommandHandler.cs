using MediatR;
using SoftLine.Trebol.Application.Exceptions;
using SoftLine.Trebol.Application.Persistence;
using SoftLine.Trebol.Domain;

namespace SoftLine.Trebol.Application.Features.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyEntity = await _unitOfWork.Repository<Company>().GetByIdAsync(request.Id);
            if (companyEntity == null)
            {
                // Handle not found
                throw new NotFoundException(nameof(Company), request.Id);
            }

            _unitOfWork.Repository<Company>().DeleteEntity(companyEntity);
            await _unitOfWork.Complete();

            return Unit.Value;
        }
    }
}

