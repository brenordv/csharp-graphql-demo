namespace CSharp.GraphQL.Domain.Models.Mutations;

public record ProductUpdateInput
{
    public string SoldBy { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal? Price { get; set; }
    public string ProductDesigner { get; set; }
    public DateTime? AddedToStoreAt { get; set; }
    public DateTime? LastShipmentReceivedAt { get; set; }
    public int? SoldSinceAvailable { get; set; }
    public bool? IsAvailable { get; set; }
    public float? Rating { get; set; }
    
    //Implicit conversion from Product to ProductUpdateInput
    public static implicit operator ProductUpdateInput(Product product) => new()
    {
        SoldBy = product.SoldBy,
        Name = product.Name,
        Description = product.Description,
        Price = product.Price,
        ProductDesigner = product.ProductDesigner,
        AddedToStoreAt = product.AddedToStoreAt,
        LastShipmentReceivedAt = product.LastShipmentReceivedAt,
        SoldSinceAvailable = product.SoldSinceAvailable,
        IsAvailable = product.IsAvailable,
        Rating = product.Rating
    };
}