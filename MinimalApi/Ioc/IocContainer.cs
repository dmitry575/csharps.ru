using Microsoft.Extensions.Options;
using MinimalApi.Settings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MinimalApi.Ioc;

internal static class IocContainer
{
    public static IServiceCollection AddMongo(this IServiceCollection services, string connection)
    {
        services.AddSingleton(serviceProvider =>
        {
            IMongoDatabase CreateDatabase(string connectionString)
            {
                var mongoUrl = MongoUrl.Create(connectionString);
                var client = new MongoClient(mongoUrl);
                return client.GetDatabase(mongoUrl.DatabaseName);
            }

            return CreateDatabase(connection);
        });

        // Мапим GUID как UUID в монге а не как NUUID(он считается как legacy)
        MongoDefaults.GuidRepresentation = GuidRepresentation.Standard;

        return services;
    }
}
