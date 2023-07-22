using CSharp.GraphQL.Api.Data;
using CSharp.GraphQL.Domain.Models;
using CSharp.GraphQL.Domain.Models.Mutations;

namespace CSharp.GraphQL.Api.GraphQl;

public class Mutation
{
    [UseDbContext(typeof(AppDbContext))]
    public async Task<Product> AddProduct(ProductInput product,
        [Service(ServiceKind.Resolver)] AppDbContext context)
    {
        Product p = product;

        context.Products.Add(p);
        await context.SaveChangesAsync();

        return p;
    }
    
    [UseDbContext(typeof(AppDbContext))]
    public async Task<Product> UpdateProduct(Guid id, ProductUpdateInput input, [Service(ServiceKind.Resolver)] AppDbContext context)
    {
        var product = await context.Products.FindAsync(id);

        if (product is null)
        {
            // Handle not found case, possibly throw an exception
            throw new Exception($"Product with id {id} not found");
        }

        product.SoldBy = input.SoldBy ?? product.SoldBy;
        product.Name = input.Name ?? product.Name;
        product.Description = input.Description ?? product.Description;
        product.Price = input.Price ?? product.Price;
        product.ProductDesigner = input.ProductDesigner ?? product.ProductDesigner;
        product.AddedToStoreAt = input.AddedToStoreAt ?? product.AddedToStoreAt;
        product.LastShipmentReceivedAt = input.LastShipmentReceivedAt ?? product.LastShipmentReceivedAt;
        product.SoldSinceAvailable = input.SoldSinceAvailable ?? product.SoldSinceAvailable;
        product.IsAvailable = input.IsAvailable ?? product.IsAvailable;
        product.Rating = input.Rating ?? product.Rating;

        await context.SaveChangesAsync();

        return product;
    }

}