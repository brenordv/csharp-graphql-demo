using System.Dynamic;
using System.Text.Json;
using CSharp.GraphQL.Domain.Models.Mutations;

namespace CSharp.GraphQL.Client.ExtensionMethods;

public static class ProductInputExtensions
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static dynamic ToDynamic(this ProductInput input)
    {
        var json = JsonSerializer.Serialize(input, Options);
        var expandoObject = JsonSerializer.Deserialize<ExpandoObject>(json, Options);
        return expandoObject;
    }
}