using CSharp.GraphQL.Client.Clients;
using CSharp.GraphQL.Client.Interfaces;
using CSharp.GraphQL.Client.Models;
using CSharp.GraphQL.Domain.DataGenerators;
using CSharp.GraphQL.Domain.Models;
using CSharp.GraphQL.Domain.Models.Mutations;
using Refit;

const string apiBaseUrl = "https://localhost:7091/";
Console.WriteLine("This is a Demo of GraphQL Client in C#");
Console.WriteLine($"You can also try the API accessing '{apiBaseUrl}graphql' with your browser");


// Initializing client
var client = InitApiClient();

// New Product to add
var newProduct = ProductGenerators.GenerateProductInput();

// Adding new product
var addedProduct = await client.AddProduct(newProduct);

// Fetching all products
var fullProducts = await client.FetchProducts<Product>();

// Fetching just products names and ids
var productNamesAndIds = await client.FetchProducts<ProductNames>("id", "name");

// Fetching single product by Id -- all fields
var productId = productNamesAndIds[0].Id;
var product = await client.FetchProductById<Product>(productId);

// Fetching single product by Id -- name and price
var productOnlyNameAndPrice = await client.FetchProductById<ProductNameAndPrice>(productId);

// Updating the product we just fetched
ProductUpdateInput productUpdate = product;
productUpdate.Name = "Updated Name";
var updateResult = await client.UpdateProduct(productId, productUpdate);

var updatedProductAfterFetch = await client.FetchProductById<Product>(productId);
var updatedProductOk = updatedProductAfterFetch.Name == productUpdate.Name && productUpdate.Name == updateResult.Name;

// Fetching all the products
const float minRating = 2.5f;
var productsWithRatingAbove = await client.FetchProductsByRating<Product>(minRating);
var allRatingsOk = productsWithRatingAbove.All(p => p.Rating >= minRating);

PrintResults(addedProduct != null, fullProducts, productNamesAndIds, product,  productOnlyNameAndPrice, allRatingsOk, productsWithRatingAbove, updatedProductOk);

#region Aux Methods
static ApiClient InitApiClient()
{
    
    var graphQlClient = RestService.For<IGraphQlClient>(apiBaseUrl);
    var client = new ApiClient(graphQlClient);
    return client;
}

static void PrintResults(
    bool result, 
    ICollection<Product> productClientSides, 
    ICollection<ProductNames> productNamesList,
    Product product,
    ProductNameAndPrice productOnlyNameAndPrice,
    bool allRatingsOk,
    ICollection<Product> productsWithRatingAbove,
    bool updatedProductOk)
{
    Console.WriteLine($"Product added: {result}");

    Console.WriteLine("Full Products fetched:");
    foreach (var p in productClientSides)
        Console.WriteLine(p);

    Console.WriteLine("Just products names and ids fetched:");
    foreach (var p in productNamesList)
        Console.WriteLine(p);

    Console.WriteLine($"Product fetched by id: {product}");
    Console.WriteLine($"Product fetched by id - only name and price: {productOnlyNameAndPrice}");
    Console.WriteLine($"Updated product worked? {updatedProductOk}");
    
    Console.WriteLine($"Found {productsWithRatingAbove.Count} products with rating above {minRating}: {allRatingsOk}");
    
    Console.WriteLine("------------------------------------");
    Console.WriteLine($"Product count: Full: {productClientSides.Count} / Names: {productNamesList.Count}");
}
#endregion