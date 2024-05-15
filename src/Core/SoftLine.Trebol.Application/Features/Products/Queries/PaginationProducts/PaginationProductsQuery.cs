using MediatR;
using SoftLine.Trebol.Application.Features.Products.Queries.Vms;
using SoftLine.Trebol.Application.Features.Shared.Queries;
using SoftLine.Trebol.Domain;

namespace SoftLine.Trebol.Application.Features.Products.Queries.PaginationProducts;

public class PaginationProductsQuery : PaginationBaseQuery, IRequest<PaginationVm<ProductVm>>
{
    public int? CategoryId { get; set; }
    public decimal? PrecioMax { get; set; }
    public decimal? PrecioMin { get; set; }
    public int? Rating { get; set; }
    public ProductStatus? Status { get; set; }
}