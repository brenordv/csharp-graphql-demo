namespace CSharp.GraphQL.Client.Models;

public record GraphQLProductUpdatedResponse<T>
{
    public T UpdateProduct { get; set; }
}