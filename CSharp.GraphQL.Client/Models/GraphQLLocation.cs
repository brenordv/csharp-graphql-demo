namespace CSharp.GraphQL.Client.Models;

public record GraphQLLocation
{
    public int Line { get; init; }
    public int Column { get; init; }
}