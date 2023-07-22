namespace CSharp.GraphQL.Client.Models;

public record GraphQLResponse<T>
{
    public T Data { get; set; }
    public List<GraphQLError> Errors { get; set; }
    public Dictionary<string, object> Extensions { get; set; }
}