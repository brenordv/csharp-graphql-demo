using Bogus;
using CSharp.GraphQL.Domain.Models;
using CSharp.GraphQL.Domain.Models.Mutations;

namespace CSharp.GraphQL.Domain.DataGenerators;

public static class ProductGenerators
{
    public static IEnumerable<Product> GenerateProducts(int quantity)
    {
        var generator = InitProductFaker();
        return generator.Generate(quantity);
    }
    
    public static ProductInput GenerateProductInput()
    {
        var generator = InitProductInputFaker();
        return generator.Generate();
    }
    
    private static Faker<Product> InitProductFaker()
    {
        var faker = new Faker<Product>();
        faker
            .RuleFor(p => p.Id, f => f.Random.Guid())
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.Price, f => f.Random.Decimal(1, 1000))
            .RuleFor(p => p.ProductDesigner, f => f.Person.FullName)
            .RuleFor(p => p.AddedToStoreAt, f => f.Date.Past())
            .RuleFor(p => p.LastShipmentReceivedAt, f => f.Date.Past())
            .RuleFor(p => p.SoldSinceAvailable, f => f.Random.Int(1, 1000))
            .RuleFor(p => p.IsAvailable, f => f.Random.Bool())
            .RuleFor(p => p.Rating, f => f.Random.Float(0, 5))
            .RuleFor(p => p.SoldBy, f => f.Company.CompanyName());

        return faker;
    }
    
    private static Faker<ProductInput> InitProductInputFaker()
    {
        var faker = new Faker<ProductInput>();
        faker
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.Price, f => f.Random.Decimal(1, 1000))
            .RuleFor(p => p.ProductDesigner, f => f.Person.FullName)
            .RuleFor(p => p.AddedToStoreAt, f => f.Date.Past())
            .RuleFor(p => p.LastShipmentReceivedAt, f => f.Date.Past())
            .RuleFor(p => p.SoldSinceAvailable, f => f.Random.Int(1, 1000))
            .RuleFor(p => p.IsAvailable, f => f.Random.Bool())
            .RuleFor(p => p.Rating, f => f.Random.Float(0, 5))
            .RuleFor(p => p.SoldBy, f => f.Company.CompanyName());

        return faker;
    }
}