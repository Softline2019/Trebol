using MediatR;
using SoftLine.Trebol.Application.Features.Products.Queries.Vms;

namespace SoftLine.Trebol.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<ProductVm>
{
    public int ProductId { get; set; }
    public GetProductByIdQuery(int productId)
    {
        ProductId = productId == 0 ? throw new ArgumentNullException(nameof(productId)) : productId;
    }
}
