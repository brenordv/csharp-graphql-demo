namespace CSharp.GraphQL.Client.Models;

public class GraphQLProductsResponse<T>
{
    public IList<T> Products { get; set; }
}