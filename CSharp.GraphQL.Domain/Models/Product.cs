namespace CSharp.GraphQL.Domain.Models;

public record Product
{
    public Guid Id { get; set; }
    public string SoldBy { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ProductDesigner { get; set; }
    public DateTime AddedToStoreAt { get; set; }
    public DateTime LastShipmentReceivedAt { get; set; }
    public int SoldSinceAvailable { get; set; }
    public bool IsAvailable { get; set; }
    public float Rating { get; set; }
}