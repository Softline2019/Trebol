using AutoMapper;
using SoftLine.Trebol.Application.Features.Addresses.Vms;
using SoftLine.Trebol.Application.Features.Companies.Commands.CreateCompanies;
using SoftLine.Trebol.Application.Features.Companies.Commands.DeleteCompany;
using SoftLine.Trebol.Application.Features.Companies.Commands.UpdateCompany;
using SoftLine.Trebol.Application.Features.Companies.Queries.Vms;
using SoftLine.Trebol.Application.Features.Images.Queries.Vms;
using SoftLine.Trebol.Application.Features.Products.Queries.Vms;
using SoftLine.Trebol.Application.Features.Pucs.Commands.CreatePucs;
using SoftLine.Trebol.Application.Features.Pucs.Queries.Vms;
using SoftLine.Trebol.Application.Features.Receipts.Commands.CreateReceipts;
using SoftLine.Trebol.Application.Features.Receipts.Queries.Vms;
using SoftLine.Trebol.Application.Features.Reviews.Queries.Vms;
using SoftLine.Trebol.Application.Features.Third.Commands.CreateThirdParty;
using SoftLine.Trebol.Application.Features.Third.Commands.DeleteThirdParty;
using SoftLine.Trebol.Application.Features.Third.Commands.UpdateThirdParty;
using SoftLine.Trebol.Application.Features.Third.Queries.Vms;
using SoftLine.Trebol.Domain;

namespace SoftLine.Trebol.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductVm>()
            .ForMember(p => p.CategoryNombre, x => x.MapFrom(a => a.Category!.Nombre))
            .ForMember(p => p.NumeroReviews, x => x.MapFrom(a => a.Reviews == null ? 0 : a.Reviews.Count));

        CreateMap<Image, ImageVm>();
        CreateMap<Review, ReviewVm>();
        CreateMap<Address, AddressVm>();
        CreateMap<Receipt, ReceiptsVm>();
        CreateMap<CreateReceiptsCommand, Receipt>();

        //--------------terceros-------------------------------
        CreateMap<ThirdParty, ThirdPartyVm>();
        CreateMap<CreateThirdPartyCommand, ThirdParty>();
        CreateMap<DeleteThirdPartyCommand, ThirdParty>();
        CreateMap<UpdateThirdPartyCommand, ThirdParty>();
       
        //----------------Company-------------------------------
        CreateMap<Company, CompanyVm>();
        CreateMap<CreateCompanyCommand, Company>();
        CreateMap<DeleteCompanyCommand, Company>();
        CreateMap<UpdateCompanyCommand, Company>();

        //---------------pucs-----------------------------------
        CreateMap<Puc, PucsVm>();
        CreateMap<CreatePucsCommand, Puc>();




    }
}
