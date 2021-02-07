using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDbCore.Interfaces;

namespace GymCompanion.Data
{
    public class MongoDbDatabaseFactory : IMongoDbDatabaseFactory
    {
        private IConfiguration _configuration;
        public MongoDbDatabaseFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IMongoDatabase CreateConnection()
        {
            var mongodbConnectionstring = _configuration["MongoDbConnectionString"];
            var client = new MongoClient(mongodbConnectionstring);
            return client.GetDatabase("GymCompanionDatabase");
        }
    }
}
