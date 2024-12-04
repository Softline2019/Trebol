//using AutoMapper;
//using MediatR;
//using SoftLine.Trebol.Application.Exceptions;
//using SoftLine.Trebol.Application.Persistence;
//using SoftLine.Trebol.Domain;

//namespace SoftLine.Trebol.Application.Features.Third.Commands.UpdateThirdParty
//{
//    public class UpdateThirdPartyCommandHandler : IRequestHandler<UpdateThirdPartyCommand>
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IMapper _mapper;

//        public UpdateThirdPartyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
//        {
//            _unitOfWork = unitOfWork;
//            _mapper = mapper;
//        }

//        public async Task<Unit> Handle(UpdateThirdPartyCommand request, CancellationToken cancellationToken)
//        {
//            var thirdPartyEntity = await _unitOfWork.Repository<ThirdParty>().GetByIdAsync(request.Id);
//            if (thirdPartyEntity == null)
//            {
//                throw new NotFoundException(nameof(ThirdParty), request.Id);
//            }

//            thirdPartyEntity.NIT = request.NIT;
//            thirdPartyEntity.Class = request.Class;
//            thirdPartyEntity.Regime = request.Regime;
//            thirdPartyEntity.VerificationDigitNIT = request.VerificationDigitNIT;
//            thirdPartyEntity.NITCode = request.NITCode;
//            thirdPartyEntity.BusinessName = request.BusinessName;
//            thirdPartyEntity.Address = request.Address;
//            thirdPartyEntity.City = request.City;
//            thirdPartyEntity.Phone1 = request.Phone1;
//            thirdPartyEntity.Phone2 = request.Phone2;
//            thirdPartyEntity.Mobile = request.Mobile;
//            thirdPartyEntity.Fax = request.Fax;
//            thirdPartyEntity.Email = request.Email;
//            thirdPartyEntity.FirstName = request.FirstName;
//            thirdPartyEntity.MiddleName = request.MiddleName;
//            thirdPartyEntity.LastName1 = request.LastName1;
//            thirdPartyEntity.LastName2 = request.LastName2;
//            thirdPartyEntity.CountryCode = request.CountryCode;
//            thirdPartyEntity.DepartmentCode = request.DepartmentCode;
//            thirdPartyEntity.EconomicActivityCode = request.EconomicActivityCode;
//            thirdPartyEntity.HasDocument = request.HasDocument;
//            thirdPartyEntity.IsMandator = request.IsMandator;
//            thirdPartyEntity.AdmissionDate = request.AdmissionDate;
//            thirdPartyEntity.UserUpdate = request.UserUpdate;
//            thirdPartyEntity.UpdateDate = request.UpdateDate;
//            thirdPartyEntity.TaxMailbox = request.TaxMailbox;
//            thirdPartyEntity.IsSupplier = request.IsSupplier;
//            thirdPartyEntity.IsClient = request.IsClient;
//            thirdPartyEntity.IsEmployee = request.IsEmployee;
//            thirdPartyEntity.IsBeneficiary = request.IsBeneficiary;
//            thirdPartyEntity.CompanyShortName = request.CompanyShortName;
//            thirdPartyEntity.User = request.User;

//            _unitOfWork.Repository<ThirdParty>().UpdateEntity(thirdPartyEntity);
//            await _unitOfWork.Complete();

//            return Unit.Value;
//        }
//    }
//}
