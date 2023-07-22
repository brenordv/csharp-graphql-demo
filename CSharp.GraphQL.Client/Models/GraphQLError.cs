namespace CSharp.GraphQL.Client.Models;

public record GraphQLError
{
    public string Message { get; init; }
    public List<GraphQLLocation> Locations { get; init; }
    public List<string> Path { get; init; }
    public Dictionary<string, object> Extensions { get; init; }
}
