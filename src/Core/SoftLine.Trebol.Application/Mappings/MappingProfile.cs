using AutoMapper;
using SoftLine.Trebol.Application.Features.Images.Queries.Vms;
using SoftLine.Trebol.Application.Features.Products.Queries.Vms;
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

    }
}
