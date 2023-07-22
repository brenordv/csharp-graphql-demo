using CSharp.GraphQL.Client.Models;
using Refit;

namespace CSharp.GraphQL.Client.Interfaces;

public interface IGraphQlClient
{
    [Post("/graphql")]
    Task<ApiResponse<GraphQLResponse<GraphQLProductsResponse<T>>>> ExecuteQuery<T>([Body] object query);

    [Post("/graphql")]
    Task<ApiResponse<GraphQLResponse<T>>> ExecuteMutation<T>([Body] object mutation);
}