using CSharp.GraphQL.Api.ExtensionMethods;
using CSharp.GraphQL.Api.GraphQl;

const int quantityFakeProducts = 10;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Services.AddDbContextWithMemSqlite();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

// Scheduling some tasks according to the application lifetime of the API.
var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();

lifetime.ApplicationStarted.Register(() =>
{
    // Wait for everything to be up and running before adding fake data.
    app.PopulateDatabase(quantityFakeProducts);
});

lifetime.ApplicationStopping.Register(() =>
{
    // Since I'm using Sqlite in memory, I need to close the connection before the application stops,
    // so this will be some sort of singleton.
    // Well, it's in memory, so I don't NEED to close the connection, but I'm doing it anyway.
    connection.Close();
    connection.Dispose();
});

app.MapGraphQL();
app.Run();