using AutoMapper;
using SoftLine.Trebol.Application.Features.Addresses.Vms;
using SoftLine.Trebol.Application.Features.Images.Queries.Vms;
using SoftLine.Trebol.Application.Features.Products.Queries.Vms;
using SoftLine.Trebol.Application.Features.Pucs.Commands.CreatePucs;
using SoftLine.Trebol.Application.Features.Pucs.Commands.DeletePucs;
using SoftLine.Trebol.Application.Features.Pucs.Commands.UpdatePucs;
using SoftLine.Trebol.Application.Features.Pucs.Queries.GetAllPucs;
using SoftLine.Trebol.Application.Features.Pucs.Queries.Vms;
using SoftLine.Trebol.Application.Features.Receipts.Commands.CreateReceipts;
using SoftLine.Trebol.Application.Features.Receipts.Queries.Vms;
using SoftLine.Trebol.Application.Features.Reviews.Queries.Vms;
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
        CreateMap<CreatePucsCommand, Puc>();
        CreateMap<GetAllPucsQuery, Puc>();
        CreateMap<DeletePucsCommand, Puc>();
        CreateMap<UpdatePucsCommand, Puc>();
        CreateMap<Puc, PucsVm>();



    }
}
