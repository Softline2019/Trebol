using AutoMapper;
using MediatR;
using SoftLine.Trebol.Application.Features.Companies.Commands.CreateCompanies;
using SoftLine.Trebol.Application.Features.Companies.Commands.CreateCompany;
using SoftLine.Trebol.Application.Features.Companies.Queries.Vms;
using SoftLine.Trebol.Application.Persistence;
using SoftLine.Trebol.Domain;

namespace SoftLine.Trebol.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CompanyVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCompanyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CompanyVm> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyEntity = _mapper.Map<Company>(request);
            await _unitOfWork.Repository<Company>().AddAsync(companyEntity);
            await _unitOfWork.Complete();

            return _mapper.Map<CompanyVm>(companyEntity);
        }
    }
}
