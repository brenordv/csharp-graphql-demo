namespace CSharp.GraphQL.Client.Models;

public record GraphQLProductResponse<T>
{
    public T Product { get; set; }
}