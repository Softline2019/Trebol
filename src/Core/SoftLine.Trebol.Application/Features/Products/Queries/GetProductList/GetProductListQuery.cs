using MediatR;
using SoftLine.Trebol.Application.Features.Products.Queries.Vms;

namespace SoftLine.Trebol.Application.Features.Products.Queries.GetProductList;

public class GetProductListQuery : IRequest<IReadOnlyList<ProductVm>>
{
}
