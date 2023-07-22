namespace CSharp.GraphQL.Domain.Models.Mutations;

public record ProductInput
{
    public string SoldBy { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
    public string ProductDesigner { get; init; }
    public DateTime AddedToStoreAt { get; init; }
    public DateTime LastShipmentReceivedAt { get; init; }
    public int SoldSinceAvailable { get; init; }
    public bool IsAvailable { get; init; }
    public float Rating { get; init; }
    
    //Implicit conversion from ProductInputMutation to Product
    public static implicit operator Product(ProductInput input) => new()
    {
        Id = Guid.NewGuid(),
        SoldBy = input.SoldBy,
        Name = input.Name,
        Description = input.Description,
        Price = input.Price,
        ProductDesigner = input.ProductDesigner,
        AddedToStoreAt = input.AddedToStoreAt,
        LastShipmentReceivedAt = input.LastShipmentReceivedAt,
        SoldSinceAvailable = input.SoldSinceAvailable,
        IsAvailable = input.IsAvailable,
        Rating = input.Rating
    };
};