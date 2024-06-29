using AutoMapper;
using MediatR;
using SoftLine.Trebol.Application.Exceptions;
using SoftLine.Trebol.Application.Persistence;
using SoftLine.Trebol.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SoftLine.Trebol.Application.Features.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCompanyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyEntity = await _unitOfWork.Repository<Company>().GetByIdAsync(request.Id);
            if (companyEntity == null)
            {
                throw new NotFoundException(nameof(Company), request.Id);
            }

            // Actualiza las propiedades de la entidad
            companyEntity.NameShortCompany = request.NameShortCompany;
            companyEntity.NIT = request.NIT;
            companyEntity.CheckDigit = request.CheckDigit;
            companyEntity.CompanyName = request.CompanyName;
            companyEntity.Address = request.Address;
            companyEntity.City = request.City;
            companyEntity.Indicative = request.Indicative;
            companyEntity.DepartmentCode = request.DepartmentCode;
            companyEntity.AdministrationCode = request.AdministrationCode;
            companyEntity.Phone1 = request.Phone1;
            companyEntity.Phone2 = request.Phone2;
            companyEntity.PulledApart = request.PulledApart;
            companyEntity.LastClosingDate = request.LastClosingDate;
            companyEntity.TaxYear = request.TaxYear;
            companyEntity.Regime = request.Regime;
            companyEntity.Level1 = request.Level1;
            companyEntity.Level2 = request.Level2;
            companyEntity.Level3 = request.Level3;
            companyEntity.Level4 = request.Level4;
            companyEntity.Level5 = request.Level5;
            companyEntity.Level6 = request.Level6;
            companyEntity.CostCenter = request.CostCenter;
            companyEntity.CostCenterLevel1 = request.CostCenterLevel1;
            companyEntity.CostCenterLevel2 = request.CostCenterLevel2;
            companyEntity.CostCenterLevel3 = request.CostCenterLevel3;
            companyEntity.BankReconciliation = request.BankReconciliation;
            companyEntity.CashFlow = request.CashFlow;
            companyEntity.CompanyType = request.CompanyType;
            companyEntity.Economic_Activity = request.Economic_Activity;
            companyEntity.IndustryAndCommerceActivityCode = request.IndustryAndCommerceActivityCode;
            companyEntity.CompanyClass = request.CompanyClass;
            companyEntity.DeclaringClass = request.DeclaringClass;
            companyEntity.CommercialRegistration = request.CommercialRegistration;
            companyEntity.BranchNumber = request.BranchNumber;
            companyEntity.LegalRepresentative = request.LegalRepresentative;
            companyEntity.LegalRepresentativeID = request.LegalRepresentativeID;
            companyEntity.RepresentativeCard = request.RepresentativeCard;
            companyEntity.TaxAudit = request.TaxAudit;
            companyEntity.TaxAuditorID = request.TaxAuditorID;
            companyEntity.ProfessionalCard = request.ProfessionalCard;
            companyEntity.Counter = request.Counter;
            companyEntity.CounterId = request.CounterId;
            companyEntity.AccountantProfessionalCard = request.AccountantProfessionalCard;
            companyEntity.MinimumSanction = request.MinimumSanction;
            companyEntity.LocalMoney = request.LocalMoney;
            companyEntity.DescriptionOfLocal = request.DescriptionOfLocal;
            companyEntity.ParallelMoney = request.ParallelMoney;
            companyEntity.ParallelMoneycheck = request.ParallelMoneycheck;
            companyEntity.CostCenterClosure = request.CostCenterClosure;
            companyEntity.NitMinorCash = request.NitMinorCash;
            companyEntity.NitMajorCash = request.NitMajorCash;
            companyEntity.Email = request.Email;

            _unitOfWork.Repository<Company>().UpdateEntity(companyEntity);
            await _unitOfWork.Complete();

            return Unit.Value;
        }
    }
}
