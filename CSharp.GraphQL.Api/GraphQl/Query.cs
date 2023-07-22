using CSharp.GraphQL.Api.Data;
using CSharp.GraphQL.Domain.Models;

namespace CSharp.GraphQL.Api.GraphQl;

public class Query
{
    [UseDbContext(typeof(AppDbContext))]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Product> GetProducts([Service(ServiceKind.Resolver)] AppDbContext context) =>
        context.Products;
}