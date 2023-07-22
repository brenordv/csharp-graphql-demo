using System.Globalization;
using CSharp.GraphQL.Client.ExtensionMethods;
using CSharp.GraphQL.Client.Interfaces;
using CSharp.GraphQL.Client.Models;
using CSharp.GraphQL.Domain.Models;
using CSharp.GraphQL.Domain.Models.Mutations;

namespace CSharp.GraphQL.Client.Clients;

public class ApiClient
{
    private readonly IGraphQlClient _graphQlClient;

    private static readonly string[] ProductKeys = new[]
    {
        "id", "name", "soldBy", "description", "price", "productDesigner", "addedToStoreAt", "lastShipmentReceivedAt",
        "soldSinceAvailable", "isAvailable", "rating"
    };

    public ApiClient(IGraphQlClient graphQlClient)
    {
        _graphQlClient = graphQlClient;
    }

    public async Task<Product> AddProduct(ProductInput newProduct, params string[] fields)
    {
        var fieldsToFetch = string.Join(" ", fields.Length == 0 ? ProductKeys : fields);
        var mutation = new
        {
            query = @$"
            mutation ($product: ProductInput!) {{
              addProduct(product: $product) {{
                {fieldsToFetch}
              }}
            }}",
            variables = new
            {
                // Here I could just add the props the way they are written in the query
                // above, but why do that when I can make my life more complicated (and dynamic)? ;-)
                product = newProduct
            }
        };

        var response = await _graphQlClient.ExecuteMutation<GraphQLProductAddedResponse<Product>>(mutation);

        await response.EnsureSuccessStatusCodeAsync();

        var content = response.Content;
        var product = content.Data.AddProduct;
        return product;
    }
    
    public async Task<Product> UpdateProduct(Guid productId, ProductUpdateInput productUpdate, params string[] fields)
    {
        var fieldsToFetch = string.Join(" ", fields.Length == 0 ? ProductKeys : fields);
        var mutation = new
        {
            query = $@"
            mutation ($id: UUID!, $product: ProductUpdateInput!) {{
              updateProduct(id: $id, input: $product) {{
                {fieldsToFetch}
              }}
            }}
        ",
            variables = new
            {
                id = productId,
                product = productUpdate
            }
        };

        var response = await _graphQlClient.ExecuteMutation<GraphQLProductUpdatedResponse<Product>>(mutation);

        await response.EnsureSuccessStatusCodeAsync();

        var content = response.Content;
        
        var product = content.Data.UpdateProduct;
        
        return product;
    }

    public async Task<IList<T>> FetchProducts<T>(params string[] fields)
    {
        var fieldsToFetch = string.Join(" ", fields.Length == 0 ? ProductKeys : fields);
        var query = new
        {
            query = $@"
        {{
            products  {{
                {fieldsToFetch}
            }}
        }}
        "
        };

        var response = await _graphQlClient.ExecuteQuery<T>(query);

        await response.EnsureSuccessStatusCodeAsync();
        var content = response.Content;

        return content.Data.Products;
    }

    public async Task<T> FetchProductById<T>(Guid productId, params string[] fields)
    {
        var fieldsToFetch = string.Join(" ", fields.Length == 0 ? ProductKeys : fields);
        var query = new
        {
            query = $@"query
    {{
        products(where: {{ id: {{ eq: ""{productId}"" }} }}) {{
            {fieldsToFetch}
        }}
    }}"
        };

        var response = await _graphQlClient.ExecuteQuery<T>(query);
        await response.EnsureSuccessStatusCodeAsync();
        var content = response.Content;

        return content.Data.Products.FirstOrDefault();
    }

    public async Task<IList<T>> FetchProductsByRating<T>(float minRate, params string[] fields)
    {
        var fieldsToFetch = string.Join(" ", fields.Length == 0 ? ProductKeys : fields);
        var query = new
        {
            query = $@"{{
              products(where: {{
                rating: {{
                  gte: {minRate.ToString(CultureInfo.InvariantCulture)}
                }}
              }}) {{
                {fieldsToFetch}   
              }}
            }}"
        };

        var response = await _graphQlClient.ExecuteQuery<T>(query);
        await response.EnsureSuccessStatusCodeAsync();
        var content = response.Content;

        return content.Data.Products;
    }
}