using CSharp.GraphQL.Api.Data;
using CSharp.GraphQL.Domain.DataGenerators;
using Microsoft.EntityFrameworkCore;

namespace CSharp.GraphQL.Api.ExtensionMethods;

public static class WebApplicationExtensions
{
    public static void PopulateDatabase(this WebApplication app, int quantity)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        context.Database.EnsureCreated();
        context.Database.Migrate();
        context.Database.EnsureCreated();

        context.Products.AddRange(ProductGenerators.GenerateProducts(quantity));
        context.SaveChanges();
    }
}