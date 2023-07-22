namespace CSharp.GraphQL.Client.Models;

public record ProductNameAndPrice
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
}