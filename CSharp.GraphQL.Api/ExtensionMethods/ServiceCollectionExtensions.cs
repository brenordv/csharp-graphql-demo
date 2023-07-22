using CSharp.GraphQL.Api.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CSharp.GraphQL.Api.ExtensionMethods;

public static class ServiceCollectionExtensions
{
    public static SqliteConnection AddDbContextWithMemSqlite(this IServiceCollection services)
    {
        var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
        var connection = new SqliteConnection(connectionStringBuilder.ToString());
        
        //Make it Singleton
        connection.Open();
        
        services.AddDbContextFactory<AppDbContext>(options => options.UseSqlite(connection));

        
        return connection;
    }
}