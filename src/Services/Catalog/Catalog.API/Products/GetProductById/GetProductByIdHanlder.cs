using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
public record GetProductByIdResult(Product Product);

//internal class GetProductByIdQueryHandler
//    (IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger)
//    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
internal class GetProductByIdQueryHandler
    (IDocumentSession session )
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        //logger.LogInformation("GetProductByIdQueryHandler.Handle called for Product ID: {@Query}", query.Id);

        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException(query.Id);
        }

        return new GetProductByIdResult(product);
    }
}
