namespace CSharp.GraphQL.Client.Models;

public record GraphQLProductAddedResponse<T>
{
    public T AddProduct { get; set; }
}